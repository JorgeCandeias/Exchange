CREATE TABLE [dbo].[Order]
(
    [SymbolId] INT NOT NULL,
	[OrderId] BIGINT NOT NULL,
    [OrderSideId] INT NOT NULL,
    [OrderTypeId] INT NOT NULL,
    [TimeInForceId] INT NOT NULL,
    [Price] DECIMAL (18, 8) NOT NULL,
    [OriginalQuantity] DECIMAL (18, 8) NOT NULL,
    [ExecutedQuantity] DECIMAL (18, 8) NOT NULL,
    [OrderStatusId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [Updated] DATETIME2(7) NOT NULL,

    CONSTRAINT [PK_Order] PRIMARY KEY ([SymbolId], [OrderId]),
    CONSTRAINT [FK_Order_OrderSide] FOREIGN KEY ([OrderSideId]) REFERENCES [dbo].[OrderSide] ([Id]),
    CONSTRAINT [FK_Order_OrderType] FOREIGN KEY ([OrderTypeId]) REFERENCES [dbo].[OrderType] ([Id]),
    CONSTRAINT [FK_Order_TimeInForce] FOREIGN KEY ([TimeInForceId]) REFERENCES [dbo].[TimeInForce] ([Id]),
    CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus] ([Id]),
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
)
GO