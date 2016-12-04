/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

package outsystems.javaservertests.databaseprovider.configurationservice;

import java.text.*;
import java.util.*;
import org.junit.*;
import outsystems.hubedition.extensibility.data.configurationservice.*;
import outsystems.hubedition.util.*;
import outsystems.hubedition.util.delegates.*;
import outsystems.servertests.databaseprovider.framework.*;
import java.math.BigDecimal;
import outsystems.hubedition.extensibility.data.configurationservice.AdvancedConfiguration;
import outsystems.hubedition.extensibility.data.configurationservice.BaseDatabaseConfiguration;
import outsystems.hubedition.extensibility.data.configurationservice.IRuntimeDatabaseConfiguration;
import outsystems.hubedition.extensibility.data.IDatabaseProvider;
import outsystems.junit.framework.DashboardTestFixture;
import outsystems.junit.framework.JUnitTestAdapter;
import outsystems.junit.framework.TestDetails;
import outsystems.servertests.databaseprovider.framework.DashboardTest;
import outsystems.testscommon.AssertUtils;



@org.junit.runner.RunWith(outsystems.junit.logic.DashboardTestRunner.class)
@DashboardTestFixture(testKind=DashboardTest.DashboardTestKind)
public class BaseDatabaseConfigurationTests extends DashboardTest {
    public static final TypeInformation<BaseDatabaseConfigurationTests> TypeInfo = TypeInformation.get(BaseDatabaseConfigurationTests.class);
    
    public static class MockDatabaseConfiguration extends BaseDatabaseConfiguration {
        public static final TypeInformation<MockDatabaseConfiguration> TypeInfo = TypeInformation.get(MockDatabaseConfiguration.class);
        
        public IDatabaseProvider getDatabaseProvider()
        {
            throw new UnsupportedOperationException();
        }
        
        public String getDatabaseIdentifier()
        {
            throw new UnsupportedOperationException();
        }
        
        protected String assembleBasicConnectionString() {
            return "jdbc://fakeconnectionstring";
        }
        
        protected String assembleAdvancedConnectionString() {
            throw new UnsupportedOperationException();
        }
        
        private AdvancedConfiguration advancedConfiguration = new AdvancedConfiguration(null, null, null);
        
        public AdvancedConfiguration getAdvancedConfiguration()
        {
            return advancedConfiguration;
        }
        
        public void setAdvancedConfiguration(AdvancedConfiguration value)
        {
            advancedConfiguration = value;
        }
        
        public IRuntimeDatabaseConfiguration getRuntimeDatabaseConfiguration()
        {
            throw new UnsupportedOperationException();
        }
    }
    
    @Test
    @TestDetails(Description="Checks if the Connection String Override property overrides the original connection string value", CreatedBy="rcn", Feature="Database Abstraction Layer", TestIssue="613292")
    public final void checkIfConnectionStringOverrideOverridesConnectionString() {
        
        MockDatabaseConfiguration mockConfig = new MockDatabaseConfiguration();
        
        Assert.assertEquals((Object) ("jdbc://fakeconnectionstring"), (Object) (mockConfig.getConnectionString()));
        
        mockConfig.setConnectionStringOverride( "overriding" );
        
        Assert.assertEquals("Didn't override existing connection string.", (Object) ("overriding"), (Object) (mockConfig.getConnectionString()));
    }
    
}