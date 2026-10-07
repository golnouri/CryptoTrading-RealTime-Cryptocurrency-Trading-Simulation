# CryptoTrading

A simple real-time cryptocurrency trading simulation built with **ASP.NET Core MVC**, **Entity Framework Core**, **SQL Server**, and **SignalR**.

This project is mainly created as a practical learning project to demonstrate the basic concepts behind a cryptocurrency exchange, including order management, order books, real-time updates, and trade matching.

## Features

* Create Buy and Sell orders
* Store orders in SQL Server
* Display Buy and Sell order books
* Sort orders by price
* Visualize order quantity with a simple volume bar
* Real-time order updates using SignalR
* Update the order book without refreshing the page
* Basic Trade entity for future trade matching
* Simple layered architecture with Domain, Application, Infrastructure, and Web projects

## Technologies

* .NET 10
* ASP.NET Core MVC
* Entity Framework Core 10
* SQL Server
* SignalR
* Razor Views
* C#
* JavaScript
* Clean Architecture concepts

## Project Structure

```text
CryptoTrading
│
├── CryptoTrading.Domain
│   ├── Entities
│   │   ├── Order.cs
│   │   └── Trade.cs
│   │
│   └── Enums
│       └── OrderType.cs
│
├── CryptoTrading.Application
│   ├── Interfaces
│   │   ├── IOrderService.cs
│   │   ├── ITradeService.cs
│   │   └── IOrderRepository.cs
│   │
│   └── Services
│       ├── OrderService.cs
│       └── TradeService.cs
│
├── CryptoTrading.Infrastructure
│   ├── AppDbContext.cs
│   │
│   └── Repositories
│       └── OrderRepository.cs
│
└── CryptoTrading.Web
    ├── Controllers
    │   └── TradingController.cs
    │
    ├── Hubs
    │   └── TradingHub.cs
    │
    └── Views
        └── Trading
            ├── Index.cshtml
            └── Order.cshtml
```

## Architecture

The project uses a lightweight layered architecture inspired by Clean Architecture:

```text
                ┌──────────────────┐
                │   Web / MVC      │
                └────────┬─────────┘
                         │
                         ▼
                ┌──────────────────┐
                │   Application    │
                │ Services/Interfaces│
                └────────┬─────────┘
                         │
                         ▼
                ┌──────────────────┐
                │  Infrastructure  │
                │ EF Core / SQL    │
                └────────┬─────────┘
                         │
                         ▼
                    SQL Server

                Domain
                  ▲
                  │
          Business Entities
```

The architecture is intentionally kept simple so that the main focus remains on understanding the trading flow and real-time communication.

## Order Flow

When a user creates an order:

```text
User
 │
 ▼
Order View
 │
 ▼
TradingController
 │
 ▼
IOrderService
 │
 ▼
IOrderRepository
 │
 ▼
Entity Framework Core
 │
 ▼
SQL Server
```

After the order is saved, SignalR notifies connected clients:

```text
Order Created
     │
     ▼
SignalR Hub
     │
     ├──────────────► Browser 1
     │
     ├──────────────► Browser 2
     │
     └──────────────► Browser 3
```

The order book is then updated in the browser without a full page refresh.

## Database

The project uses SQL Server with the following main tables:

* `Orders`
* `Trades`

Example `Order`:

```text
Id
Type
Price
Quantity
CreatedAt
```

## Running the Project

### 1. Configure SQL Server

Update the connection string in:

```text
CryptoTrading.Web/appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=CryptoTradingDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 2. Create the Database

Run the following commands from Visual Studio Package Manager Console:

```powershell
Add-Migration InitialCreate
Update-Database
```

For the migration:

```text
Default Project: CryptoTrading.Infrastructure
Startup Project: CryptoTrading.Web
```

### 3. Run the Application

Run the `CryptoTrading.Web` project.

The default route opens the trading page:

```text
/Trading/Index
```

## SignalR

The project uses SignalR to send newly created orders to connected clients.

Hub:

```text
/tradingHub
```

When an order is created, the server sends:

```csharp
await _hubContext.Clients.All.SendAsync(
    "OrderCreated",
    order);
```

The browser receives the event and adds the new order to the order book without refreshing the page.

## Current Status

The project is currently focused on the basic trading infrastructure:

* [x] Buy/Sell order creation
* [x] Order persistence
* [x] Order book
* [x] Order quantity visualization
* [x] SignalR real-time updates
* [x] No-refresh order book updates
* [ ] Order matching engine
* [ ] Trade creation
* [ ] User balances
* [ ] Wallet simulation
* [ ] Transaction history
* [ ] More advanced order types

## Purpose

This project is not intended to be a production cryptocurrency exchange.

It is a small practical project for learning and demonstrating:

* ASP.NET Core MVC
* Clean Architecture concepts
* Dependency Injection
* Repository and Service patterns
* Entity Framework Core
* SQL Server
* SignalR
* Real-time web applications
* Basic trading system concepts

## License

This project is available for educational and demonstration purposes.
