using ECommerceWeb.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Dto
{
    public class ShoppingCartDto
    {
        public ProductDtoResponse Product { get; set; } = default!;

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Total { get; set; }




    }
}
