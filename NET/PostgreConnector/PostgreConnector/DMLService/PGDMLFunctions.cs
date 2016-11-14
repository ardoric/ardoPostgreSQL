using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.DMLService;

namespace ardo.DatabaseProvider.PostgreSQL.DMLService
{
    public class PGDMLFunctions: BaseDMLFunctions
    {
        public PGDMLFunctions(IDMLService service) : base(service) { }

        #region Math
        public override string Trunc(string n)
        {
            return string.Format("Trunc({0})", n);
        }
        #endregion

        #region Text
        public override string Index(string t, string search)
        {
            // PGSQL String functions are 1-based
            return string.Format("(position({0} in {1})-1)", search, t);
        }

        public override string Length(string t)
        {
            return string.Format("length({0})", t);
        }

        public override string Substr(string t, string start, string length)
        {
            // PGSQL substring is 1-based
            return string.Format("substring({0} from ({1})+1 for {2})", t, start, length);
        }

        public override string Trim(string t)
        {
            return string.Format("trim({0})", t);
        }
        #endregion

        #region Data Conversion
        public override string BooleanToInteger(string b)
        {
            return string.Format("cast({0} as int)", b);
        }

        public override string BooleanToText(string b)
        {
            // uai you no take true and false, mon ?
            return string.Format("(case {0} when TRUE then 'True' ELSE 'False' end) ", b);
        }

        public override string DateTimeToDate(string dt)
        {
            return string.Format("cast({0} as date)", dt) ;
        }

        public override string DateTimeToTime(string dt)
        {
            return string.Format("(timestamp '1900-01-01 00:00:00' + cast({0} as time))", dt);
        }

        public override string DateToText(string d, string dateFormat)
        {
            return string.Format("to_char({0}, '{1}')", d, dateFormat.ToUpper());
        }

        public override string DateTimeToText(string dt, string dateFormat)
        {
            return string.Format("to_char({0}, '{1} HH24:MI:SS')", dt, dateFormat.ToUpper());
        }

        public override string TextToDate(string t, string dateFormat)
        {
            return string.Format("to_date({0},'{1}')", t, dateFormat.ToUpper());
        }

        public override string TextToDateTime(string t, string dateFormat)
        {
            return string.Format("(to_timestamp({0}, '{1} HH24:MI:SS')::timestamp without time zone)", t, dateFormat.ToUpper());
        }

        public override string DecimalToBoolean(string d)
        {
            return string.Format("(case {0} when 0.0 then FALSE else TRUE end)", d);
        }

        public override string DecimalToInteger(string d)
        {
            return string.Format("cast({0} as int)",d); ;
        }

        public override string DecimalToText(string d)
        {
            return string.Format("cast({0} as text)",d); ;
        }

        public override string DecimalToLongInteger(string d)
        {
            return string.Format("cast({0} as bigint)", d);
        }

        public override string IntegerToBoolean(string i)
        {
            return string.Format("cast({0} as boolean)", i);
        }

        public override string IntegerToDecimal(string i)
        {
            return string.Format("cast({0} as decimal)",i);
        }

        public override string IntegerToText(string i)
        {
            return string.Format("cast({0} as text)", i);
        }

        public override string IntegerToLongInteger(string b)
        {
            return string.Format("cast({0} as bigint)", b);
        }

        public override string TextToDecimal(string t)
        {
            return string.Format("cast({0} as decimal)", t);
        }

        public override string TextToInteger(string t)
        {
            return string.Format("cast({0} as integer)",t);
        }

        public override string TextToTime(string t)
        {
            return string.Format("(to_timestamp('1900-01-01 ' || {0}, 'YYYY-MM-DD HH24:MI:SS')::timestamp without time zone)", t);
        }

        public override string TextToLongInteger(string t)
        {
            return string.Format("cast({0} as bigint)", t);
        }

        public override string LongIntegerToInteger(string b)
        {
            return string.Format("cast({0} as int)", b);
        }

        public override string LongIntegerToDecimal(string b)
        {
            return string.Format("cast({0} as decimal)", b);
        }


