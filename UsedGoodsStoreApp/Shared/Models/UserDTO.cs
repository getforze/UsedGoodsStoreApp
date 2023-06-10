using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class UserDTO
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string Password { get; set; }
    public virtual List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();

    public virtual PermissionDTO Permission { get; set; }
}
