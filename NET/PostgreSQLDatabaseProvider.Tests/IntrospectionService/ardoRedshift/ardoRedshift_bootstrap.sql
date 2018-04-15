CREATE TABLE "IntrospecTbl%Machine%" (ID int IDENTITY(1,1) NOT NULL, DBTEXT varchar(255) NOT NULL, DBINTEGER int, DBLONGINTEGER bigint, DBDECIMAL decimal(37, 8), DBBOOLEAN boolean, DBDATETIME timestamp, DBBINARYDATA text, CONSTRAINT PK_IntrospectionTestTable PRIMARY KEY (ID));

CREATE VIEW "IntrospecView%Machine%" AS SELECT * FROM "IntrospecTbl%Machine%";

CREATE TABLE "SELECT%Machine%" (TEXTID varchar(10) NOT NULL, VAL int, CONSTRAINT PK_Select%Machine% PRIMARY KEY (TEXTID));

CREATE VIEW "FROM%Machine%" AS SELECT * FROM "SELECT%Machine%";

CREATE TABLE "ForeignKeysTable%Machine%" (ID int, INTROSPECTIONID int, SELECTID varchar(10) NOT NULL);
ALTER TABLE "ForeignKeysTable%Machine%" ADD CONSTRAINT FK_FKT_IspecTbl%Machine% FOREIGN KEY (INTROSPECTIONID) REFERENCES "IntrospecTbl%Machine%"(ID);
ALTER TABLE "ForeignKeysTable%Machine%" ADD CONSTRAINT FK_FKT_Select%Machine% FOREIGN KEY (SELECTID) REFERENCES "SELECT%Machine%"(TEXTID);