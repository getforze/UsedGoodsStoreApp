using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models;

public partial class AttributeProduct
{
    public int AttributeProductId { get; set; }

    public int AttributeId { get; set; }

    public int ProductId { get; set; }

    public int AttributeValueId { get; set; }

    public virtual Attribute1 Attribute1 { get; set; } = null!;

    public virtual AttributeValue AttributeValue { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
