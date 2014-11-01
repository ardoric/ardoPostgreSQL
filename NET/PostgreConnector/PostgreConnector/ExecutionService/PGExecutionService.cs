using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using System.Data.Common;
using OutSystems.HubEdition.Extensibility.Data;
using Npgsql;


namespace OutSystems.HubEdition.DatabaseProvider.Postgres.ExecutionService
{
    public class PGExecutionService: BaseExecutionService
    {

        public PGExecutionService(IDatabaseServices dbServices)
            : base(dbServices)
        {
        }

        public override bool IsConnectionException(DbException e)
        {
            NpgsqlException exception = e as NpgsqlException;
            if (exception == null)
                return false;

            // TODO: handle localization ? do it by Code ?
            return exception.BaseMessage.StartsWith("Failed to establish a connection to ");
        }

        // http://www.mono-project.com/PostgreSQL says "You can use parameter names with Npgsql (:) or SqlServer (@) prefix style."
        public override string ParameterPrefix
        {
            get { return ":"; }
        }
    }
}
