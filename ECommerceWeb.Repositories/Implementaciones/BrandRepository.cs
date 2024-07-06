using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Repositories.Implementaciones
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(EcommerceDbContext context)
           : base(context)
        {
        }
        public async Task<ICollection<Brand>> ListActiveAsync()
        {
            return await Context.Set<Brand>()
                .Where(p => p.state)
                .AsNoTracking()
                .Select(x => new Brand
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .AsQueryable()
                .ToListAsync();
        }
    }
}
