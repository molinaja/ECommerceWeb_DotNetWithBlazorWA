# ECommerceWeb

##Example of ecommerce SPA site build in Dot Net 8

- ASP Net Core ---> Blazor web assably in client side
- API Rest for middle logical
- Entity framework Core for coneccion to database and manage data
- SQL Server 2022 developer for database

###For Running in dev mode

1. Install .net 8
2.  install EF ==> ( dotnet tool install --global dotnet-ef)  or install local ==> ( dotnet add package Microsoft.EntityFrameworkCore.Tools) 
3. Change connection string 
4. cd in the project folder run in you console ==> dotnet ef database update --project .\ECommerceWeb.DataAccess\ --startup-project .\ECommerceweb.WebApi
5. run in your console dotnet watch run
6. Ensure the folder wwwroot was created in  webapi, for upload images of products
7. dotnet watch run --project ECommerceWeb.WebApi![image](https://github.com/user-attachments/assets/e16431c8-3514-455e-9df5-565c773b3173)

