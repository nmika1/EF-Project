using System;
using System.Collections.Generic;

namespace ConsoleApp9.Entities;

public partial class RoomMaintenance
{
    public int MaintenanceId { get; set; }

    public int? RoomId { get; set; }

    public string? Description { get; set; }

    public DateOnly? MaintenanceDate { get; set; }

    public virtual Room? Room { get; set; }
}
