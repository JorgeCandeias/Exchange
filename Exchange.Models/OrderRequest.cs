using Orleans.Concurrency;

namespace Exchange.Models;

[Immutable]
public record OrderRequest
{
    public string Symbol { get; init; } = string.Empty;
    public OrderSide Side { get; init; }
    public OrderType Type { get; init; }
    public TimeInForce TimeInForce { get; init; }
    public decimal Quantity { get; init; }
    public decimal Price { get; init; }
    public DateTime Timestamp { get; init; }
    public TimeSpan ReceiveWindow { get; init; }
}