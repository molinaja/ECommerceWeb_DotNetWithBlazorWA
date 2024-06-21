using ECommerceWeb.Entities;

namespace ECommerceWeb.Repositories.Interfaces
{
    // here we will do aCRUD (CREATE, READ, UPDATE, DELETE)

    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity // <----- this is a constraint (rule)
    {
        Task<ICollection<TEntity>> ListAsync();

        Task<ICollection<TEntity>> ListAsync(Func<TEntity, bool> predicate);

        Task<TEntity?> FindByIdAsync(int id);

        Task<int> AddAsync(TEntity entity);

        Task UpdateAsync();

        Task DeleteAsync(int id);
    }
}
