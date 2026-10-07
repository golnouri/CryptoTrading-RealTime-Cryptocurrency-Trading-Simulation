using CryptoTrading.Application.Interfaces;
using CryptoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoTrading.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }
}