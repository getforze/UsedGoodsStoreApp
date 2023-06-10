using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class ProductImagesDTO
{
    public int ProductImageId { get; set; }
    public int ProductId { get; set; }

    public byte[] Image { get; set; }

    public bool IsMainImage { get; set; }

    public virtual ProductDTO Product { get; set; } = new ProductDTO();

}
