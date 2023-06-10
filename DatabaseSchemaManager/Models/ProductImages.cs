using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models;

public partial class ProductImages
{
    public int ProductImageId { get; set; }
    public int ProductId { get; set; }

    public byte[] Image { get; set; }

    public bool IsMainImage { get; set; }

    public virtual Product Product { get; set; } = null!;

}
