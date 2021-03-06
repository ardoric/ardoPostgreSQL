/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

package outsystems.hubedition.extensibility.data.executionservice;

import java.util.HashMap;
import java.util.Map;

public class DataRow {

	private final Map<String, Object> data = new HashMap<String, Object>();
	private DataRowState state = DataRowState.Detached;
	private String rowError = "";
	
	DataRow() {
	}
	
	public Object get(DataColumn column) {
		return get(column.getName());
	}
	
	public void put(DataColumn column, Object value) {
		put(column.getName(), value);
	}
	
	public Object get(String columnName) {
		return data.get(columnName);
	}
	
	public void put(String columnName, Object value) {
		data.put(columnName, value);
	}
	
	public void acceptChanges() {
		setState(DataRowState.Unchanged);
	}

	public DataRowState getState() {
		return state;
	}
	
	void setState(DataRowState state) {
		this.state = state;
	}
	
	public String getRowError() {
		return rowError;
	}
	
	public void setRowError(String rowError) {
		this.rowError = rowError;
	}
	
}
