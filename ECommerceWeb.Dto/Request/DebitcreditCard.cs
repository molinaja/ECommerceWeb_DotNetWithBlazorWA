using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerceWeb.Dto.Request
{
    public class DebitcreditCard
    {
        public string? name { get; set; }

        public string? number { get; set; }

        public string? ExpireDate { get; set; }

        public string? Cvv { get; set; }

    }
}
