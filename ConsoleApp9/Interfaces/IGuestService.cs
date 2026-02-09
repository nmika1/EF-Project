using ConsoleApp9.Entities;
/// <summary>
/// Defines operations for guest registration and room allocation logic.
/// </summary>
public interface IGuestService
{
    List<string> GetFreeRooms(int hotelId);
    void AddGuest(Guest g);
    void ViewGuestsByHotel(int hotelId);
    bool DeleteGuest(int id);
}