CREATE PROCEDURE [dbo].[AddOrder]
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
DECLARE @UserId INT = (SELECT [Id] FROM [dbo].[User] WHERE [Name] = @User);

INSERT INTO [dbo].[Order]
(
    [SymbolId],
    [OrderId],
    [OrderSideId],
    [OrderTypeId],
    [TimeInForceId],
    [Price],
    [OriginalQuantity],
    [ExecutedQuantity],
    [OrderStatusId],
    [UserId],
    [Updated]
)
VALUES
(
	@SymbolId,
    @OrderId,
    @Side,
    @Type,
    @TimeInForce,
    @Price,
    @OriginalQuantity,
    @ExecutedQuantity,
    @Status,
    @UserId,
    @Updated
)

RETURN 0
GO