using ardo.DatabaseProvider.PostgreSQL.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ardo.DatabaseProvider.Redshift.ConfigurationService
{
    public class RedshiftDatabaseConfigurator: BaseDatabaseConfiguration
    {

        public override IDatabaseProvider DatabaseProvider { get { return ardoRedshift.Instance; } }

        [UserDefinedConfigurationParameter(Label = "Server", IsMandatory = true, Order = 1, Region = ParameterRegion.DatabaseLocation)]
        public string Server { get; set; }

        [UserDefinedConfigurationParameter(Label = "Database", IsMandatory = true, Order = 2, Region = ParameterRegion.DatabaseLocation)]
        public string Database { get; set; }

        [UserDefinedConfigurationParameter(Label = "Username", IsMandatory = true, Order = 1, Region = ParameterRegion.UserSpecific)]
        public string Username { get; set; }

        [UserDefinedConfigurationParameter(Label = "Password", IsPassword = true, Order = 2, Region = ParameterRegion.UserSpecific)]
        public string Password { get; set; }

        [UserDefinedConfigurationParameter(Label = "Port", IsMandatory = false, Order = 3, Region = ParameterRegion.DatabaseLocation)]
        public int Port { get; set; } 

        private AdvancedConfiguration _advConfig =
            new AdvancedConfiguration(
                "Insert configuration parameters separated by ';'. Username and Password will be inserted automatically if present.",
                "Connection String Parameters",
                "$AdvancedConnectionStringField;Username=$Username;Password=<hidden>");

        public override AdvancedConfiguration AdvancedConfiguration
        {
            get
            {
                return _advConfig;
            }
            set
            {
                _advConfig = value;
            }
        }

        protected override string AssembleAdvancedConnectionString()
        {
            return _advConfig.AdvancedConnectionStringField + string.Format(";Username={0};Password={1}", Username, Password);
        }

        public override string DatabaseIdentifier
        {
            get
            {
                return Database;
            }
        }


        public RedshiftDatabaseConfigurator(): base()
        {
            Port = 5439;
        }



        protected override string AssembleBasicConnectionString()
        {
            return string.Format("Host={0};Username={1};Password={2};Database={3};Port={4};MaxPoolSize=100;ConnectionLifeTime=120;SSL=True;Sslmode=Prefer;", Server, Username, Password, Database, Port);
        }


        public override IRuntimeDatabaseConfiguration RuntimeDatabaseConfiguration
        {
            get
            {
                return new PGRuntimeDBConfiguration()
                {
                    ConnectionString = ConnectionString,
                    DatabaseIdentifier = Database,
                    Username = Username
                };
            }
        }


    }

}
