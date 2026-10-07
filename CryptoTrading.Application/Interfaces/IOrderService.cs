using CryptoTrading.Domain.Entities;

namespace CryptoTrading.Application.Interfaces;

public interface IOrderService
{
    Task CreateAsync(Order order);

    Task<List<Order>> GetAllAsync();
}