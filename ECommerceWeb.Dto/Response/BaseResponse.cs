using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Dto.Response
{
    public class BaseResponse
    {
        public string? msnError { get; set; }
        public bool success { get; set; }
    }
}
