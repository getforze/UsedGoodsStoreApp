using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class AttributeProductDTO
{
    public int AttributeProductId { get; set; }

    public int AttributeId { get; set; }

    public int ProductId { get; set; }

    public int AttributeValueId { get; set; }
    public string Selector { get; set; } = "1";


	public virtual AttributeDTO Attribute1 { get; set; } = null!;

    public virtual AttributeValueDTO AttributeValue { get; set; } = null!;

    public virtual ProductDTO Product { get; set; } = null!;
}
