﻿CREATE TABLE IF NOT EXISTS `ManagerProfile` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Name`	TEXT NOT NULL,
	`Created`	TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS `DatabaseMigrationScript` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`FileName`	TEXT NOT NULL,
	`MigrationDate`	TEXT NOT NULL
);
