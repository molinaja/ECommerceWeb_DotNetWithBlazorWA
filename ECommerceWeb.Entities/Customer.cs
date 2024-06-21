using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Entities;

public class Customer : BaseEntity
{

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [StringLength(500)]
    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }
}
