using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Entities;

public class Sale : BaseEntity
{
    [StringLength(20)]
    public string BillNumber { get; set; } = null!;

    public DateTime SaleDate { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    public float TotalSale { get; set; }
    
    public ICollection<SaleDetail> SaleDetail { get; set; } = new List<SaleDetail>();
}
