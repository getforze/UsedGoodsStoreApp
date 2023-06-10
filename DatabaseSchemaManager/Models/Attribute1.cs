using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models;

public partial class Attribute1
{
    public int AttributeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public virtual ICollection<AttributeProduct> AttributeProducts { get; set; } = new List<AttributeProduct>();

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();
}
