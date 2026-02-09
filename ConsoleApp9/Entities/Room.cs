using System;
using System.Collections.Generic;

namespace ConsoleApp9.Entities;

public partial class Room
{
    public int RoomId { get; set; }

    public int? HotelId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string? RoomType { get; set; }

    public decimal PricePerNight { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<RoomMaintenance> RoomMaintenances { get; set; } = new List<RoomMaintenance>();
}
