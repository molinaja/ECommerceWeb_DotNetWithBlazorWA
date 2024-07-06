using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Dto.Request
{
    public class BrandDtoRequest
    {
        [Required(ErrorMessage = Constant.ConsMsnRequeriedField)]
        [StringLength(50, ErrorMessage = Constant.ConsMsnMaxLength)]
        public string Name { get; set; } = default!;
    }
}
