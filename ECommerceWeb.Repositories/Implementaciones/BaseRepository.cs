using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ECommerceWeb.Repositories.Implementaciones
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly EcommerceDbContext Context;

        protected BaseRepository(EcommerceDbContext context)
        {
            Context = context;
        }

        public virtual async Task<ICollection<TEntity>> ListAsync()
        {
            return await Context
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<TEntity>> ListAsync(Func<TEntity, bool> predicate)
        {
            var collection = await Context.Set<TEntity>()
                .Where(predicate)
                .AsQueryable()
                .AsNoTracking()
                .ToListAsync(); 

            return collection;
        }

        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await Context.Set<TEntity>()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public virtual async Task<int> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity); // this line try to add to the collection of the DbSet
            await Context.SaveChangesAsync(); // this confirm the saving the record

            return entity.Id;
        }

        public async Task UpdateAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           
            // we serching the id in the collection , this id is reciving like a param
            var existentEntity = await FindByIdAsync(id);
            if (existentEntity is not null)
            {
                existentEntity.state = false;
                await Context.SaveChangesAsync();
            }
        }
     
    }
}
