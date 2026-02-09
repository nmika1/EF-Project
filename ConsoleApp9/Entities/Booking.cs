using System;
using System.Collections.Generic;

namespace ConsoleApp9.Entities;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? GuestId { get; set; }

    public int? HotelId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();

    public virtual Guest? Guest { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
