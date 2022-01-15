CREATE PROCEDURE [dbo].[GetSymbols]
AS

SELECT
	[Id],
	[Name]
FROM
	[dbo].[Symbol]

RETURN 0
GO