using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models1;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int OrderStatusId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public int HouseNumber { get; set; }

    public int? ApartamentNumber { get; set; }

    public string PostalCode { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
