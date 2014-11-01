using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data;

namespace OutSystems.HubEdition.DatabaseProvider.Postgres.ExecutionService
{
    public class PGProviderProperties: BaseProviderProperties
    {

        public PGProviderProperties(IDatabaseProvider provider) : base(provider) { }

        // what on earth is this?
        public override string DatabaseContainerName
        {
            get { return "Schema"; }
        }

        /*
        public override string ParameterTypeName
        {
            get { return "Npgsql.NpgsqlParameter"; }
        }
         */

        public override string DisplayName
        {
            get { return "PostgreSQL"; }
        }
    }
}
