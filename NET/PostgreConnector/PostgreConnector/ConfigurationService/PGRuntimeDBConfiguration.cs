using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data;

namespace OutSystems.HubEdition.DatabaseProvider.Postgres.ConfigurationService
{
    public class PGRuntimeDBConfiguration: IRuntimeDatabaseConfiguration
    {
        [ConfigurationParameter]
        public string ConnectionString
        {
            get;
            set;
        }

        [ConfigurationParameter]
        public string DatabaseIdentifier
        {
            get;
            set;
        }

        [ConfigurationParameter]
        public string Username
        {
            get;
            set;
        }

        public IDatabaseProvider DatabaseProvider
        {
            get { return ardoPGSQL.Instance; }
        }
    }
}
