using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Entities;

public class Category : BaseEntity
{

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string? Description { get; set; }

    public string? icon { get; set; }

}
