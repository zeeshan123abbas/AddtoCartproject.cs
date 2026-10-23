# 🛒 ShopCart MVC: E-Commerce with ASP.NET Core

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core%20MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

An online store built with **ASP.NET Core MVC** and **Entity Framework Core**: browse products, add them to a cart, and place orders.

## ✨ Features

- 🛍️ **Product catalogue** (`ProductController`)
- 🛒 **Add to cart**, update and remove items (`CartController`)
- 📦 **Orders** with order items
- 🗄️ Database built with **EF Core code-first migrations**
- 🧰 Session helpers for the cart (`Helpers/`)

## 🧱 Architecture

```
Controllers/   HomeController · ProductController · CartController
Models/        Product · CartItem · Order · OrderItem · DBModel (DbContext)
Views/         Razor views
Migrations/    EF Core migrations
Helpers/       Session and cart helpers
wwwroot/       CSS, JS and images
```

## ▶️ Getting started

```bash
git clone https://github.com/zeeshan123abbas/AddtoCartproject.cs.git
cd AddtoCartproject.cs/AddtoCartproject.cs
# set your connection string in appsettings.json
dotnet ef database update
dotnet run
```

## 🎓 What you will learn

The MVC pattern, EF Core models and migrations, session-based carts, and the order flow of a real store.

---

👨‍🏫 **Zeeshan Abbas**, Senior Faculty & Manager Academics, Aptech North Nazimabad
