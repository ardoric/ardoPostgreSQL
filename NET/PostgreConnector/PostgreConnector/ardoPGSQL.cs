using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.DatabaseProvider.Postgres.ConfigurationService;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.DatabaseProvider.Postgres.ExecutionService;

namespace OutSystems.HubEdition.DatabaseProvider.Postgres
{
    public class ardoPGSQL: BaseDatabaseProvider
    {
        public static readonly IDatabaseProvider Instance = new ardoPGSQL();

        public ardoPGSQL() { }

        public IIntegrationDatabaseConfiguration CreateEmptyDatabaseConfiguration()
        {
            return new PostgreDatabaseConfigurator();
        }

        public override IDatabaseServices GetIntegrationDatabaseServices(IRuntimeDatabaseConfiguration databaseConfiguration)
        {
            return new ardoPGDBServices(databaseConfiguration);
        }


        public override IIntegrationDatabaseConfiguration CreateEmptyIntegrationDatabaseConfiguration()
        {
            return new PostgreDatabaseConfigurator();
        }


        public override DatabaseProviderKey Key
        {
            get { return DatabaseProviderKey.Deserialize("ardoPGSQL"); }
        }

        public override IProviderProperties Properties
        {
            get { return new PGProviderProperties(this); }
        }

    }
}
