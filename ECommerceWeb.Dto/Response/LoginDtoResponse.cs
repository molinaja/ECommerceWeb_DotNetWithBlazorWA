using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Dto.Response
{
    public class LoginDtoResponse : BaseResponse
    {
        public string Token { get; set; } = default!;
        public string Namme { get; set; } = default!;


    }
}
