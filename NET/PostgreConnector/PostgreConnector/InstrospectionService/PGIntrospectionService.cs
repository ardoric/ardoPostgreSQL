using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data;
using System.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace ardo.DatabaseProvider.PostgreSQL.InstrospectionService
{
    public class PGIntrospectionService: BaseIntrospectionService
    {
        public PGIntrospectionService(IDatabaseServices services)
            : base(services)
        {
        }

        protected virtual string ListDatabasesQuery()
        {
            return "SELECT schema_name FROM information_schema.schemata";
        }

        public override IEnumerable<IDatabaseInfo> ListDatabases()
        {
            using (IDbConnection connection = GetConnection())
            {
                IDbCommand cmd = CreateCommand(connection, ListDatabasesQuery());
                using (IDataReader reader = cmd.ExecuteReader()) {
                    List<IDatabaseInfo> res = new List<IDatabaseInfo>();
                    // add the public schema which always exists but isn't featured here.
                    bool added_public = false;
                    while (reader.Read())
                    {
                        string schema = (string)reader["schema_name"];
                        res.Add(new PGDatabaseInfo(DatabaseServices, (string)reader["schema_name"]));
                        if (schema == "public")
                            added_public = true;
                    }
                    if (!added_public)
                        res.Add(new PGDatabaseInfo(DatabaseServices, "public"));
                    return res;
                }
            }

        }

        protected virtual string ListTableSourcesQuery()
        {
            return "SELECT table_schema, table_name FROM information_schema.tables WHERE table_schema = :dbname";
        }

        public override IEnumerable<ITableSourceInfo> ListTableSources(IDatabaseInfo database, IsTableSourceToIgnore isTableSourceToIgnore)
        {
            using (IDbConnection connection = GetConnection())
            {
                IDbCommand cmd = CreateCommand(connection, ListTableSourcesQuery());
                CreateParameter(cmd, "dbname", DbType.String, database.Identifier);

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<ITableSourceInfo> res = new List<ITableSourceInfo>();

                    while (reader.Read())
                    {
                        string name = (string)reader["table_name"];
                        if (!isTableSourceToIgnore(name)) // what's this? do I have to respect this?
                        {
                            res.Add(new PGTableSource(DatabaseServices, database, name));
                        }
                    }

                    return res;
                }
            }
        }

        protected virtual string GetTableSourceColumnsQuery() 
        {
            return @"SELECT cols.column_name, 
                             cols.data_type, 
                             cols.is_nullable,
                             cols.column_default, 
                             cols.character_maximum_length, 
                             cols.numeric_precision, 
                             cols.numeric_precision_radix, 
                             cols.numeric_scale,
                             cons.constraint_type
                     FROM information_schema.columns cols
                     LEFT JOIN 
                     ( 
                        information_schema.key_column_usage usage 
                        INNER JOIN information_schema.table_constraints cons ON (cons.constraint_name = usage.constraint_name and cons.constraint_type = 'PRIMARY KEY') 
                     ) ON (cols.column_name = usage.column_name and cols.table_name = usage.table_name and cols.table_schema = usage.table_schema)
                     WHERE cols.table_schema = :schema 
                     AND cols.table_name = :tableName
                     ORDER BY cols.ordinal_position";
        }

        public override IEnumerable<ITableSourceColumnInfo> GetTableSourceColumns(ITableSourceInfo tableSource)
        {
            PGTableSource source = tableSource as PGTableSource;
            if (source == null)
                return null;

            List<ITableSourceColumnInfo> res = new List<ITableSourceColumnInfo>();
            using (IDbConnection connection = GetConnection())
            {
                IDbCommand cmd = CreateCommand(connection, GetTableSourceColumnsQuery());
                
                CreateParameter(cmd, "schema", DbType.String, source.Database.Identifier);
                CreateParameter(cmd, "tableName", DbType.String, source.Name);
                
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(new PGColumnInfo(tableSource, reader));
                    }
                }


                return res;
            }
        }

        protected virtual string GetTableSourceForeignKeysQuery()
        {
            return @"SELECT 
                       key_column_usage.constraint_name    AS constraint_name,
                       key_column_usage.column_name        AS source_column_name,
                       table_constraints.table_catalog     AS dest_database,
                       table_constraints.table_schema      AS dest_schema,
                       table_constraints.table_name        AS dest_table_name,
                       referential_constraints.delete_rule AS delete_rule,
                       dest_usage.column_name              AS dest_column_name
                    FROM information_schema.key_column_usage
                    INNER JOIN information_schema.referential_constraints ON (key_column_usage.constraint_name = referential_constraints.constraint_name)
                    INNER JOIN information_Schema.table_constraints ON (referential_constraints.unique_constraint_name = table_constraints.constraint_name)
                    INNER JOIN information_schema.key_column_usage AS dest_usage ON (table_constraints.constraint_name = dest_usage.constraint_name)
                    WHERE key_column_usage.table_name = :tableName AND key_column_usage.table_schema = :schemaName
                    AND table_constraints.constraint_type = 'PRIMARY KEY'";
        }

        public override IEnumerable<ITableSourceForeignKeyInfo> GetTableSourceForeignKeys(ITableSourceInfo tableSource)
        {
            PGTableSource source = tableSource as PGTableSource;
            if (source == null)
                return null;

            using (IDbConnection connection = GetConnection())
            {
                List<ITableSourceForeignKeyInfo> keys = new List<ITableSourceForeignKeyInfo>();
                // should prolly do some better inner join matching
                IDbCommand cmd = CreateCommand(connection, GetTableSourceForeignKeysQuery());
                CreateParameter(cmd, "tableName", DbType.String, source.Name);
                CreateParameter(cmd, "schemaName", DbType.String, source.Database.Identifier);

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        keys.Add(new PGFKInfo(DatabaseServices, source, reader));
                    }
                }
                
                return keys;
            }
            
        }

        /*
        public override IIntrospectionObjectFactory ObjectFactory
        {
            get { return new PGIntrospectionFactory(DatabaseServices); }
        }
         */


        #region Helper Functions
        // these helper functions could exist in BaseIntrospectionServices
        private IDbConnection GetConnection()
        {
            return DatabaseServices.TransactionService.CreateConnection();
        }

        private IDbCommand CreateCommand(IDbConnection conn, string sqltext)
        {
            return DatabaseServices.ExecutionService.CreateCommand(conn, sqltext);
        }

        private IDbDataParameter CreateParameter(IDbCommand cmd, string name, DbType dbType, object paramValue) 
        {
            return DatabaseServices.ExecutionService.CreateParameter(cmd, name, dbType, paramValue);
        }
        #endregion
    }
}
