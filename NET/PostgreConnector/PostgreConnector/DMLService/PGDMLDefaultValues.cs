using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ardo.DatabaseProvider.PostgreSQL.DMLService;
using OutSystems.HubEdition.Extensibility.Data.DMLService;


namespace ardo.DatabaseProvider.PostgreSQL.DMLService
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
