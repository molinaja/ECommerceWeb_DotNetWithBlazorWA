using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public bool state { get; set; }

    protected BaseEntity()
    {
        state = true;
    }
}