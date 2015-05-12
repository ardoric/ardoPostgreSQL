using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using ardo.DatabaseProvider.PostgreSQL.ExecutionService;
using ardo.DatabaseProvider.PostgreSQL.DMLService;
using ardo.DatabaseProvider.PostgreSQL.InstrospectionService;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using ardo.DatabaseProvider.PostgreSQL.TransactionService;

namespace ardo.DatabaseProvider.PostgreSQL
{
    public class ardoPGDBServices : IDatabaseServices
    {
        IRuntimeDatabaseConfiguration configuration;

        public ardoPGDBServices(IRuntimeDatabaseConfiguration dbconfig)
        {
            configuration = dbconfig;
        }

        public IRuntimeDatabaseConfiguration DatabaseConfiguration { get { return configuration; } }

        public IDMLService DMLService { get { return new PGDMLService(this); } }
        public IIntrospectionService IntrospectionService { get { return new PGIntrospectionService(this); } }

        // this could be a parametrized class with the IDbConnection type being used.
        public IExecutionService ExecutionService { get { return new PGExecutionService(this); } }



        public IDatabaseObjectFactory ObjectFactory
        {
            get { return new PGIntrospectionFactory(this); }
        }

        public ITransactionService TransactionService
        {
            get { return new PGTransactionService(this); }
        }
    }
}
