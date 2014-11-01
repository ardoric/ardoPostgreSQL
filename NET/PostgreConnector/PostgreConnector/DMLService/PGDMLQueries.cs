using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.DMLService.DMLPlaceholders;

namespace OutSystems.HubEdition.DatabaseProvider.Postgres.DMLService
{
    public class PGDMLQueries: BaseDMLQueries
    {

        private Dictionary<StatementPlaceholder, string> count;

        public PGDMLQueries(IDMLService dmlService) : base(dmlService) {

            count = new Dictionary<StatementPlaceholder, string>();
            count.Add(StatementPlaceholder.BeforeStatement, "SELECT COUNT(1) FROM (");
            count.Add(StatementPlaceholder.AfterStatement, ") as result");

        }


        public override IDictionary<StatementPlaceholder, string> SQLPlaceholderValuesForCountQuery()
        {
            return count;
        }

        public override IDictionary<SelectPlaceholder, string> SQLPlaceholderValuesForMaxRecords(string maxRecordsParam)
        {
            
            Dictionary<SelectPlaceholder, string> res = new Dictionary<SelectPlaceholder,string>();
            res.Add(SelectPlaceholder.BeforeStatement, "SELECT * FROM (");
            res.Add(SelectPlaceholder.AfterStatement, ") as result LIMIT " + maxRecordsParam);
            return res;
        }
    }
}
