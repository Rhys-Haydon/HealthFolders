CREATE TABLE [dbo].[Ledger]
(
	[EntryID] INT IDENTITY(1,1) NOT NULL,
	[UserID] INT NOT NULL,
	[DatePaid] DATETIME NULL,
	[AmountPaid] MONEY NULL

	PRIMARY KEY CLUSTERED ([EntryID] ASC)

	CONSTRAINT [FK_dbo.Ledger_dbo.User.UserID] 
		FOREIGN KEY ([UserID])
		REFERENCES [dbo].[User] ([UserID]) ON DELETE CASCADE,
)
