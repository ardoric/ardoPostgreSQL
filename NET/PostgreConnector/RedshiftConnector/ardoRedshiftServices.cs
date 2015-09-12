using ardo.DatabaseProvider.PostgreSQL;
using ardo.DatabaseProvider.PostgreSQL.DMLService;
using ardo.DatabaseProvider.PostgreSQL.ExecutionService;
using ardo.DatabaseProvider.PostgreSQL.InstrospectionService;
using ardo.DatabaseProvider.PostgreSQL.TransactionService;
using ardo.DatabaseProvider.Redshift.ExecutionService;
using ardo.DatabaseProvider.Redshift.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ardo.DatabaseProvider.Redshift
{
    public class ardoRedshiftServices : IDatabaseServices
    {
        IRuntimeDatabaseConfiguration configuration;

        public ardoRedshiftServices(IRuntimeDatabaseConfiguration dbconfig) 
        {
            configuration = dbconfig;
        }
        public virtual IRuntimeDatabaseConfiguration DatabaseConfiguration { get { return configuration; } }


        public virtual IIntrospectionService IntrospectionService { get { return new RedshiftIntrospectionService(this); } }
        public virtual IDMLService DMLService { get { return new PGDMLService(this); } }
        public virtual IExecutionService ExecutionService { get { return new RedshiftExecutionService(this); } }
        public virtual ITransactionService TransactionService { get { return new PGTransactionService(this); } }



        public virtual IDatabaseObjectFactory ObjectFactory
        {
            get { return new PGIntrospectionFactory(this); }
        }



    }
}
