# MVCProject

## Description
Simple application for managing financial plans. 

It is a page on which a list of financial plans are displayed.  For each financial plan are displayed:
 
 - `Name`
 - `Person to whom the financial plan belongs`
 - `Id fin. plan`
 - `Date of creation`
 - `Last modification`
 - `Validity/status`
 - `name of the user who made the last modification`

Application also allows adding, deleting and editing the basic data of the financial plan.

## Technologies
Project is created with:

* Visual Studio
*  ASP. NET Core MVC
* Entity Framework Core
* Razor pages
* PostgreSQL
* Bootstrap 5

## Installation

I highly recommend using Visual Studio, which will install most dependencies automatically. 

 - Open `MVCProject.sln` with Visual Studio.
 - Check NuGet Manager if `Npgsql.EntityFrameworkCore.PostgreSQL` and `Npgsql.EntityFrameworkCore.PostgreSQL.Design` are installed. 
 - Create  `appsettings.json` file by `appsettingsEXAMPLE.json` and put connection string `MVCProjectContext` example: ` "MVCProjectContext":"Server=localhost;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;"` for PostgreSQL database.
 - For DataSeed set `"Seed": true` (Fills database with test data, only if it's empty)
 - run `Update-Database` inside `Package Manager Console`
 - run application
 - applicaion runs on `https://localhost:7072/`

## Usage

### /Plans
 - list of financial plans is listed here
 - list can by filtered by Plans Name`/Plans?searchString=PlansName` or id `/Plans?searchString=id`
 - list can by ordered  both ASC and DESC, example: `/Plans?sortOrder=Id` or `?sortOrder=id_desc`
 - filter and order can by combined, example: `/Plans?sortOrder=Date&currentFilter=PlanName`

### /Plans/Create

 - new Plan can by added `/Plans/Create` 

### /Plans/Details/id

 - shows details about Plan `/Plans/Details/1`

### Plans/Edit/id

 - Plan with id can by edited `/Plans/Edit/1`
 - UpdatedAt and CreatedAt cannot by edited.
 
### /Plans/Delete/id
 - Plan with id can by deleted `/Plans/Delete/1`


