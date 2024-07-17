using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.DataAccess
{
    public class EcommerseIdentity  : IdentityUser
    {
        public string Name { get; set; } = default!;

        public DateOnly BirthDate { get; set; }

        public string Address { get; set; } = default!;

    }
}
