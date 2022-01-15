CREATE PROCEDURE [dbo].[UpdateOrder]
	@Symbol NVARCHAR(100),
    @OrderId BIGINT,
    @Side INT,
    @Type INT,
    @TimeInForce INT,
    @Price DECIMAL (18, 8),
    @OriginalQuantity DECIMAL (18, 8),
    @ExecutedQuantity DECIMAL (18, 8),
    @Status INT,
    @User NVARCHAR(100),
    @Updated DATETIME2(7)
AS

DECLARE @SymbolId INT = (SELECT [Id] FROM [dbo].[Symbol] WHERE [Name] = @Symbol);

UPDATE [dbo].[Order]
SET
    [ExecutedQuantity] = @ExecutedQuantity,
    [OrderStatusId] = @Status,
    [Updated] = @Updated
WHERE
    [SymbolId] = @SymbolId
    AND [OrderId] = @OrderId
;

RETURN 0
GO