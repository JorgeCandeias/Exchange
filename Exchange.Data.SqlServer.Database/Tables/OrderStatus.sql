CREATE TABLE [dbo].[OrderStatus]
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,

	CONSTRAINT [PK_OrderStatus] PRIMARY KEY
	(
		[Id]
	),

	CONSTRAINT [UK_OrderStatus_Name] UNIQUE
	(
		[Name]
	)
)
GO