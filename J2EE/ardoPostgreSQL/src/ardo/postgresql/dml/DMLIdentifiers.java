/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

package ardo.postgresql.dml;

import outsystems.hubedition.extensibility.data.dmlservice.BaseDMLIdentifiers;
import outsystems.hubedition.extensibility.data.dmlservice.IDMLService;
import outsystems.hubedition.util.TypeInformation;

/**
 *	Implementation of the IDMLIdentifiers interface that defines methods that help build DML Identifiers for columns, tables, and others.
 */
public class DMLIdentifiers extends BaseDMLIdentifiers {
    public static final TypeInformation<DMLIdentifiers> TypeInfo = TypeInformation.get(DMLIdentifiers.class);
    
    /**
	 *	Initializes a new instance of the DMLIdentifiers class.
	 *	@param	dmlService	The DML service.
	 */
    
    public DMLIdentifiers(IDMLService dmlService){
        super(dmlService);
    }
    
    /**
	 *	Gets the maximum length of a simple (not compound) identifier. This value should be the minimum valid length for any kind of identifier (e.g. table name, parameter name)
	 */
    public int getMaxLength() {
    	// http://www.postgresql.org/docs/9.1/static/sql-syntax-lexical.html
        return 63;
    }
}
