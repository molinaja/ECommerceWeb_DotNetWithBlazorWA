using ECommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWeb.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Data seeding
            builder.HasData(new List<Category>
            {
                new() { Id = 1, Name = "Celulares", Description = "Celulares de Alta gama" },
                new() { Id = 2, Name = "Televisores", Description = "Electrodomesticos para el hogar" },
                new() { Id = 3, Name = "Computadoras Portátiles", Description = "Solo Laptops" },
            });
        }
    }
}
