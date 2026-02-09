using ConsoleApp9;
using ConsoleApp9.Entities;
using Microsoft.EntityFrameworkCore;

public class HotelService : IHotelService
{
    private readonly HotelSystemContext _db;
    public HotelService(HotelSystemContext context) => _db = context;

    /// <summary>
    /// Calculates the sum of all service prices across the entire system.
    /// </summary>
    public decimal GetTotalRevenue() => _db.Services.Sum(s => s.ServicePrice ?? 0);
}