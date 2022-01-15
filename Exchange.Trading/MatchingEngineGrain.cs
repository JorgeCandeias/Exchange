using CommunityToolkit.Diagnostics;
using Exchange.Core;
using Orleans;
using System.Buffers;

namespace Exchange.Trading;

internal class MatchingEngineGrain : Grain, IMatchingEngineGrain
{
    private readonly ISystemClock _clock;

    public MatchingEngineGrain(ISystemClock clock)
    {
        _clock = clock;
    }

    public override Task OnActivateAsync()
    {
        _symbol = this.GetPrimaryKeyString();

        Guard.IsEqualTo(_symbol, _symbol.Trim().ToUpperInvariant(), "Symbol");

        return base.OnActivateAsync();
    }

    private readonly OrderBook _book = new();
    private string _symbol = string.Empty;
    private long _lastOrderId;
    private long _lastTradeId;

    public ValueTask<OrderResponse> PlaceOrderAsync(OrderRequest request)
    {
        Validate(request);

        // create a book order from the request
        var order = new Order
        {
            OrderId = ++_lastOrderId,
            Symbol = request.Symbol,
            Type = request.Type,
            TimeInForce = request.TimeInForce,
            Side = request.Side,
            Price = request.Price,
            Status = OrderStatus.New,
            OriginalQuantity = request.Quantity,
            ExecutedQuantity = 0
        };

        // apply the order
        var result = (order.Type, order.Side) switch
        {
            (OrderType.Limit, OrderSide.Buy) => TryExecuteLimitBuyOrder(order)
        };

        return ValueTask.FromResult(result);
    }

    private void Validate(OrderRequest request)
    {
        Guard.IsNotNull(request, nameof(request));
        Guard.IsEqualTo(request.Symbol, _symbol, nameof(request.Symbol));

        if (request.Type == OrderType.Limit)
        {
            Guard.IsGreaterThan(request.Price, 0, nameof(request.Price));
        }
        else if (request.Type == OrderType.Market)
        {
            Guard.IsEqualTo(request.Price, 0, nameof(request.Price));
        }
    }

    private OrderResponse ExecuteLimitBuyOrder(Order order)
    {
        var trades = ArrayPool<Trade>.Shared.Rent(1000);
        var count = 0;

        // scan ask price levels upwards
        foreach (var ask in _book.Asks.TakeWhile(x => x.Key <= order.Price))
        {
            // match the orders in the price level
            foreach (var other in ask.Value.Values)
            {
                var required = order.OriginalQuantity - order.ExecutedQuantity;
                var available = other.OriginalQuantity - other.ExecutedQuantity;
                var take = Math.Min(required, available);

                order.ExecutedQuantity += take;
                other.ExecutedQuantity += take;

                // calculate the price as the midpoint between buyer and seller so we dont favour any
                var price = (order.Price + other.Price) / 2;

                // keep the time consistent between trades
                var now = DateTime.UtcNow;

                // create the buy trade from this match
                var buyTrade = new Trade
                {
                    Symbol = _symbol,
                    TradeId = ++_lastTradeId,
                    OrderId = order.OrderId,
                    Quantity = take,
                    Price = price,
                    Side = TradeSide.Buy,
                    Time = now
                };

                // create the sell trade
                var sellTrade = new Trade
                {
                    Symbol = _symbol,
                    TradeId = ++_lastTradeId,
                    OrderId = other.OrderId,
                    Quantity = take,
                    Price = price,
                    Side = TradeSide.Sell,
                    Time = now
                };

                // hold on to the trades for further processing
                trades[count++] = buyTrade;
                trades[count++] = sellTrade;

                // break if the order was executed completely
                if (order.ExecutedQuantity == order.OriginalQuantity)
                {
                    break;
                }
            }
        }

        // see how far the order was executed
        if (executedQuantity == 0)
        {
            // new order
        }
        else if (executedQuantity == order.ExecutedQuantity)
        {
            // filled order
        }
        else
        {
            // partially filled order
        }
    }
}

internal class MatchingEngineGrainState
{
    public long LastOrderId { get; set; }
    public long LastTradeId { get; set; }
}