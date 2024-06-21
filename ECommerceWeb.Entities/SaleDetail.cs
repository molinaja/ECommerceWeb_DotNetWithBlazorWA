namespace ECommerceWeb.Entities;

public class SaleDetail : BaseEntity
{
    public int SaleId { get; set; }
    public Sale Sale { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public float UnitPrice { get; set; }

    public int Quantity { get; set; }

    public float Total { get; set; }
}
