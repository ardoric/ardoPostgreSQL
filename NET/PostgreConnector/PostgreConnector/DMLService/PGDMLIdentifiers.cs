using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OutSystems.HubEdition.Extensibility.Data.DMLService;
using ardo.DatabaseProvider.PostgreSQL.ConfigurationService;

namespace ardo.DatabaseProvider.PostgreSQL.DMLService
{
    public class PGDMLIdentifiers: BaseDMLIdentifiers
    {

        public PGDMLIdentifiers(IDMLService service): base(service)
        {
        }

        /*
        public override string EscapeAndQualifyIdentifier(string objectName)
        {
            string schema = ((PostgreDatabaseConfigurator)DMLService.DatabaseServices.DatabaseConfiguration).Database;
            return EscapeIdentifier(schema) + ".public." + EscapeIdentifier(objectName); // is this what's wanted ?
            // maybe I should support other schemas?
        }
         */

        public override int MaxLength
        {
            // http://www.postgresql.org/docs/9.1/static/sql-syntax-lexical.html
            get { return 63; }
        }

        /*
        // what exactly is this ?
        public override string ParamPrefix
        {
            // http://www.mono-project.com/PostgreSQL says "You can use parameter names with Npgsql (:) or SqlServer (@) prefix style."
            get { return ":"; }
        }
         */
    }
}
