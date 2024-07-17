using System.Reflection;
using ECommerceWeb.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ECommerceWeb.DataAccess;

public class EcommerceDbContext : IdentityDbContext<EcommerseIdentity>
{
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Customer> Customers { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Sale> Sales { get; set; } = default!;
    public DbSet<SaleDetail> SaleDetails { get; set; } = default!;
    public DbSet<Brand> Brands { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //We apply a custom configuration of entitys 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //modelBuilder.Entity<Product>().HasQueryFilter(p => p.state == true);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        
        configurationBuilder.Properties<string>().HaveMaxLength(255);

    }

}
