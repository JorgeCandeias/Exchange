CREATE PROCEDURE [dbo].[GetSymbol]
	@Id INT
AS

SELECT
	[Id],
	[Name]
FROM
	[dbo].[Symbol]
WHERE
	[Id] = @Id

RETURN 0
GO