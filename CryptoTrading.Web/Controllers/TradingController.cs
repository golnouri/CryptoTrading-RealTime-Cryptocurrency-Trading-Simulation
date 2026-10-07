using CryptoTrading.Application.Interfaces;
using CryptoTrading.Domain.Entities;
using CryptoTrading.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using CryptoTrading.Web.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace CryptoTrading.Web.Controllers;

public class TradingController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IHubContext<TradingHub> _hubContext;
    public TradingController(
        IOrderService orderService,
        IHubContext<TradingHub> hubContext)
    {
        _orderService = orderService;
        _hubContext = hubContext;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _orderService.GetAllAsync();

        return View(orders);
    }

    [HttpGet]
    public IActionResult Order()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Order(Order order)
    {
        await _orderService.CreateAsync(order);

        await _hubContext.Clients.All.SendAsync(
            "OrderCreated",
            order);
        return RedirectToAction(nameof(Index));
    }
}