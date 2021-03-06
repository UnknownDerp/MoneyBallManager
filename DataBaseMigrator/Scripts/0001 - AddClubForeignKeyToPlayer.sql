﻿
CREATE TABLE IF NOT EXISTS 'Player" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Name`	TEXT NOT NULL,
	`ClubId`	INTEGER NOT NULL,
	`Height`	INTEGER NOT NULL,
	`Weight`	INTEGER NOT NULL,
	`Position`	INTEGER NOT NULL,
	`PlayerRole`	INTEGER NOT NULL,
	CONSTRAINT 'fk_club_player' FOREIGN KEY(`ClubId`) REFERENCES `Club`(`Id`)
);

