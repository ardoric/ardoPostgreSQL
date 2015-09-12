using ardo.DatabaseProvider.PostgreSQL.ExecutionService;
using ardo.DatabaseProvider.Redshift.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ardo.DatabaseProvider.Redshift
{
    public class RedshiftProviderProperties: PGProviderProperties
    {

        public RedshiftProviderProperties(IDatabaseProvider provider) : base(provider) { }

        public override string DisplayName
        {
            get { return "Redshift"; }
        }

    }
}
