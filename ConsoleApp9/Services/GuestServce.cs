using ConsoleApp9;
using ConsoleApp9.Entities;
using Microsoft.EntityFrameworkCore;

public class GuestService : IGuestService
{
    private readonly HotelSystemContext _db;
    public GuestService(HotelSystemContext context) => _db = context;

    /// <summary>
    /// Logic to find 50 room numbers not currently assigned to guests in the specified hotel.
    /// </summary>
    public List<string> GetFreeRooms(int hotelId)
    {
        var occupied = _db.Guests.Where(g => g.HotelId == hotelId).Select(g => g.AssignedRoomNumber).ToList();
        List<string> rooms = new List<string>();
        int counter = 1;
        while (rooms.Count < 50)
        {
            if (!occupied.Contains(counter.ToString())) rooms.Add(counter.ToString());
            counter++;
        }
        return rooms;
    }

    /// <summary>
    /// Saves a new guest to the database.
    /// </summary>
    public void AddGuest(Guest g)
    {
        _db.Guests.Add(g);
        _db.SaveChanges();
    }

    /// <summary>
    /// Displays guest details including the primary GuestID.
    /// </summary>
    public void ViewGuestsByHotel(int hotelId)
    {
        var guests = _db.Guests.Where(g => g.HotelId == hotelId).ToList();
        foreach (var g in guests)
            Console.WriteLine($"ID: {g.GuestId} | {g.FirstName} {g.LastName} | Room: {g.AssignedRoomNumber}");
    }

    /// <summary>
    /// Removes a guest record based on their ID.
    /// </summary>
    public bool DeleteGuest(int id)
    {
        var g = _db.Guests.Find(id);
        if (g == null) return false;
        _db.Guests.Remove(g);
        _db.SaveChanges();
        return true;
    }
}