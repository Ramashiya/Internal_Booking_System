# 📅 Internal Resource Booking System

An internal web application to manage the booking of shared resources such as meeting rooms, laptops, and vehicles. Built with ASP.NET Core MVC and Entity Framework Core.

---

## 🚀 Features

- Add, edit, delete resources (meeting rooms, equipment, etc.)
- Make bookings for a resource with validation to prevent conflicts
- View bookings in a list
- Display upcoming bookings for each resource
- Visual UI using Bootstrap 5

---

## 🛠 Technologies Used

- ASP.NET Core MVC (.NET 6/7/8)
- Entity Framework Core
- Microsoft SQL Server / LocalDB
- Bootstrap (via default ASP.NET template)
- Razor Views

---

## 📁 Project Structure

InternalBookingSystem/
│
├── Controllers/         → BookingsController.cs and HomeController.cs and ResourcesController.cs
|── Data/                → ApplicationDbContext.cs
|── Migration/           → 20250715082139_InitialCleanSetup.cs and ApplicationDbContextModelSnapshot.cs_
├── Models/              → Booking.cs and ErrorViewModel.cs and Resource.cs
├── Views/
│   ├── Bookings/        → Create,  Delete, Details,Edit, Index
│   ├── Resources/       → Index, Details, Edit
│   └── Shared/          → Layout and partials
├
├── wwwroot/             → CSS, JS
├── appsettings.json     → DB config
├── Program.cs
└── README.md
