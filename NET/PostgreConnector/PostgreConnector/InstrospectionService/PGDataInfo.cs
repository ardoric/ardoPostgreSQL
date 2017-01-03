using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace ardo.DatabaseProvider.PostgreSQL.InstrospectionService
{
    class PGDataInfo : IDataTypeInfo
    {

        public PGDataInfo(string data_type, int maxLength, int precision, int precision_radix, int numeric_scale)
        {
            SqlDataType = data_type;
            switch (data_type.ToLower())
            {

                case "character":
                case "character varying":
                case "varchar":
                case "char":
                case "uuid":
                case "text":
                    Type = DBDataType.TEXT;
                    if (maxLength != -1)
                        Length = maxLength;
                    break;
                
                case "boolean":
                case "bool":
                    Type = DBDataType.BOOLEAN;
                    break;

                case "date":
                    Type = DBDataType.DATE;
                    break;
                
                case "timestamp":
                case "timestamp without time zone":
                case "timestamp with time zone":
                case "timestamptz":
                    Type = DBDataType.DATE_TIME;
                    break;

                case "time":
                case "time without time zone":
                case "timez":
                case "time with time zone":
                    Type = DBDataType.TIME;
                    break;

                case "integer":
                case "int":
                case "int4":
                case "smallint":
                case "int2":
                case "serial":
                case "serial4":
                    Type = DBDataType.INTEGER;
                    break;


                case "numeric":
                case "decimal":
                case "real":
                case "double precision":
                    SetNumberType(maxLength, precision, precision_radix, numeric_scale);
                    break;
                
                case "bigint":
                case "int8":
                case "bigserial":
                case "serial8":
                    Type = DBDataType.LONGINTEGER;
                    break;

                case "bytea":
                    Type = DBDataType.BINARY_DATA;
                    break;

                // check for better place for some of these types
                case "box":
                case "cidr":
                case "circle":
                case "inet": // text?
                case "line":
                case "lseg":
                case "macaddr": // text ?
                case "money": // decimal ?
                case "path":
                case "point":
                case "polygon":
                case "tsquery":
                case "tsvector":
                case "txid_snapshot":
                case "xml": // text ?
                case "bit": // boolean ?
                case "bit varying": // text ?
                case "ARRAY":
                case "USER-DEFINED":
                case "interval":
                default:
                    Type = DBDataType.UNKNOWN;
                    break;
            }
        }

        private void SetNumberType(int maxLength, int precision, int precision_radix, int numeric_scale)
        {
            if (numeric_scale <= 0)
            {
                if (precision <= 9)
                {
                    Type = DBDataType.INTEGER;
                    return;
                }

                if (precision <= 18)
                {
                    Type = DBDataType.LONGINTEGER;
                    return;
                }

                if (precision <= 28)
                {
                    Length = precision;
                    Type = DBDataType.DECIMAL;
                    Decimals = numeric_scale; // 0 here
                    return;
                }

                Type = DBDataType.TEXT;
                return;
            }
            else {
                if (precision > 28 || numeric_scale > 8)
                {
                    Type = DBDataType.TEXT;
                    Length = precision + 3; // for the sign, . and optional 0 after 
                    return;
                }
                else {
                    Type = DBDataType.DECIMAL;
                    Length = precision;
                    Decimals = numeric_scale;
                    return;
                }
            }
        }

        public int Decimals
        {
            get;
            set;
        }

        public int Length
        {
            get;
            set;
        }

        public string SqlDataType
        {
            get;
            set;
        }

        public DBDataType Type
        {
            get;
            set;
        }
    }
}
