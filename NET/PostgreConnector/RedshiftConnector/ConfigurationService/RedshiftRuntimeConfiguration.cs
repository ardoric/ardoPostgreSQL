using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ardo.DatabaseProvider.Redshift.ConfigurationService
{
    class RedshiftRuntimeConfiguration: IRuntimeDatabaseConfiguration
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
            get { return ardoRedshift.Instance; }
        }

    }
}
