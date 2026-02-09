using System;
using System.Collections.Generic;

namespace ConsoleApp9.Entities;

public partial class Service
{
    public int ServiceId { get; set; }

    public int? HotelId { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal? ServicePrice { get; set; }

    public virtual ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();

    public virtual Hotel? Hotel { get; set; }
}
