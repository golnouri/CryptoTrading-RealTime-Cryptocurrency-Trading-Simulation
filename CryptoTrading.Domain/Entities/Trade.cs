using CryptoTrading.Domain.Enums;

namespace CryptoTrading.Domain.Entities;

public class Trade
{
    public int Id { get; set; }

    public OrderType Type { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}