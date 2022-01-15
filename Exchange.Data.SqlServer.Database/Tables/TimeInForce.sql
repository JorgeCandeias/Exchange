CREATE TABLE [dbo].[TimeInForce]
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,

	CONSTRAINT [PK_TimeInForce] PRIMARY KEY
	(
		[Id]
	),

	CONSTRAINT [UK_TimeInForce_Name] UNIQUE
	(
		[Name]
	)
)
GO