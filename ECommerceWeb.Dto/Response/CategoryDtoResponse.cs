namespace ECommerceWeb.Dto.Response;

public class CategoryDtoResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}