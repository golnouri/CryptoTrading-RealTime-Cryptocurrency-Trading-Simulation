using CryptoTrading.Domain.Entities;

namespace CryptoTrading.Application.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order);

    Task<List<Order>> GetAllAsync();
}