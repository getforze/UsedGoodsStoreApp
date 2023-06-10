using System;
using System.Collections.Generic;

namespace UsedGoodsStoreApp.Shared.Models;

public partial class OrderDTO
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int OrderStatusId { get; set; }

    public DateTime OrderDate { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public int HouseNumber { get; set; }
    public int? ApartamentNumber { get; set; }
    public string PostalCode { get; set; }

    public virtual List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

    public virtual OrderStatusDTO OrderStatus { get; set; } = null!;

    public virtual UserDTO User { get; set; } = null!;
}
