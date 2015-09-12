using ardo.DatabaseProvider.PostgreSQL.InstrospectionService;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ardo.DatabaseProvider.Redshift.IntrospectionService
{
    public class RedshiftIntrospectionService: PGIntrospectionService
    {
        public RedshiftIntrospectionService(IDatabaseServices services)
            : base(services)
        {
        }

        // no information about primary key
        protected override string GetTableSourceColumnsQuery() {
            return @"SELECT cols.column_name, 
                             cols.data_type, 
                             cols.is_nullable,
                             cols.column_default, 
                             cols.character_maximum_length, 
                             cols.numeric_precision, 
                             cols.numeric_precision_radix, 
                             cols.numeric_scale,
                             NULL constraint_type
                     FROM information_schema.columns cols
                     WHERE cols.table_schema = :schema 
                     AND cols.table_name = :tableName
                     ORDER BY cols.ordinal_position"; ;
        }

        // always empty for now.
        public override IEnumerable<ITableSourceForeignKeyInfo> GetTableSourceForeignKeys(ITableSourceInfo tableSource)
        {
            return new List<ITableSourceForeignKeyInfo>();
        }
    }
}
