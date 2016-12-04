package ardo.postgresql.execution;

import java.sql.Connection;

import outsystems.hubedition.databaseabstractionlayer.adoadapters.ADOCommand;
import outsystems.hubedition.databaseabstractionlayer.adoadapters.ADOParameter;

public class PGADOCommand extends ADOCommand {
	public PGADOCommand() {
		super(null);
	}
	
	public PGADOCommand(Connection conn) {
		super(conn);
	}
	
	@Override
	public ADOParameter createParameter() {
		return new PGADOParameter();
	}
}