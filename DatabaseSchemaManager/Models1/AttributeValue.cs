using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models1;

public partial class AttributeValue
{
    public int AttributeValueId { get; set; }

    public int AttributeId { get; set; }

    public string Value { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public virtual Attribute Attribute { get; set; } = null!;

    public virtual ICollection<AttributeProduct> AttributeProducts { get; set; } = new List<AttributeProduct>();
}
