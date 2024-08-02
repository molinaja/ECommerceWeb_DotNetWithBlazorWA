using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using ECommerceWeb.Dto;

namespace ECommerceWeb.DataAccess
{
    public static class UserInitializer
    {
        public static async Task CreateInitRolesAndUsers(IServiceProvider serviceProvider)
        {
            //repositories
            UserManager<EcommerseIdentity> userManager = serviceProvider.GetRequiredService<UserManager<EcommerseIdentity>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //create role
            IdentityRole AdminRole = new IdentityRole(Statics.AdministratorRole);
            IdentityRole ClientRole = new IdentityRole(Statics.ClientRole);

            await roleManager.CreateAsync(AdminRole);
            await roleManager.CreateAsync(ClientRole);

            //Admin User
            var adminUser = new EcommerseIdentity
            {
                Name = "Administrator",
                BirthDate = DateOnly.Parse("1990-01-01"),
                Address = "Av. Siempre viva 123",
                UserName = "admin",
                Email = "admin@molinaja.com",
                EmailConfirmed = true
            };

            IdentityResult result = await userManager.CreateAsync(adminUser, "AdminUSer123@");
            if (result.Succeeded) 
            {
                await userManager.AddToRoleAsync(adminUser, Statics.AdministratorRole);
            }

        }

    }

}
