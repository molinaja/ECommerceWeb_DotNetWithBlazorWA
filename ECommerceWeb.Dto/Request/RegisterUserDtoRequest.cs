using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Dto.Request
{
    public  class RegisterUserDtoRequest
    {
        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        public string Name { get; set; } = default!;
        
        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        public string LastName { get; set; } = default!;

        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        public string Address { get; set; } = default!;

        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]

        public string Password { get; set; } = default!;

        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        [Compare(nameof( Password))]
        public string ConfirmPassword { get; set; } = default!;

    }
}
