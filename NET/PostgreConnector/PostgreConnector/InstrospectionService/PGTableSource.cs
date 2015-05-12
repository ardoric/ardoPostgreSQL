using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace ardo.DatabaseProvider.PostgreSQL.InstrospectionService
{
    // still not sure about this representation
    class PGTableSource: BaseTableSourceInfo
    {
        public PGTableSource(IDatabaseServices dbServices, IDatabaseInfo dbInfo, string name) :
            base(dbServices, dbInfo, name, dbInfo.Identifier + ".\"" + name + "\"")
        {
        }
    }
}
