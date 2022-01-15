WITH Source AS
(
	SELECT * FROM (
	VALUES
		(0, 'None'),
		(1, 'Limit'),
		(2, 'Market')
	)
	AS X ([Id], [Name])
)

MERGE INTO [dbo].[OrderType] AS T
USING [Source] AS S
ON S.Id = T.Id
WHEN NOT MATCHED THEN INSERT ([Id], [Name]) VALUES (S.[Id], S.[Name])
WHEN MATCHED AND T.[Name] <> S.[Name] THEN UPDATE SET [Name] = S.[Name];
GO