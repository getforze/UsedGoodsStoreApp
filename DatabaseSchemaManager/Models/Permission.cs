using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models;

public partial class Permission
{
    public int UserId { get; set; }

    public bool IsAdmin { get; set; }

    public virtual User User { get; set; } = null!;
}
