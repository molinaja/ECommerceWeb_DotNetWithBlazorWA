using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Repositories.Interfaces
{
    public interface ISalesRepository : IBaseRepository<Sale>
    {
        Task CreateTransactionAsync();

        Task ConfirmTransactionAsync();

        Task ResetTransactionAsync();

        Task<DashBoard> ShowDashBoard();

    }
}
