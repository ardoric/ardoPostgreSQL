/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

package outsystems.hubedition.extensibility.data.introspectionservice;

import java.text.*;
import java.util.*;
import outsystems.hubedition.extensibility.data.*;
import outsystems.hubedition.util.*;
import outsystems.hubedition.util.delegates.*;
import java.math.BigDecimal;

@FunctionalInterface
public interface IsTableSourceToIgnore_Lambda {
    TypeInformation<IsTableSourceToIgnore_Lambda> TypeInfo = TypeInformation.get(IsTableSourceToIgnore_Lambda.class);
    boolean executeImplLambda(String tableName) throws Exception;
    default boolean execute(String tableName){
        try {
            return executeImplLambda(tableName);
        } catch (Exception e) {
            return WrappedException.<Boolean>wrapExceptionIfNeeded(e);
        }
    }
}
