using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<AttributeProduct> AttributeProducts { get; set; } = new List<AttributeProduct>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    public virtual ICollection<ProductImages> ProductImages { get; set; } = new List<ProductImages>();
}
