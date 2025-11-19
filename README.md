# Hair Salon Website - Clean Architecture

[![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet/mvc)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Clean Architecture](https://img.shields.io/badge/Clean%20Architecture-6DB33F?style=for-the-badge)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

## 🌟 Overview

A professionally structured Hair Salon web application built with ASP.NET Core 6.0 MVC, following clean code principles and clean architecture patterns. The application provides comprehensive appointment management, service browsing, and user authentication features.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

### Folder Structure

```
HairSalon/
├── Core/                           # Business logic layer
│   ├── Interfaces/                 # Service and repository interfaces
│   │   ├── IRepository.cs
│   │   ├── IAppointmentRepository.cs
│   │   └── IAppointmentService.cs
│   ├── Services/                   # Business logic implementation
│   │   └── AppointmentService.cs
│   ├── Constants/                  # Application constants
│   │   ├── ErrorMessages.cs
│   │   └── RouteNames.cs
│   └── Exceptions/                 # Custom exceptions
│       ├── NotFoundException.cs
│       └── BusinessException.cs
│
├── Infrastructure/                 # Data access layer
│   └── Repositories/              # Repository implementations
│       ├── Repository.cs
│       └── AppointmentRepository.cs
│
├── Controllers/                    # MVC Controllers
│   ├── HomeController.cs
│   └── AppointmentsController.cs
│
├── Models/                         # Domain models and DTOs
│   ├── Appointment.cs             # Domain entity
│   ├── HairSalonData.cs          # Legacy entity
│   ├── ErrorViewModel.cs
│   ├── DTOs/                      # Data Transfer Objects
│   │   ├── AppointmentDto.cs
│   │   ├── CreateAppointmentDto.cs
│   │   └── UpdateAppointmentDto.cs
│   └── ViewModels/                # View-specific models
│
├── Data/                          # Database context
│   └── HairDbContext.cs
│
├── Configuration/                  # Startup configuration
│   ├── DependencyInjectionConfig.cs
│   ├── DatabaseConfig.cs
│   └── IdentityConfig.cs
│
├── Middleware/                     # Custom middleware
│   └── ExceptionHandlingMiddleware.cs
│
├── Views/                          # Razor views
├── wwwroot/                        # Static files
└── Program.cs                      # Application entry point
```

## ✨ Key Features

### Application Features
- ✅ **Appointment Management** - Full CRUD operations for appointments
- ✅ **Service Listings** - Display salon services and pricing
- ✅ **User Authentication** - ASP.NET Identity integration
- ✅ **Responsive Design** - Mobile-friendly interface
- ✅ **Contact Information** - Easy access to salon details

### Clean Code Features
- ✅ **Repository Pattern** - Generic repository with specific implementations
- ✅ **Service Layer** - Business logic separated from controllers
- ✅ **Dependency Injection** - Loosely coupled components
- ✅ **DTOs** - Proper data transfer objects for API boundaries
- ✅ **Global Exception Handling** - Centralized error management
- ✅ **Constants** - No magic strings or hardcoded values
- ✅ **SOLID Principles** - Single responsibility, dependency inversion
- ✅ **Comprehensive Logging** - ILogger integration throughout
- ✅ **Input Validation** - Data annotations and model validation
- ✅ **Documentation** - XML comments on all public APIs

## 🛠️ Technologies Used

- **Framework:** ASP.NET Core 6.0 MVC
- **Language:** C# 10
- **ORM:** Entity Framework Core 7
- **Database:** SQL Server
- **Authentication:** ASP.NET Core Identity
- **Design Patterns:** Repository, Service Layer, Dependency Injection
- **Architecture:** Clean Architecture, SOLID Principles

## ⚙️ Setup and Installation

### Prerequisites

- .NET 6.0 SDK or later
- SQL Server 2019 or later
- Visual Studio 2022 or VS Code
- SQL Server Management Studio (optional)

### Installation Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/AnishRoy50/HairSalonWebsiteUsingASP.NET_MVC.git
   cd HairSalonWebsiteUsingASP.NET_MVC
   ```

2. **Update Database Connection String:**
   
   Edit `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=HairSalonDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Apply Database Migrations:**
   ```bash
   dotnet ef database update
   ```

4. **Build the Solution:**
   ```bash
   dotnet build
   ```

5. **Run the Application:**
   ```bash
   dotnet run
   ```

   The application will be available at `https://localhost:5001` or `http://localhost:5000`

## 🏛️ Architecture Patterns

### Repository Pattern
```csharp
// Generic repository for common operations
IRepository<T> → Repository<T>

// Specific repository for appointments
IAppointmentRepository → AppointmentRepository
```

### Service Layer
```csharp
// Business logic abstraction
IAppointmentService → AppointmentService
```

### Dependency Injection
All dependencies are registered in `Configuration/DependencyInjectionConfig.cs`:
```csharp
services.AddScoped<IAppointmentRepository, AppointmentRepository>();
services.AddScoped<IAppointmentService, AppointmentService>();
```

### Exception Handling
Global exception handling middleware catches and processes all exceptions:
- `NotFoundException` → 404 Not Found
- `BusinessException` → 400 Bad Request
- `Exception` → 500 Internal Server Error

## 📝 Code Quality Features

### 1. **Separation of Concerns**
- Controllers handle HTTP requests only
- Services contain business logic
- Repositories manage data access

### 2. **Single Responsibility Principle**
- Each class has one reason to change
- Controllers → HTTP handling
- Services → Business rules
- Repositories → Data operations

### 3. **Dependency Inversion**
- Depend on abstractions (interfaces)
- Not on concrete implementations

### 4. **Data Transfer Objects**
- `CreateAppointmentDto` - For creating appointments
- `UpdateAppointmentDto` - For updating appointments
- `AppointmentDto` - For reading appointments

### 5. **Constants**
- `ErrorMessages` - Centralized error messages
- `RouteNames` - Named routes

## 🚀 Usage

### For Developers

**Adding a New Service:**
1. Create interface in `Core/Interfaces/`
2. Create implementation in `Core/Services/`
3. Register in `Configuration/DependencyInjectionConfig.cs`

**Adding a New Entity:**
1. Create entity in `Models/`
2. Create DTOs in `Models/DTOs/`
3. Create repository interface in `Core/Interfaces/`
4. Create repository in `Infrastructure/Repositories/`
5. Add DbSet to `HairDbContext.cs`
6. Create and apply migration

### For Users

- **Browse Services:** Navigate to Services page
- **Book Appointment:** Register/Login → Appointments → Create New
- **Manage Appointments:** View, Edit, or Delete existing appointments
- **Contact:** Access salon contact information

## 🧪 Testing

The clean architecture makes the application highly testable:

```csharp
// Services can be unit tested with mocked repositories
var mockRepo = new Mock<IAppointmentRepository>();
var service = new AppointmentService(mockRepo.Object, logger);

// Controllers can be tested with mocked services
var mockService = new Mock<IAppointmentService>();
var controller = new AppointmentsController(mockService.Object, logger);
```

## 📊 Database Schema

```sql
Appointments
├── Id (PK)
├── FirstName
├── LastName
├── Email
└── Password

AspNetUsers (Identity tables)
AspNetRoles
...
```

## 🔐 Security Features

- Password hashing with ASP.NET Identity
- Anti-forgery tokens on forms
- Authorization attributes on controllers
- SQL injection prevention via EF Core
- XSS prevention via Razor encoding

## 📈 Future Enhancements

- [ ] Add appointment date/time scheduling
- [ ] Implement email notifications
- [ ] Add service selection to appointments
- [ ] Create admin dashboard
- [ ] Add payment integration
- [ ] Implement appointment reminders
- [ ] Add customer reviews and ratings

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License.

## 👤 Author

**Anish Roy**
- GitHub: [@AnishRoy50](https://github.com/AnishRoy50)

---

**Built with Clean Code Principles** 💎✨
