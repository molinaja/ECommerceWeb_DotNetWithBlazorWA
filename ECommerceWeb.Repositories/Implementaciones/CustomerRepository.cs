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
    public class CustomerRepository(EcommerceDbContext context) : BaseRepository<Customer>(context), ICustomerRepository
    {
        //in c# 12 the constructor is not necessary its implicit in the class declaration
        //public CustomerRepository(EcommerceDbContext context)
        //  : base(context)
        //{

        //}

        public async Task<Customer?> GetCustomerByEmail(string email)
        {
            return await Context.Set<Customer>().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
