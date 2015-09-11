using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ardo.DatabaseProvider.PostgreSQL;
using OutSystems.RuntimeCommon;

namespace ardo.DatabaseProvider.Redshift
{
    public class ardoRedshift : ardoPGSQL
    {
        public override DatabaseProviderKey Key
        {
            get { return DatabaseProviderKey.Deserialize("ardoRedshift"); }
        }

    }
}
