using ECommerceWeb.Entities;

namespace ECommerceWeb.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<ICollection<Category>> ListMinimalAsync();
    }
}
