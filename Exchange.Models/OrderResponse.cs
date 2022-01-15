using Orleans.Concurrency;

namespace Exchange.Models;

[Immutable]
public record OrderResponse
{
    public long OrderId { get; init; }
    public string Symbol { get; init; } = string.Empty;
    public OrderSide Side { get; init; }
    public OrderType OrderType { get; init; }
    public TimeInForce TimeInForce { get; init; }
    public decimal Quantity { get; init; }
    public decimal? Price { get; init; }
    public OrderStatus Status { get; init; }
}