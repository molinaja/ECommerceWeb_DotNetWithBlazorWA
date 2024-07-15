# ECommerceWeb

Example of ecommerce site build in Dot Net 8
- ASP Net Core ---> Blazor web assably in client side
- API Rest for middle logical
- Entity framworl Core for coneccion to database and manage data
- SQL Server 2022 developer for database

For Running in dev mode
0- Install .net 8
0 install EF ==> ( dotnet tool install --global dotnet-ef)  or install local ==> ( dotnet add package Microsoft.EntityFrameworkCore.Tools) 
1- Change connection string 
2- cd in the project folder run in you console ==> dotnet ef database update --project .\ECommerceWeb.DataAccess\ --startup-project .\ECommerceweb.WebApi
3- run in your console dotnet watch run
