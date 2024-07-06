using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request;

public class CategoryDtoRequest
{
    [Required(ErrorMessage = Constant.ConsMsnRequeriedField)]
    [StringLength(100, ErrorMessage = Constant.ConsMsnMaxLength)]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = Constant.ConsMsnRequeriedField)]
    [StringLength(100, ErrorMessage =  Constant.ConsMsnMaxLength)]
    public string? Description { get; set; } 
}