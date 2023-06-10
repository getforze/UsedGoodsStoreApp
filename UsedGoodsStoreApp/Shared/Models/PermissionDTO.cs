using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class PermissionDTO
{
    public int UserId { get; set; }

    public bool IsAdmin { get; set; }

    public virtual UserDTO User { get; set; } = null!;
}
