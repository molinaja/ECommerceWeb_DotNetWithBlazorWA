using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request
{
    public class ProductDtoRequest
    {
        [Required(ErrorMessage = Constant.ConsMsnRequeriedField)]
        [StringLength(100, ErrorMessage = Constant.ConsMsnMaxLength)]
        public string Name { get; set; } = default!;
        [Range(0, Double.MaxValue, ErrorMessage = Constant.ConsMsnOutOfRange)]
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
