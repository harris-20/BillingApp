# BillingApp

A simple ASP.NET Core MVC billing application that allows users to add, edit, delete, and view products and generate an invoice report.

Features
Add products
Edit products
Delete products
Display all products
Calculate subtotal
Calculate Ontario tax (14%)
Calculate total price
Generate a printable invoice report
Save the invoice report as PDF using the browser's Print / Save as PDF option
Store invoice data in SQL Server
Technologies Used
C#
ASP.NET Core MVC
Entity Framework Core
SQL Server / LocalDB
Razor Views
HTML / CSS
Bootstrap
Project Structure
BillingApp
│
├── Controllers
│   └── HomeController.cs
│
├── Models
│   ├── Invoice.cs
│   └── InvoiceDbContext.cs
│
├── Views
│   ├── Home
│   │   ├── Invoice.cshtml
│   │   ├── InvoiceReport.cshtml
│   │   └── CreateEditProduct.cshtml
│   │
│   └── Shared
│
├── Migrations
│
├── wwwroot
│
├── Program.cs
└── appsettings.json
Database

The application uses Entity Framework Core to communicate with SQL Server.

The connection is configured in appsettings.json.

(localdb)\MSSQLLocalDB
        ↓
BillingAppDb
        ↓
Invoice table

The Invoice table stores:

Id
ProductName
Price

The Price property is stored as decimal(18,2).

Invoice Calculation

The application calculates:

Subtotal = Sum of all product prices

Ontario Tax = Subtotal × 14%

Total = Subtotal + Ontario Tax
Running the Project

Install the required NuGet packages:

Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

Create the database migration:

Add-Migration InitialCreate

Apply the migration:

Update-Database

Run the application from Visual Studio.

Invoice Report

Click Generate Invoice from the Invoice page.

The application opens the invoice report containing:

Product details
Product prices
Subtotal
Ontario Tax
Total

The report can then be printed or saved as a PDF using the browser's Print → Save as PDF option.

Main MVC Flow
User
 ↓
Razor View
 ↓
HomeController
 ↓
InvoiceDbContext
 ↓
Entity Framework Core
 ↓
SQL Server
 ↓
Invoice Table

For invoice generation:

SQL Server
 ↓
EF Core
 ↓
HomeController
 ↓
InvoiceReport.cshtml
 ↓
HTML Report
 ↓
Print / Save as PDF
