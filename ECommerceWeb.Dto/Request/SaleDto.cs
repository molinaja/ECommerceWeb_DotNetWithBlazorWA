using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Dto.Request
{
    public record SaleDto(int ClientID, float Total, ICollection<SaleDetailDto> SaleDetail );

    public record SaleDetailDto(int productID, int queantity, float Price, float Total);

}
