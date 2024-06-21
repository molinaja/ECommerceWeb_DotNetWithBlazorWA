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

    public async Task<ICollection<ProductInfo>> ListAsync(string filtro)
    {
        var coleccion = Context.Database.SqlQueryRaw<ProductInfo>("EXEC uspListarProductos {0}", filtro);

        return await coleccion.ToListAsync();
    }
}