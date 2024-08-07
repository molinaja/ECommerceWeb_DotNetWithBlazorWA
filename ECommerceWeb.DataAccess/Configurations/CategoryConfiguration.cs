using ECommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWeb.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(100);

            // Data seeding
            builder.HasData(new List<Category>
            {
                new() { Id = 1, Name = "Foodies", Description = "Foodies in general", icon="ph:bowl-food" },
                new() { Id = 2, Name = "Bird Shop", Description = "bird Section", icon="ph:bird" },
                new() { Id = 3, Name = "Dog Shop", Description = "Dog Section", icon="ph:dog" },
                new() { Id = 4, Name = "Fish Shop", Description = "Fish Section", icon="ph:fish" },
                new() { Id = 5, Name = "Cat Shop", Description = "Cat Section", icon="ph:cat" },
                new() { Id = 6, Name = "Services", Description = "Services in place", icon="ph:call-bell" },


            });
        }
    }
}
