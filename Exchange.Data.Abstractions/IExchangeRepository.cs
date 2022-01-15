using Exchange.Models;

namespace Exchange.Data;

public interface IExchangeRepository
{
    Task AddOrderAsync(Order order);
}