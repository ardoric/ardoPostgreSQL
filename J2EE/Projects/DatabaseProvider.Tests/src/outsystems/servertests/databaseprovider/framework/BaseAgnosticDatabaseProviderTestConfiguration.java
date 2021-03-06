/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

package outsystems.servertests.databaseprovider.framework;

import java.io.*;
import java.text.*;
import java.util.*;
import linqbridge.linq.*;
import outsystems.hubedition.extensibility.data.*;
import outsystems.hubedition.extensibility.data.platform.*;
import outsystems.hubedition.util.*;
import outsystems.hubedition.util.delegates.*;
import outsystems.runtimecommon.*;
import java.math.BigDecimal;
import linqbridge.linq.LinqMethods;
import outsystems.hubedition.extensibility.data.DatabasePluginProvider;


public abstract class BaseAgnosticDatabaseProviderTestConfiguration<TDatabaseProvider extends IDatabaseProvider, TDatabaseProviderTestCase extends IDatabaseProviderTestCase<TDatabaseProvider>> extends BaseDatabaseProviderTestConfiguration<TDatabaseProvider, TDatabaseProviderTestCase> implements IGenericObject {
    
    protected boolean isServerOnly()
    {
        return false;
    }
    
    private static final <TDatabaseProvider extends IDatabaseProvider, TDatabaseProviderTestCase extends IDatabaseProviderTestCase<TDatabaseProvider>> DatabasePluginProvider<TDatabaseProvider> getServerPluginProviderField(final TypeInformation<TDatabaseProvider> classTypeArg_TDatabaseProvider, final TypeInformation<TDatabaseProviderTestCase> classTypeArg_TDatabaseProviderTestCase) {
        BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler<TDatabaseProvider, TDatabaseProviderTestCase> staticsHandler = staticInitBaseAgnosticDatabaseProviderTestConfiguration(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
        return staticsHandler.serverPluginProviderField;
    }
    
    private static final <TDatabaseProvider extends IDatabaseProvider, TDatabaseProviderTestCase extends IDatabaseProviderTestCase<TDatabaseProvider>> void setServerPluginProviderField(final TypeInformation<TDatabaseProvider> classTypeArg_TDatabaseProvider, final TypeInformation<TDatabaseProviderTestCase> classTypeArg_TDatabaseProviderTestCase, DatabasePluginProvider<TDatabaseProvider> value) {
        BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler<TDatabaseProvider, TDatabaseProviderTestCase> staticsHandler = staticInitBaseAgnosticDatabaseProviderTestConfiguration(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
        staticsHandler.serverPluginProviderField = value;
    }
    
    private static final <TDatabaseProvider extends IDatabaseProvider, TDatabaseProviderTestCase extends IDatabaseProviderTestCase<TDatabaseProvider>> DatabasePluginProvider<TDatabaseProvider> getInternalPluginProviderField(final TypeInformation<TDatabaseProvider> classTypeArg_TDatabaseProvider, final TypeInformation<TDatabaseProviderTestCase> classTypeArg_TDatabaseProviderTestCase) {
        BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler<TDatabaseProvider, TDatabaseProviderTestCase> staticsHandler = staticInitBaseAgnosticDatabaseProviderTestConfiguration(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
        return staticsHandler.internalPluginProviderField;
    }
    
    private static final <TDatabaseProvider extends IDatabaseProvider, TDatabaseProviderTestCase extends IDatabaseProviderTestCase<TDatabaseProvider>> void setInternalPluginProviderField(final TypeInformation<TDatabaseProvider> classTypeArg_TDatabaseProvider, final TypeInformation<TDatabaseProviderTestCase> classTypeArg_TDatabaseProviderTestCase, DatabasePluginProvider<TDatabaseProvider> value) {
        BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler<TDatabaseProvider, TDatabaseProviderTestCase> staticsHandler = staticInitBaseAgnosticDatabaseProviderTestConfiguration(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
        staticsHandler.internalPluginProviderField = value;
    }
    
    
    private Iterable<TDatabaseProvider> providersToTest;
    protected Iterable<TDatabaseProvider> getProvidersToTest()
    {
        if (providersToTest == null)
        {
            Iterable<TDatabaseProvider> ptt = getServerPluginProviderField(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase).getImplementations();
            if (!isServerOnly())
            {
                ptt = LinqMethods.union(ptt, getInternalPluginProviderField(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase).getImplementations());
            }
            providersToTest = LinqMethods.toList(ptt);
        }
        return providersToTest;
    }
    
    private static <TDatabaseProvider extends IDatabaseProvider, TDatabaseProviderTestCase extends IDatabaseProviderTestCase<TDatabaseProvider>> File getBaseDirectory(final TypeInformation<TDatabaseProvider> classTypeArg_TDatabaseProvider, final TypeInformation<TDatabaseProviderTestCase> classTypeArg_TDatabaseProviderTestCase)
    {
        
                        String jarPath = ClassUtils.getCannonicalJarFilePath(BaseAgnosticDatabaseProviderTestConfiguration.class);
                        File jarFile = new File(jarPath);
        
                        // Load relative to the installation directory
                        return jarFile.getParentFile();
                    
    }
    
    // Plugins are loaded relative to AppBase so that they work on the developer machine and on regressions
    
    // Not 100% correct since they should have a different interface, but can't reference it in this project
    
    public BaseAgnosticDatabaseProviderTestConfiguration(final TypeInformation<TDatabaseProvider> classTypeArg_TDatabaseProvider, final TypeInformation<TDatabaseProviderTestCase> classTypeArg_TDatabaseProviderTestCase) {
        super(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
        instanceInitBaseAgnosticDatabaseProviderTestConfiguration(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
    }
    
    public TypeInformation<?> getTypeInformation() {
        return TypeInformation.<BaseAgnosticDatabaseProviderTestConfiguration<TDatabaseProvider, TDatabaseProviderTestCase>>get(BaseAgnosticDatabaseProviderTestConfiguration.class, classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
    }
    
    private final void instanceInitBaseAgnosticDatabaseProviderTestConfiguration(final TypeInformation<TDatabaseProvider> classTypeArg_TDatabaseProvider, final TypeInformation<TDatabaseProviderTestCase> classTypeArg_TDatabaseProviderTestCase) {
        providersToTest = null;
    }
    protected static <TDatabaseProvider extends IDatabaseProvider, TDatabaseProviderTestCase extends IDatabaseProviderTestCase<TDatabaseProvider>> BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler<TDatabaseProvider, TDatabaseProviderTestCase> staticInitBaseAgnosticDatabaseProviderTestConfiguration(final TypeInformation<TDatabaseProvider> classTypeArg_TDatabaseProvider, final TypeInformation<TDatabaseProviderTestCase> classTypeArg_TDatabaseProviderTestCase) {
        staticInitBaseDatabaseProviderTestConfiguration(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
        @SuppressWarnings("unchecked")
        BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler<TDatabaseProvider, TDatabaseProviderTestCase> result = StaticsHandlerFactory.get(BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler.class, BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler.staticsHandlerMap, classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
        
        if (!result.isInitialized()) {
            synchronized (result) {
                if (result.isNew()) {
                    result.startInitialization();
                    try {
                        result.staticInit(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase);
                    } finally {
                        result.finishInitialization();
                    }
                }
            }
        }
        
        return result;
    }
    private static final class BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler<TDatabaseProvider extends IDatabaseProvider, TDatabaseProviderTestCase extends IDatabaseProviderTestCase<TDatabaseProvider>> extends StaticsHandler {
        @SuppressWarnings("rawtypes")
        public static final java.util.Map<TypeArguments, BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler> staticsHandlerMap = new java.util.HashMap<TypeArguments, BaseAgnosticDatabaseProviderTestConfigurationStaticsHandler>();
        public DatabasePluginProvider<TDatabaseProvider> serverPluginProviderField;
        public DatabasePluginProvider<TDatabaseProvider> internalPluginProviderField;
        public void staticInit(final TypeInformation<TDatabaseProvider> classTypeArg_TDatabaseProvider, final TypeInformation<TDatabaseProviderTestCase> classTypeArg_TDatabaseProviderTestCase) {
            serverPluginProviderField = null;
            internalPluginProviderField = null;
            File serverPluginsDir = new File(FileUtils.combine(FileUtils.combine(getBaseDirectory(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase).getAbsolutePath(), "plugins"), "database"));
            setServerPluginProviderField(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase, new DatabasePluginProvider<TDatabaseProvider>(classTypeArg_TDatabaseProvider, serverPluginsDir) );
            File internalPluginsDir = new File(FileUtils.combine(serverPluginsDir.getAbsolutePath(), "internal"));
            setInternalPluginProviderField(classTypeArg_TDatabaseProvider, classTypeArg_TDatabaseProviderTestCase, new DatabasePluginProvider<TDatabaseProvider>(classTypeArg_TDatabaseProvider, internalPluginsDir) );
        }
    }
    
}
