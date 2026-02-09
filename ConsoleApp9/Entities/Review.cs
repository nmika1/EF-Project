using System;
using System.Collections.Generic;

namespace ConsoleApp9.Entities;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? HotelId { get; set; }

    public int? GuestId { get; set; }

    public int? Rating { get; set; }

    public string? Comments { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
