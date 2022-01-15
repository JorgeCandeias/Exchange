CREATE TABLE [dbo].[OrderType]
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,

	CONSTRAINT [PK_OrderType] PRIMARY KEY
	(
		[Id]
	),

	CONSTRAINT [UK_OrderType_Name] UNIQUE
	(
		[Name]
	)
)
GO