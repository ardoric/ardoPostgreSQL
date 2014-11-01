using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data.DMLService.DMLPlaceholders;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace OutSystems.HubEdition.DatabaseProvider.Postgres.DMLService
{
    public class PGDMLEntityActions: BaseDMLEntityActions
    {
        private IDictionary<SelectPlaceholder, string> getforupdateplaceholder;

        public PGDMLEntityActions(IDMLService service, ITableSourceInfo tableSourceInfo) : base(service, tableSourceInfo)
        {
            getforupdateplaceholder = new Dictionary<SelectPlaceholder, string>()
            {
                { SelectPlaceholder.AfterStatement, "FOR UPDATE" }
            };
        }

        public override IDictionary<SelectPlaceholder, string> SQLPlaceholderValuesForGetForUpdate()
        {
            return getforupdateplaceholder;
        }

        public override IDictionary<InsertPlaceholder, string> SQLPlaceholderValuesForCreateAndRetrieveId(string idColumnName, string outputParameterName, out RetrieveIdMethod retrieveIdMethod)
        {
            retrieveIdMethod = RetrieveIdMethod.ReturnValue;

            return new Dictionary<InsertPlaceholder, string>()
            {
                { InsertPlaceholder.AfterStatement, "RETURNING " + idColumnName }
            };
        }
    }
}
