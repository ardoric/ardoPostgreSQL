using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.DatabaseProvider.Postgres.DMLService;
using OutSystems.HubEdition.Extensibility.Data.DMLService;


namespace OutSystems.HubEdition.DatabaseProvider.Postgres.DMLService
{
    public class PGDMLDefaultValues: BaseDMLDefaultValues
    {
        public PGDMLDefaultValues(IDMLService service) : base(service) { }

        public override string Boolean
        {
            get
            {
                return "FALSE";
            }
        }
    }
}
