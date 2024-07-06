using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Entities.Infos;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ECommerceWeb.Repositories.Implementaciones;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(EcommerceDbContext context)
        : base(context)
    {
    }

    public async Task<ICollection<ProductInfo>> ListAsync(string filter)
    {
        return await Context.Set<Product>()
            .Where(p => p.Name.Contains(filter))
            .AsNoTracking()
            .Select(p => new ProductInfo
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                Price = p.Price,
                Category = p.Category.Name,
                Brand = p.Brand.Name,
            })
            .AsQueryable().ToListAsync();


    }

    public async Task<ICollection<ProductInfo>> ListActiveAsync()
    {
        return await Context.Set<Product>()
                .Where(p => p.state)
                .AsNoTracking()
                .Select(x => new ProductInfo
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Brand = x.Brand.Name,
                    BrandId = x.BrandId,
                    Category = x.Category.Name,
                    CategoryId = x.CategoryId, 
                })
                .ToListAsync();
    }
}