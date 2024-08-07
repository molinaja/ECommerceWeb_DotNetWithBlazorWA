namespace ECommerceWeb.Entities.Infos;

public class ProductInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public float Price { get; set; }
    public int CategoryId { get; set; }
    public string Category { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public int BrandId { get; set; }
    public string? UrlImagen { get; set; }
}