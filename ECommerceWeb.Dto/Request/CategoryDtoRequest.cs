namespace ECommerceWeb.Dto.Request;

public class CategoryDtoRequest
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}