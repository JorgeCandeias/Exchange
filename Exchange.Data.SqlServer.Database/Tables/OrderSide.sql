CREATE TABLE [dbo].[OrderSide]
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,

	CONSTRAINT [PK_OrderSide] PRIMARY KEY
	(
		[Id]
	),

	CONSTRAINT [UK_OrderSide_Name] UNIQUE
	(
		[Name]
	)
)
GO