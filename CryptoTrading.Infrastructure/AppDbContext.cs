using CryptoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoTrading.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Trade> Trades { get; set; }
}