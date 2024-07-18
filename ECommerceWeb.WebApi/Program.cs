
using ECommerceWeb.DataAccess;
using ECommerceWeb.Repositories.Implementaciones;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<EcommerceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDb"));
});

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IBrandRepository, BrandRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();




//ASPNETCORE iDENTITY CONFIG
builder.Services.AddIdentity<EcommerseIdentity, IdentityRole>(polices =>
{
    //Password Polices 
    polices.Password.RequireDigit = true;
    polices.Password.RequireLowercase = true;
    polices.Password.RequireUppercase = true;
    polices.Password.RequiredUniqueChars = 2;
    polices.Password.RequireNonAlphanumeric = true;
    polices.Password.RequiredLength = 8;

    //User Polices.
    polices.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<EcommerceDbContext>().AddDefaultTokenProviders();

// Configure the context of security of teh API REST
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] ??
                                           throw new InvalidOperationException("SecretKey of the token is not configured"));

    //parameters for validate the authentification of the token
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//// this is a minimal api example
//app.MapGet("/api/v2/categories", async (ICategoryRepository repository) => Results.Ok(await repository.ListAsync()));

app.MapControllers();
app.MapFallbackToFile("index.html");

await using var scope = app.Services.CreateAsyncScope();
{
    await UserInitializer.CreateInitRolesAndUsers(scope.ServiceProvider);

}

app.Run();
