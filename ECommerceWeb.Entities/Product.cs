﻿using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Entities;

public class Product : BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; } = null!;

    public float Price { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}