using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class CategoryDTO
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public int ParentCategoryId { get; set; }

    public virtual List<CategoryDTO> InverseParentCategory { get; set; }

    public virtual CategoryDTO ParentCategory { get; set; }

    public virtual List<ProductCategoryDTO> ProductCategories { get; set; } = new List<ProductCategoryDTO>();

    public virtual List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
}
