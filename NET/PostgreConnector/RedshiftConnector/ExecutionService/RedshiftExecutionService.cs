using ardo.DatabaseProvider.PostgreSQL.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ardo.DatabaseProvider.Redshift.ExecutionService
{
    public class RedshiftExecutionService: PGExecutionService
    {

        public RedshiftExecutionService(IDatabaseServices dbServices)
            : base(dbServices)
        {
        }

        /* The following code is meant to address the decimal parameters
         * losing precision (becoming integers).
         * I believe this should work, but I had to change the tests
         * to get them to pass. I'll need to double check if this is 
         * the right way.
         * 
        public override DbType ConvertToDbType(Type type)
        {
            if (type == typeof(string))
            {
                return DbType.String;
            }
            else if (type == typeof(Int32))
            {
                return DbType.Int32;
            }
            else if (type == typeof(DateTime))
            {
                return DbType.DateTime;
            }
            else if (type == typeof(decimal))
            {
                return DbType.Double;
            }
            else if (type == typeof(bool))
            {
                return DbType.Boolean;
            }
            else
            {
                throw new NotSupportedException("Unable to convert " + type.ToString() + " to DbType");
            }
        }

        public override object TransformRuntimeToDatabaseValue(DbType dbType, object value)
        {
            if (dbType == DbType.Double)
            {
                return decimal.ToDouble((decimal)value);
            }
            return base.TransformRuntimeToDatabaseValue(dbType, value);
        }
         */

    }
}
