using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data;
using ardo.DatabaseProvider.PostgreSQL.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace ardo.DatabaseProvider.PostgreSQL.InstrospectionService
{

    public class PGIntrospectionFactory : IDatabaseObjectFactory
    {
        private IDatabaseServices services;
        
        public PGIntrospectionFactory(IDatabaseServices services)
        {
            this.services = services;
        }


        public IDatabaseInfo CreateLocalDatabaseInfo()
        {
            return new PGDatabaseInfo(services, ((PGRuntimeDBConfiguration)services.DatabaseConfiguration).DatabaseIdentifier);
        }

        public IDatabaseInfo CreateDatabaseInfo(string databaseIdentifier)
        {
            if (databaseIdentifier.StartsWith("\""))
            {
                databaseIdentifier = databaseIdentifier.Substring(1, databaseIdentifier.Length - 2);
            }
            return new PGDatabaseInfo(services, databaseIdentifier);
        }

        public ITableSourceInfo CreateTableSourceInfo(string qualifiedName)
        {
            // TODO: better qualified name parsing
            String[] parts = qualifiedName.Trim().Split('.');
            switch (parts.Length)
            {
                case 1:
                    return new PGTableSource(services, new PGDatabaseInfo(services, ""), parts[0].Trim('"'));
                default:
                    return new PGTableSource(services, new PGDatabaseInfo(services, parts[0].Trim('"')), parts[1].Trim('"'));
            }
            
        }
    }
}
