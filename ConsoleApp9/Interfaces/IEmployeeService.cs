using ConsoleApp9.Entities;

/// <summary>
/// Defines operations for viewing and managing hotel staff.
/// </summary>
public interface IEmployeeService
{
    void ViewEmployeesByHotel(int hotelId);
}