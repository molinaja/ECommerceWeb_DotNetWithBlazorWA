using ECommerceWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Repositories.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {

        Task<Customer?> GetCustomerByEmail(string email);
    }
}
