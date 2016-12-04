package ardo.postgresql.execution;

import java.sql.PreparedStatement;
import java.sql.SQLException;

import outsystems.hubedition.databaseabstractionlayer.adoadapters.ADOParameter;

public class PGADOParameter extends ADOParameter {
	@Override
	public void setObjectValue(PreparedStatement pstmt, int index) throws SQLException {
		// override just the behavior we want to override
		if ((objectValue instanceof String) && ((String) objectValue).length() > 4000) {
			pstmt.setString(index, (String) objectValue);
			return ;
		}
		super.setObjectValue(pstmt, index);
	}
}
