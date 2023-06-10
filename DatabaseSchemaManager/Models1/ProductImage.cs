using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models1;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public int ProductId { get; set; }

    public byte[] Image { get; set; } = null!;

    public bool IsMainImage { get; set; }

    public virtual Product Product { get; set; } = null!;
}
