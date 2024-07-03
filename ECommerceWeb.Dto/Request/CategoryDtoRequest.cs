using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request;

public class CategoryDtoRequest
{
    [Required(ErrorMessage ="The field {0} is required!")]
    [StringLength(50, ErrorMessage = "The max length off field {0} is {1}")]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = "The field {0} is required!")]
    [StringLength(100, ErrorMessage = "The max length off field {0} is {1}")]
    public string? Description { get; set; }
}