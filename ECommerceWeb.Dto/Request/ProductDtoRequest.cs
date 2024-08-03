using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request
{
    public class ProductDtoRequest
    {
        [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
        [StringLength(100, ErrorMessage = Statics.ConsMsnMaxLength)]
        public string Name { get; set; } = default!;
        
        [Range(0, Double.MaxValue, ErrorMessage = Statics.ConsMsnOutOfRange)]
        public float Price { get; set; }
        
        public int CategoryId { get; set; }
        
        public int BrandId { get; set; }

        public string? Base64Image { get; set; } 

        public string? FileName { get; set; } 

        public string? ImageUrl { get; set; }

    }
}
