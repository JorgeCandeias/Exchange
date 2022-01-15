CREATE PROCEDURE [dbo].[AddSymbol]
	@Id INT,
	@Name NVARCHAR(100)
AS

INSERT INTO [dbo].[Symbol]
(
	[Id],
	[Name]
)
VALUES
(
	@Id,
	@Name
);

RETURN 0
GO