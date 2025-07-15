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

## Getting Started

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) (or SQLite configured in appsettings.json)
- IDE like Visual Studio 

### Setup & Run

1.Clone the repository:
   ```bash
   
   git clone https://github.com/Ramashiya/Internal_Booking_System.git
   cd Internal_Booking_System
   ```
2.Restore dependencies:
  ```bash
   dotnet restore
```

3.Apply database migrations:
   ```bash
   dotnet ef database update
```
4.Run the application:
  ```bash
dotnet run
```
5.Open your browser and navigate to:
https://localhost:7011

