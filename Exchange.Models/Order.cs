using Orleans.Concurrency;

namespace Exchange.Models;

[Immutable]
public record Order
{
    public string Symbol { get; init; } = string.Empty;
    public long OrderId { get; init; }
    public OrderSide Side { get; init; }
    public OrderType Type { get; init; }
    public TimeInForce TimeInForce { get; init; }
    public decimal Price { get; init; }
    public decimal OriginalQuantity { get; init; }
    public decimal ExecutedQuantity { get; init; }
    public OrderStatus Status { get; init; }
    public string User { get; init; } = string.Empty;
    public DateTime Updated { get; init; }
}