using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class ProductCategoryDTO
{
    public int ProductCategoryId { get; set; }

    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public virtual CategoryDTO Category { get; set; } = null!;

    public virtual ProductDTO Product { get; set; } = null!;
}
