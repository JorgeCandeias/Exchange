CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL DEFAULT NEXT VALUE FOR [dbo].[UserSequence],
	[Name] NVARCHAR(100) NOT NULL,

	CONSTRAINT [PK_User] PRIMARY KEY
	(
		[Id]
	),

	CONSTRAINT [UK_User_Name] UNIQUE
	(
		[Name]
	)
)
GO