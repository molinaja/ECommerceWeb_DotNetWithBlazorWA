using ECommerceWeb.Entities;
using ECommerceWeb.Entities.Infos;

namespace ECommerceWeb.Repositories.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<ICollection<ProductInfo>> ListAsync(string filtro);
}