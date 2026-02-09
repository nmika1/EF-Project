using ConsoleApp9;
using ConsoleApp9.Entities;
using Microsoft.EntityFrameworkCore;

public class EmployeeService : IEmployeeService
{
    private readonly HotelSystemContext _db;
    public EmployeeService(HotelSystemContext context) => _db = context;

    /// <summary>
    /// Displays staff list including the primary EmployeeID.
    /// </summary>
    public void ViewEmployeesByHotel(int hotelId)
    {
        var emps = _db.Employees.Where(e => e.HotelId == hotelId).ToList();
        foreach (var e in emps)
            Console.WriteLine($"ID: {e.EmployeeId} | {e.FirstName} {e.LastName} | Position: {e.Position}");
    }
}