using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ECommerceWeb.Repositories.Implementaciones
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EcommerceDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Category>> ListActiveAsync()
        {
            return await Context.Set<Category>()
                .Where(p => p.state)
                .AsNoTracking()
                .Select(x => new Category
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    icon = x.icon,
                   
                })
                .ToListAsync();
        }
    }
}
