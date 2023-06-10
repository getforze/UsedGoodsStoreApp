using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class OrderItemDTO
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public virtual OrderDTO Order { get; set; } = null!;

    public virtual ProductDTO Product { get; set; } = null!;
}
