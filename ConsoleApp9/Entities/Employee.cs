using System;
using System.Collections.Generic;

namespace ConsoleApp9.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Position { get; set; }

    public decimal? Salary { get; set; }

    public string? Status { get; set; }

    public int? HotelId { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
