WITH Source AS
(
	SELECT * FROM (
	VALUES
		(0, 'None'),
		(1, 'New'),
		(2, 'PartiallyFilled'),
		(3, 'Filled'),
		(4, 'Canceled'),
		(5, 'PendingCancel'),
		(6, 'Rejected'),
		(7, 'Expired')
	)
	AS X ([Id], [Name])
)

MERGE INTO [dbo].[OrderStatus] AS T
USING [Source] AS S
ON S.Id = T.Id
WHEN NOT MATCHED THEN INSERT ([Id], [Name]) VALUES (S.[Id], S.[Name])
WHEN MATCHED AND T.[Name] <> S.[Name] THEN UPDATE SET [Name] = S.[Name];
GO