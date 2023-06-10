using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models1;

public partial class Attribute
{
    public int AttributeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public virtual ICollection<AttributeProduct> AttributeProducts { get; set; } = new List<AttributeProduct>();

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();
}
