using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace ardo.DatabaseProvider.PostgreSQL.InstrospectionService
{
    public class PGDatabaseInfo: BaseDatabaseInfo
    {
        private string _identifier;
        public PGDatabaseInfo(IDatabaseServices services, string identifier) : base(services) 
        {
            _identifier = identifier;
        }

        public override string Identifier
        {
            get { return _identifier; }
        }
    }
}
