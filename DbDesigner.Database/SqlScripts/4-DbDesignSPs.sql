CREATE PROCEDURE DbDesignsByUserId (pAppUserId bigint(20))
BEGIN

SELECT   
 `DbDesignId`, `AppUserId`, `DatabaseName`, `DatabaseType`,`DbDesignJson`
FROM DbDesign WHERE `AppUserId` = pAppUserId;

END;

CREATE PROCEDURE DbDesignSelect (pDbDesignId bigint(20))
BEGIN

SELECT   
 `DbDesignId`, `AppUserId`, `DatabaseName`, `DatabaseType`,`DbDesignJson`
FROM DbDesign WHERE `DbDesignId` = pDbDesignId;

END;

CREATE PROCEDURE DbDesignInsert
(
  pDbDesignId bigint(20),
  pAppUserId bigint(20),
  pDatabaseName varchar(355),
  pDatabaseType varchar(355),
  pDbDesignJson longtext
)
BEGIN

INSERT INTO DbDesign
( `DbDesignId`, `AppUserId`, `DatabaseName`, `DatabaseType`,`DbDesignJson`)
VALUES
( pDbDesignId, pAppUserId, pDatabaseName, pDatabaseType, pDbDesignJson);

END;

CREATE PROCEDURE TargetUpdate
(
  pDbDesignId bigint(20),
  pDatabaseName varchar(355),
  pDatabaseType varchar(355),
  pDbDesignJson longtext
)
BEGIN

UPDATE DbDesign
SET  `DatabaseName`= pDatabaseName,`DatabaseType` = pDatabaseType,`DbDesignJson` = pDbDesignJson
WHERE `DbDesignId` = pDbDesignId;

END;
