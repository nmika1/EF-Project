using ConsoleApp9;
using ConsoleApp9.Entities;
using Microsoft.EntityFrameworkCore;

public class ServiceManager : IServiceManager
{
    private readonly HotelSystemContext _db;
    public ServiceManager(HotelSystemContext context) => _db = context;

    /// <summary>
    /// Displays all services and their prices from the database.
    /// </summary>
    public void ViewServicePrices()
    {
        var services = _db.Services.ToList();
        foreach (var s in services)
            Console.WriteLine($"{s.ServiceName}: ${s.ServicePrice}");
    }
}