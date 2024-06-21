using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request
{
    public class ProductDtoRequest
    {
        [Required]
        public string Name { get; set; } = default!;

        public float Price { get; set; }

        public int CategoryId { get; set; }
    }
}
