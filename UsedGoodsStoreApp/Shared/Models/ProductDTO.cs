using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class ProductDTO
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual List<AttributeProductDTO> AttributeProducts { get; set; } = new List<AttributeProductDTO>();

    public virtual CategoryDTO Category { get; set; } = null!;

    public virtual List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

    public virtual List<ProductCategoryDTO> ProductCategories { get; set; } = new List<ProductCategoryDTO>();
    public virtual List<ProductImagesDTO> ProductImages { get; set; } = new List<ProductImagesDTO>();
}
