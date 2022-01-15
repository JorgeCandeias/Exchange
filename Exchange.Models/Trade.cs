using Orleans.Concurrency;

namespace Exchange.Models;

[Immutable]
public record Trade
{
    public string Symbol { get; init; } = string.Empty;
    public long TradeId { get; init; }
    public long OrderId { get; init; }
    public TradeSide Side { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public DateTime Time { get; init; }
}