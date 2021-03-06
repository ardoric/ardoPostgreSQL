/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

package outsystems.hubedition.extensibility.data.platform;

import java.text.*;
import java.util.*;
import linqbridge.linq.*;
import outsystems.hubedition.extensibility.data.*;
import outsystems.hubedition.extensibility.data.platform.queryprovider.*;
import outsystems.hubedition.util.*;
import outsystems.hubedition.util.delegates.*;
import outsystems.runtimecommon.*;
import outsystems.runtimecommon.log.*;
import java.math.BigDecimal;
import linqbridge.linq.LinqMethods;
import outsystems.hubedition.extensibility.data.IDatabaseProvider;
import outsystems.hubedition.extensibility.data.platform.queryprovider.DatabaseProviderSpecificImplementationFor;
import outsystems.runtimecommon.CollectionsExtensions;
import outsystems.runtimecommon.DatabaseProviderKey;
import outsystems.runtimecommon.log.EventLogger;


public class DatabaseProviderExtensions {
    public static final TypeInformation<DatabaseProviderExtensions> TypeInfo = TypeInformation.get(DatabaseProviderExtensions.class);
    
    /**
	 *	Creates an instance of a type that inherits from BaseType, from a list of possible  Types (specificTypes). Matching is performed using the attribute DatabaseProviderSpecificImplementationFor.
	 *	@param	provider	Database provider used to filter the specificTypes
	 *	@param	specificTypes	Specific types inherit from BaseType
	 *	@return	An object that inherits from BaseType
	 *	@param <BaseType> Class related to the base type.
@param methodTypeArg_BaseType Information regarding the method's type argument.
	 */
    public static <BaseType> BaseType getProviderSpecificType(final TypeInformation<BaseType> methodTypeArg_BaseType, IDatabaseProvider provider, Class<?> ... specificTypes) {
        try {
            String providerKey = provider.getKey().serialize();
            
            for (Class<?> specificType : specificTypes) {
                DatabaseProviderSpecificImplementationFor attribute = (DatabaseProviderSpecificImplementationFor) LinqMethods.firstOrDefault(TypeInformation.Object, Arrays.asList(ClassUtils.getCustomAttributes(specificType, DatabaseProviderSpecificImplementationFor.class, false)));
                
                if (attribute != null && attribute.key().equals(providerKey))
                {
                    return methodTypeArg_BaseType.cast(specificType.newInstance());
                }
            }
        }catch (Exception exceptionToHandle) {
            exceptionToHandle = WrappedException.unwrapExceptionIfNeeded(exceptionToHandle);
            
            {
                Exception e = (Exception)exceptionToHandle;
                String message = "Error creating instance of '" + methodTypeArg_BaseType.getTypeClass().getSimpleName() + "' from types: " + CollectionsExtensions.strCat(LinqMethods.select(Arrays.asList(specificTypes), (Class<?> t) -> {
    return t.getSimpleName();
}), " | ") + ":\n" + e;
                
                EventLogger.writeError(message);
            }
        }
        
        return null;
    }
    
    /**
	 *	Creates an instance of a type that inherits from BaseType, from a list of possible  Types (specificTypes). If none is found, returns an instance of BaseType.
	 *	@param	provider	Database provider used to filter the specificTypes
	 *	@param	specificTypes	Specific types that inherit from BaseType
	 *	@return	An object that is or inherits from BaseType
	 *	@param <BaseType> Class related to the base type.
@param methodTypeArg_BaseType Information regarding the method's type argument.
	 */
    public static <BaseType> BaseType getProviderSpecificOrBaseType(final TypeInformation<BaseType> methodTypeArg_BaseType, IDatabaseProvider provider, Class<?> ... specificTypes) {
        
        BaseType type = DatabaseProviderExtensions.<BaseType>getProviderSpecificType(methodTypeArg_BaseType, provider, specificTypes);
        return (type != null? type : methodTypeArg_BaseType.newInstance());
    }
}
