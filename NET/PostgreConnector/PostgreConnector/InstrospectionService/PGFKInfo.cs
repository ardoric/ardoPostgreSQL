using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using System.Data;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace ardo.DatabaseProvider.PostgreSQL.InstrospectionService
{
    class PGFKInfo : ITableSourceForeignKeyInfo
    {
        public PGFKInfo(IDatabaseServices dbServices, ITableSourceInfo source, IDataReader reader)
        {
            TableSource = source;
            Name = (string)reader["constraint_name"];
            ColumnName = (string)reader["source_column_name"];
            IsCascadeDelete = "DELETE".Equals(((string)reader["delete_rule"]).ToUpper());
            ReferencedColumnName = (string)reader["dest_column_name"];

            ReferencedTableSource = new PGTableSource(dbServices, source.Database, (string)reader["dest_table_name"]);

        }

        public ITableSourceInfo TableSource
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public string ColumnName
        {
            get;
            private set;
        }

        public ITableSourceInfo ReferencedTableSource
        {
            get;
            private set;
        }

        public string ReferencedColumnName
        {
            get;
            private set;
        }

        public bool IsCascadeDelete
        {
            get;
            private set;
        }
    }
}