        public override string LongIntegerToText(string b)
        {
            return string.Format("cast({0} as text)", b);
        }

        public override string TimeToText(string t)
        {
            return string.Format("to_char({0},'HH24:MI:SS')", t);
        }

        // ?? why isn't this the default implementation ??
        public override string IdentifierToInteger(string id)
        {
            return id;
        }

        public override string IdentifierToLongInteger(string id)
        {
            return id;
        }

        public override string IdentifierToText(string id)
        {
            return id;
        }


        #endregion

        // You will find only suffering within the realm of dates.
        // Enter if you dare...
        #region Date & Time
        public override string AddDays(string dt, string n)
        {
            return AddDate(dt, n, "day");
        }

        public override string AddHours(string dt, string n)
        {
            return AddDate(dt, n, "hour");
        }

        public override string AddMinutes(string dt, string n)
        {
            return AddDate(dt, n, "minute");
        }

        public override string AddMonths(string dt, string n)
        {
            return AddDate(dt, n, "month");
        }

        public override string AddSeconds(string dt, string n)
        {
            return AddDate(dt, n, "second");
        }

        public override string AddYears(string dt, string n)
        {
            return AddDate(dt, n, "year");
        }

        private string AddDate(string dt, string n, string unit)
        {
            return string.Format("({0} + (({1}) * interval '1 {2}'))", dt, n, unit);
        }

        // to whoever thought this method was a good idea: .!. (-.-) .!.
        public override string BuildDateTime(string d, string t)
        {
            return string.Format("({0} + ({1} - timestamp '1900-01-01 00:00:00'))", d, t);
        }

        public override string Day(string dt)
        {
            return string.Format("extract(day from {0})", dt);
        }

        public override string DayOfWeek(string dt)
        {
            return string.Format("extract(dow from {0})", dt);
        }

        // diffs from http://www.sqlines.com/postgresql/how-to/datediff
        // COWER MORTALS
        public override string DiffDays(string dt1, string dt2)
        {
            return string.Format("date_part('day', {1} - {0})", dt1, dt2) ;
        }

        public override string DiffHours(string dt1, string dt2)
        {
            return "(" + DiffDays(dt1, dt2) + string.Format(")*24 + date_part('hour', {1} - {0} )", dt1, dt2);
        }

        public override string DiffMinutes(string dt1, string dt2)
        {
            return "(" + DiffHours(dt1, dt2) + string.Format(")*60 + date_part('minute', {1} - {0})", dt1, dt2);
        }

        public override string DiffSeconds(string dt1, string dt2)
        {
            return "(" + DiffMinutes(dt1, dt2) + string.Format(")*60 + date_part('seconds', {1} - {0})", dt1, dt2);
        }

        public override string Hour(string dt)
        {
            return string.Format("extract(hour from {0})", dt);
        }

        public override string Minute(string dt)
        {
            return string.Format("extract(minute from {0})", dt);
        }

        public override string Month(string dt)
        {
            return string.Format("extract(month from {0})", dt);
        }

        public override string NewDate(string y, string m, string d)
        {
            return string.Format("to_date(concat({0},'-',{1},'-',{2}), 'YYYY-MM-DD')",y,m,d);
        }

        public override string NewDateTime(string y, string mo, string d, string h, string m, string s)
        {
            // if I don't cast to timestamp without timezone I get a 00:36:32 offset when using this function.
            // is it possible there's a better way to do this ? please ...
            return string.Format("(to_timestamp(concat({0},'-',{1},'-',{2},' ',{3},':',{4},':',{5}), 'YYYY-MM-DD HH24:MI:SS') :: timestamp without time zone)", y, mo, d, h, m, s);
        }

        public override string NewTime(string h, string m, string s)
        {
            return NewDateTime("1900","01","01", h, m, s);
        }

        public override string NullDate()
        {
            return string.Format("date '1900-01-01'") ;
        }

        public override string Second(string dt)
        {
            return string.Format("extract(second from {0})", dt);
        }

        public override string Year(string dt)
        {
            return string.Format("extract(year from {0})",dt);
        }
        #endregion

    }
}
