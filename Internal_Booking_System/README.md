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

- ASP.NET Core MVC (.NET 9)
- Entity Framework Core
- Microsoft SQL Server / LocalDB
- Bootstrap (via default ASP.NET template)
- Razor Views

---

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) (or SQLite configured in appsettings.json)
- IDE like Visual Studio 

### ⚙️ Setup Instructions (Windows using Command Prompt)

1. **Clone the repository** (or download the ZIP):
   ```cmd
   git clone https://github.com/Ramashiya/Internal_Booking_System.git
   ```

2. **Navigate to the project folder**:
   ```cmd
   cd Internal_Booking_System\Internal_Booking_System
   ```

3. **Restore dependencies**:
   ```cmd
   dotnet restore
   ```

4. **(Optional) Add and apply migrations** (only if not already created):
   ```cmd
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Build the project**:
   ```cmd
   dotnet build
   ```

6. **Run the application**:
   ```cmd
   dotnet run
   ```

7. **Open in browser**:
   
   When the app runs, it will start on a local address such as:
   ```
   http://localhost:5101
   ```
   Open that URL in your browser.
