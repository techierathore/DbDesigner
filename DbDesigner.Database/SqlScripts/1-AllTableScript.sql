CREATE TABLE `AppUser` (
  `AppUserId` bigint(20) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(255) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `EmailID` varchar(355) NOT NULL,
  `PasswordHash` varchar(35) NOT NULL,
  `MobileNo` varchar(35) NOT NULL,
  `IsVerified` bit(1) DEFAULT NULL,
  `UserRole` varchar(55) NOT NULL,
  `ProfilePicId` bigint(20) DEFAULT NULL,
	PRIMARY KEY (`AppUserId`)
);

CREATE TABLE `UserLogin` (
	`LoginId` bigint NOT NULL AUTO_INCREMENT,
	`UserId` bigint NOT NULL,
	`LoginDate` DATETIME NOT NULL,
	`LoginToken` mediumtext NOT NULL,
	`TokenStatus` varchar(55) NOT NULL,
	`ExipryDate` DATETIME NOT NULL,
	`IssueDate` DATETIME NOT NULL,
	PRIMARY KEY (`LoginId`)
);

CREATE TABLE `DbDesign` (
	`DbDesignId` bigint NOT NULL AUTO_INCREMENT,
	`AppUserId` bigint NOT NULL,
	`DatabaseName` varchar(355) NOT NULL,
	`DatabaseType` varchar(355) NOT NULL,
	`DbDesignJson` longtext,
	PRIMARY KEY (`DbDesignId`)
);



