using Exchange.Core;

namespace Exchange.Trading;

internal class OrderBook
{
    public SortedDictionary<decimal, SortedDictionary<long, Order>> Asks { get; } = new();
    public SortedDictionary<decimal, SortedDictionary<long, Order>> Bids { get; } = new(ReverseComparer<decimal>.Default);
}