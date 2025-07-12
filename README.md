
## 📋 Mô tả
API quản lý đơn hàng và sản phẩm được xây dựng bằng **ASP.NET Core 8.0** với Entity Framework Core 8.0, theo kiến trúc Clean Architecture.

## 🛠️ Công nghệ sử dụng
- **.NET 8.0**
- **ASP.NET Core Web API 8.0**
- **Entity Framework Core 8.0**
- **SQL Server**
- **Swagger/OpenAPI**
- **Repository Pattern**
- **Unit of Work Pattern**

## 📁 Cấu trúc Project
```
SenVang/
├── WebAPI/                 # API Layer
│   ├── Controllers/        # API Controllers
│   ├── Startup.cs         # Cấu hình ứng dụng
│   ├── Program.cs         # Entry point
│   └── appsettings.json   # Cấu hình database
├── Services/              # Business Logic Layer
│   ├── Customers/         # Customer services
│   ├── Products/          # Product services
│   ├── Orders/            # Order services
│   └── OrderItems/        # OrderItem services
├── DataAccessEF/          # Data Access Layer
│   ├── Interfaces/        # Repository interfaces
│   └── UnitOfWork/        # Unit of Work implementation
└── Domain/                # Domain Layer
    ├── Entities/          # Domain entities
    ├── DTOs/              # Data Transfer Objects
    └── TrainingContext.cs # DbContext
```

## 🚀 Hướng dẫn cài đặt và chạy

### 1. Yêu cầu hệ thống
- **.NET 8.0 SDK** (bắt buộc)
- **SQL Server** (LocalDB, Express, hoặc Full)
- **Visual Studio 2022** hoặc **VS Code**
- **Windows 10/11** hoặc **macOS/Linux**

### 2. Kiểm tra .NET version
```bash
# Kiểm tra phiên bản .NET đã cài
dotnet --version

# Kết quả mong đợi: 8.0.x
```

### 3. Clone và cài đặt
```bash
# Clone repository
git clone <repository-url>
cd SenVang

# Restore packages
dotnet restore

# Build solution
dotnet build
```

### 4. Cấu hình Database

#### 4.1. Cập nhật Connection String
Mở file `WebAPI/appsettings.json` và cập nhật connection string:

```json
{
  "SqlConnectionString": "Server=YOUR_SERVER;Database=SenVangDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

**Ví dụ cho SQL Server LocalDB:**
```json
{
  "SqlConnectionString": "Server=(localdb)\\mssqllocaldb;Database=SenVangDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

**Ví dụ cho SQL Server Express:**
```json
{
  "SqlConnectionString": "Server=DESKTOP-XXXXX\\SQLEXPRESS;Database=SenVangDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

#### 4.2. Tạo Database và Migration
```bash
# Di chuyển vào thư mục WebAPI
cd WebAPI

# Tạo migration
dotnet ef migrations add Init

# Update database
dotnet ef database update
```

### 5. Chạy ứng dụng
```bash
# Chạy từ thư mục WebAPI
dotnet run

# Hoặc chạy từ thư mục gốc
dotnet run --project WebAPI
```

### 6. Truy cập API
- **Swagger UI:** `https://localhost:5001/swagger`
- **API Base URL:** `https://localhost:5001/api`

## 📚 API Endpoints

### Customer API
| Method | Endpoint | Mô tả |
|--------|----------|-------|
| GET | `/api/customers` | Lấy danh sách khách hàng |
| GET | `/api/customers/{id}` | Lấy chi tiết khách hàng |
| POST | `/api/customers` | Thêm khách hàng mới |
| PUT | `/api/customers/{id}` | Cập nhật khách hàng |
| DELETE | `/api/customers/{id}` | Xóa khách hàng |

### Product API
| Method | Endpoint | Mô tả |
|--------|----------|-------|
| GET | `/api/products` | Lấy danh sách sản phẩm |
| GET | `/api/products/{id}` | Lấy chi tiết sản phẩm |
| POST | `/api/products` | Thêm sản phẩm mới |
| PUT | `/api/products/{id}` | Cập nhật sản phẩm |
| DELETE | `/api/products/{id}` | Xóa sản phẩm |

### Order API
| Method | Endpoint | Mô tả |
|--------|----------|-------|
| GET | `/api/orders` | Lấy danh sách đơn hàng |
| GET | `/api/orders/{id}` | Lấy chi tiết đơn hàng |
| POST | `/api/orders` | Tạo đơn hàng mới |

## 📝 Ví dụ sử dụng API

### 1. Thêm Customer
```bash
POST /api/customers
Content-Type: application/json

{
  "name": "Nguyen Van An",
  "email": "nguyenvanan@email.com",
  "phoneNumber": "0901234567"
}
```

### 2. Thêm Product
```bash
POST /api/products
Content-Type: application/json

{
  "name": "Laptop Dell Inspiron",
  "price": 15000000
}
```

### 3. Tạo Order
```bash
POST /api/orders
Content-Type: application/json

{
  "customerId": 1,
  "orderDate": "2024-01-15T10:30:00",
  "items": [
    {
      "productId": 1,
      "quantity": 2,
      "unitPrice": 15000000
    }
  ]
}
```

### 4. Filter Orders
```bash
GET /api/orders?fromDate=2024-01-01&toDate=2024-12-31&customerId=1
```

## 🔧 Cấu trúc DTO

### CustomerRequest
```json
{
  "name": "string",
  "email": "string",
  "phoneNumber": "string"
}
```

### ProductRequest
```json
{
  "name": "string",
  "price": 0.00
}
```

### OrderRequest
```json
{
  "customerId": 1,
  "orderDate": "2024-01-01T00:00:00",
  "items": [
    {
      "productId": 1,
      "quantity": 1,
      "unitPrice": 100.00
    }
  ]
}
```
## 🐛 Troubleshooting

### Lỗi thường gặp

#### 1. Lỗi .NET Version
```
The specified framework 'Microsoft.NETCore.App', version '5.0.0' was not found.
```
**Giải pháp:** Cài đặt .NET 8.0 SDK từ [Microsoft .NET Downloads](https://dotnet.microsoft.com/download/dotnet/8.0)

#### 2. Lỗi Connection String
```
Value cannot be null. (Parameter 'connectionString')
```
**Giải pháp:** Kiểm tra lại connection string trong `appsettings.json`

#### 3. Lỗi Migration
```
Build failed
```
**Giải pháp:** 
- Đảm bảo đã restore packages: `dotnet restore`
- Build lại solution: `dotnet build`
- Kiểm tra EF Core 8.0 packages

#### 4. Lỗi 401 Unauthorized
**Giải pháp:** Kiểm tra cấu hình authentication trong `Startup.cs`

#### 5. Lỗi Database
```
Cannot open database
```
**Giải pháp:**
- Kiểm tra SQL Server đang chạy
- Kiểm tra quyền truy cập database
- Chạy lại migration: `dotnet ef database update`

## 📦 Package Versions (.NET 8)

### Core Packages
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
```



## 📄 License
MIT License 
