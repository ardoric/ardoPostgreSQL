using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace ardo.DatabaseProvider.PostgreSQL.DMLService
{
    public class PGDMLService: BaseDMLService
    {

        public PGDMLService(IDatabaseServices dbServices) : base(dbServices) { }

        public override IDMLDefaultValues DefaultValues
        {
            get { return new PGDMLDefaultValues(this); }
        }

        public override IDMLFunctions Functions
        {
            get { return new PGDMLFunctions(this); }
        }

        public override IDMLEntityActions GetEntityActions(ITableSourceInfo tableSourceInfo)
        {
            return new PGDMLEntityActions(this, tableSourceInfo);
        }

        public override IDMLIdentifiers Identifiers
        {
            get { return new PGDMLIdentifiers(this); }
        }

        public override IDMLOperators Operators
        {
            get { return new BaseDMLOperators(this); }
        }

        public override IDMLQueries Queries
        {
            get { return new PGDMLQueries(this); }
        }

        // or just return BaseDMLAggregateFunctions, since I didn't change anything.
        public override IDMLAggregateFunctions AggregateFunctions
        {
            get { return new PGDMLAggregateFunctions(this); }
        }
    }
}
