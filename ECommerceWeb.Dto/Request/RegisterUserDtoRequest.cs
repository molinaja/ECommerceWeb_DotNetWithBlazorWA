using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Dto.Request
{
    public  class RegisterUserDtoRequest
    {
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string Address { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;

    }
}
