﻿CREATE TABLE [dbo].[User]
(
	[UserID] INT IDENTITY (1,1) NOT NULL,
	[LastName] NVARCHAR (50) NULL,
	[FirstName] NVARCHAR(50) NULL,

	PRIMARY KEY CLUSTERED ([UserID] ASC) 
)
