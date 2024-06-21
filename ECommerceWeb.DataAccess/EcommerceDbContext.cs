using System.Reflection;
using ECommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.DataAccess;

public class EcommerceDbContext : DbContext
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //We apply a custom configuration of entitys 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
