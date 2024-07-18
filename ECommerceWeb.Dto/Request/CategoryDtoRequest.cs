using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request;

public class CategoryDtoRequest
{
    [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
    [StringLength(100, ErrorMessage = Statics.ConsMsnMaxLength)]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = Statics.ConsMsnRequeriedField)]
    [StringLength(100, ErrorMessage = Statics.ConsMsnMaxLength)]
    public string? Description { get; set; } 
}