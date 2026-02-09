using System;
using System.Collections.Generic;

namespace ConsoleApp9.Entities;

public partial class Guest
{
    public int GuestId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? HotelId { get; set; }

    public string? AssignedRoomNumber { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
