# OfflineTicketingSystem
A simple offline ticket management system built with .NET 8, EF Core, and SQLite.
سیستم مدیریت تیکت آفلاین با استفاده از .NET 8، EF Core و SQLite ساخته شده است.

📖 Overview / معرفی پروژه

این پروژه به کاربران و مدیران امکان مدیریت تیکت‌ها را می‌دهد:

کاربران (Employee) می‌توانند تیکت ایجاد کنند و وضعیت تیکت‌های خود را مشاهده کنند.

مدیران (Admin) می‌توانند تمامی تیکت‌ها را مشاهده، بروزرسانی و حذف کنند.

احراز هویت با JWT انجام می‌شود.

🌐 Tech Stack / تکنولوژی‌ها
Layer	Technology
Backend	.NET 8, C# 12
ORM	Entity Framework Core
Database	SQLite
Mapping	AutoMapper
Mediation	MediatR
Validation	FluentValidation
API Docs	Swagger


🛠️ Features / امکانات

JWT Authentication & Authorization

Role-based access: Employee & Admin

CRUD operations for tickets

Data validation using FluentValidation

Swagger UI for easy API testing


⚙️ Installation / نصب

Clone the repository / کلون کردن مخزن:

git clone https://github.com/rq70/OfflineTicketingSystem.git
cd OfflineTicketingSystem


Restore packages & create the database / نصب پکیج‌ها و ساخت پایگاه داده:

dotnet restore
dotnet ef database update


Run the project / اجرای پروژه:

dotnet run --project OfflineTicketingSystem.Api


Open Swagger / باز کردن Swagger:

https://localhost:7243/swagger

🔑 Authentication / احراز هویت

Endpoint:

POST /api/Auth/Login


Example request:

{
  "Email": "employee@test.com",
  "Password": "Employee123!"
}


Example response:

{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}


Use the token in Authorization header:

Authorization: Bearer {your_token}

📄 API Endpoints / مسیرهای API
Method	Route	Role	Description
POST	/api/Auth/Login	Any	Login and receive JWT
POST	/api/Tickets	Employee	Create a ticket
GET	/api/Tickets/my	Employee	Get my tickets
GET	/api/Tickets	Admin	Get all tickets
PUT	/api/Tickets/{id}	Admin	Update a ticket
DELETE	/api/Tickets/{id}	Admin	Delete a ticket
Example: Create Ticket / ایجاد تیکت

Request:

{
  "Title": "Printer Issue",
  "Description": "Printer is not working",
  "Priority": 2,
  "AssignedToUserId": "6c46493a-416e-4e58-8d8f-387a126e6299"
}


Response:

"ticket-id-guid"

Example: Get My Tickets / مشاهده تیکت‌های خود

Request Header:

Authorization: Bearer {your_token}


Response:

[
  {
    "Id": "f7b2d5e1-0c4b-4b9a-a6f2-2c77e4f5d123",
    "Title": "Printer Issue",
    "Description": "Printer is not working",
    "Status": 0,
    "Priority": 2,
    "CreatedByUserId": "6c46493a-416e-4e58-8d8f-387a126e6299",
    "AssignedToUserId": "6c46493a-416e-4e58-8d8f-387a126e6299",
    "CreatedAt": "2025-12-24T07:00:00Z",
    "UpdatedAt": "2025-12-24T07:00:00Z"
  }
]

💡 Notes / نکات مهم

هنگام ایجاد یا بروزرسانی تیکت، AssignedToUserId باید معتبر باشد.

تمام خطاها توسط Middleware مدیریت می‌شوند و JSON بازگردانده می‌شود.

نقش‌ها:

Employee: ایجاد و مشاهده تیکت‌های خود

Admin: مدیریت کامل تیکت‌ها
