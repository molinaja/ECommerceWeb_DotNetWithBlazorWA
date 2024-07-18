using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Dto.Request
{
    public class LoginDtoRequest
    {
        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        public string UserName { get; set; } = default!;
        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        public string Password { get; set; } = default!;

    }
}
