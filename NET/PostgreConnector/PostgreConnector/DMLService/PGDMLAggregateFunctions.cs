using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.DatabaseProvider.Postgres.DMLService;
using OutSystems.HubEdition.Extensibility.Data.DMLService;

namespace OutSystems.HubEdition.DatabaseProvider.Postgres.DMLService
{
    public class PGDMLAggregateFunctions: BaseDMLAggregateFunctions
    {
        public PGDMLAggregateFunctions(IDMLService service) : base(service) { }
        // base implementations seem to be enough. We'll see in the tests :)
    }
}
