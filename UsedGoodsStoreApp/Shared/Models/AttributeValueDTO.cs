using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class AttributeValueDTO
{
    public int AttributeValueId { get; set; }

    public int AttributeId { get; set; }

    public string Value { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public virtual Attribute Attribute { get; set; } = null!;

    public virtual List<AttributeProductDTO> AttributeProducts { get; set; } = new List<AttributeProductDTO>();
}
