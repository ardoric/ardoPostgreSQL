using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ardo.DatabaseProvider.PostgreSQL;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using ardo.DatabaseProvider.Redshift.ConfigurationService;

namespace ardo.DatabaseProvider.Redshift
{
    public class ardoRedshift : BaseDatabaseProvider
    {
        public static readonly IDatabaseProvider Instance = new ardoRedshift();

        public override DatabaseProviderKey Key
        {
            get { return DatabaseProviderKey.Deserialize("ardoRedshift"); }
        }


        public IIntegrationDatabaseConfiguration CreateEmptyDatabaseConfiguration()
        {
            return new RedshiftDatabaseConfigurator();
        }

        public override IIntegrationDatabaseConfiguration CreateEmptyIntegrationDatabaseConfiguration()
        {
            return new RedshiftDatabaseConfigurator();
        }


        public override IProviderProperties Properties
        {
            get { return new RedshiftProviderProperties(this); }
        }

        public override IDatabaseServices GetIntegrationDatabaseServices(IRuntimeDatabaseConfiguration databaseConfiguration)
        {
            return new ardoRedshiftServices(databaseConfiguration);
        }

    }


}
