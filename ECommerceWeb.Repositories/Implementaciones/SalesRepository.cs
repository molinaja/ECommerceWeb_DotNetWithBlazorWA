using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Repositories.Implementaciones
{
    public class SalesRepository(EcommerceDbContext context) : BaseRepository<Sale>(context), ISalesRepository
    {

        public override async Task<int> AddAsync(Sale entity)
        {
            var quantityRecords = await Context.Set<Sale>().CountAsync();

            entity.BillNumber = $"F001-{quantityRecords+1:000000}";

            await Context.AddAsync(entity);
            return entity.Id;
        }

        public async Task CreateTransactionAsync()
        {
           await Context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
        }


        public async Task ConfirmTransactionAsync()
        {
            await Context.Database.CommitTransactionAsync();
            await Context.SaveChangesAsync();
        }

        public async Task ResetTransactionAsync()
        {
            await Context.Database.RollbackTransactionAsync();
        }

        public async Task<DashBoard> ShowDashBoard()
        {
            var query = Context.Database.SqlQueryRaw<DashBoard>("exec uspDashboard");
            return await query.FirstAsync();
        }
    }
}
