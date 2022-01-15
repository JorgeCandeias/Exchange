CREATE PROCEDURE [dbo].[UpdateSymbol]
	@Id INT,
	@Name NVARCHAR(100)
AS

UPDATE [dbo].[Symbol]
SET
	[Name] = @Name
WHERE
	[Id] = @Id
;

RETURN 0
GO