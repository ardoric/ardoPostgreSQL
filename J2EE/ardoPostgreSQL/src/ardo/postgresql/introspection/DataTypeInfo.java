package ardo.postgresql.introspection;

import outsystems.hubedition.extensibility.data.DBDataType;
import outsystems.hubedition.extensibility.data.databaseobjects.BaseDataTypeInfo;
import outsystems.hubedition.extensibility.data.databaseobjects.IDataTypeInfo;

public class DataTypeInfo extends BaseDataTypeInfo implements IDataTypeInfo {
	public DataTypeInfo(DBDataType type, String sqlDataType, int length, int decimals) {
		super(type, sqlDataType, length, decimals);
	}
	
	private static final String[] textTypes = new String[] {
		"character", "character varying", "varchar", "char", "uuid", "text"
	};
	
	private static final String[] booleanTypes = new String[] {
		"boolean", "bool"
	};
	
	private static final String[] dateTypes = new String[] {
		"date"
	};
	
	private static final String[] dateTimeTypes = new String[] {
		"timestamp", "timestamp without time zone", "timestamp with time zone", "timestamptz"
	};
	
	private static final String[] timeTypes = new String[] {
		"time", "time without time zone", "timez", "time with time zone"
	};
	
	private static final String[] intTypes = new String[] {
		"integer", "int", "int4", "smallint", "int2", "serial", "serial4"
	};
	
	private static final String[] decimalTypes = new String[] {
		"numeric", "decimal", "real", "double precision"
	};
	
	private static final String[] binaryDataTypes = new String[] {
		"bytea"
	};
	
	private static final String[] longIntTypes = new String[] {
			"bigint", "int8", "bigserial", "serial8"
	};
	
	public static IDataTypeInfo create(String data_type, int maxLength, int precision, int precision_radix, int numeric_scale) {
		
		String dt = data_type.toLowerCase();
		
		if (isIn(dt, textTypes)) {
			return new DataTypeInfo(DBDataType.TEXT, data_type, maxLength, 0);
		}
		
		if (isIn(dt, booleanTypes)) {
			return new DataTypeInfo(DBDataType.BOOLEAN, data_type, 0, 0);
		}
		
		if (isIn(dt, dateTypes)) {
			return new DataTypeInfo(DBDataType.DATE, data_type, 0, 0);
		}
		
		if (isIn(dt, dateTimeTypes)) {
			return new DataTypeInfo(DBDataType.DATE_TIME, data_type, 0 , 0);
		}
		
		if (isIn(dt, timeTypes)) {
			return new DataTypeInfo(DBDataType.TIME, data_type, 0 , 0);
		}
		
		if (isIn(dt, intTypes)) {
			return new DataTypeInfo(DBDataType.INTEGER, data_type, 0, 0);
		}
		
		if (isIn(dt, longIntTypes)) {
			return new DataTypeInfo(DBDataType.LONGINTEGER, data_type, 0, 0);
		}
		
		if (isIn(dt, decimalTypes)) {
			if (numeric_scale <= 0) {
				if (precision <= 9)
					return new DataTypeInfo(DBDataType.INTEGER, data_type, 0, 0);
				if (precision <= 18)
					return new DataTypeInfo(DBDataType.LONGINTEGER, data_type, 0, 0);
				if (precision <= 28)
					return new DataTypeInfo(DBDataType.DECIMAL, data_type, precision, numeric_scale);
				return new DataTypeInfo(DBDataType.TEXT, data_type, precision, 0);
			} else {
				if (precision > 28 || numeric_scale > 8) {
					new DataTypeInfo(DBDataType.TEXT, data_type, precision + 1, 0);
				} else {
					return new DataTypeInfo(DBDataType.DECIMAL, data_type, precision, numeric_scale);
				}
			}
		}
		
		if (isIn(dt, binaryDataTypes)) {
			return new DataTypeInfo(DBDataType.BINARY_DATA, data_type, 0, 0);
		}
		
		return new DataTypeInfo(DBDataType.UNKNOWN, data_type, 0, 0);
		
	}
	
	private static boolean isIn(String str, String[] values) {
		for (String s : values)
			if (str.equals(s))
				return true;
		return false;
	}
}
