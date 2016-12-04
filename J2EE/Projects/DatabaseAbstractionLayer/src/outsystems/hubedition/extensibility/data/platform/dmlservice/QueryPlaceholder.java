/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

package outsystems.hubedition.extensibility.data.platform.dmlservice;

import java.text.*;
import java.util.*;
import outsystems.hubedition.extensibility.data.*;
import outsystems.hubedition.extensibility.data.platform.*;
import outsystems.hubedition.util.*;
import outsystems.hubedition.util.delegates.*;
import java.math.BigDecimal;
import java.util.Map;

/**
 *	Represents the possible placeholders to use in the PlatformDMLService.SetVariableFromQuery method. {BeforeStatement} SELECT {AfterSelectKeyword} column, ..., column{BeforeFromKeyword} FROM EntityWHERE conditions{AfterStatement}
 */
public enum QueryPlaceholder implements IEnum {
    BeforeStatement,
    AfterSelectKeyword,
    BeforeFromKeyword,
    AfterStatement;
    
    public static final TypeInformation<QueryPlaceholder> TypeInfo = TypeInformation.get(QueryPlaceholder.class);
    public int getIntValue() {
        return ordinal();
    }
    
    public static String[] names() {
        return EnumUtils.getNames(values());
    }
    
    public static QueryPlaceholder getDefaultValue() {
        return BeforeStatement;
    }
    
    private static Map<Integer, QueryPlaceholder> intToEnum;
    private static Map<Integer, QueryPlaceholder> getIntToEnum() {
        if (intToEnum == null) {
            intToEnum = EnumUtils.getIntToEnumValueMap(values());
        }
        return intToEnum;
    }
    
    private static Map<String, QueryPlaceholder> lowerCaseNameToEnum;
    private static Map<String, QueryPlaceholder> getLowerCaseNameToEnum() {
        if (lowerCaseNameToEnum == null) {
            lowerCaseNameToEnum = EnumUtils.getNameToEnumValueMap(values(), /*lowerCase*/true);
        }
        return lowerCaseNameToEnum;
    }
    
    private static Map<String, QueryPlaceholder> nameToEnum;
    private static Map<String, QueryPlaceholder> getNameToEnum() {
        if (nameToEnum == null) {
            nameToEnum = EnumUtils.getNameToEnumValueMap(values(), /*lowerCase*/false);
        }
        return nameToEnum;
    }
    
    public static QueryPlaceholder valueOf(int value) {
        QueryPlaceholder result = getIntToEnum().get(value);
        if (result == null) {
            throw new IllegalArgumentException("No enum const class QueryPlaceholder with int value " + value);
        }
        return result;
    }
    
    
    public static QueryPlaceholder valueOf(String value, boolean ignoreCase) {
        if (!ignoreCase) {
            return valueOf(value);
        }
        QueryPlaceholder result = getLowerCaseNameToEnum().get(value.toLowerCase());
        if (result == null) {
            throw new IllegalArgumentException("No enum const class QueryPlaceholder." + value);
        }
        return result;
    }
    
    
    public static boolean isDefined(String value) {
        return getNameToEnum().containsKey(value);
    }
    
    public static boolean isDefined(int value) {
        return getIntToEnum().containsKey(value);
    }
}