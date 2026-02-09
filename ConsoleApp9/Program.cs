using ConsoleApp9;
using ConsoleApp9.Entities;

/// <summary>
/// Initializes the database context and instantiates specialized services via their interfaces.
/// </summary>
using var context = new HotelSystemContext();

IGuestService guestService = new GuestService(context);
IHotelService hotelService = new HotelService(context);
IEmployeeService employeeService = new EmployeeService(context);
IServiceManager serviceManager = new ServiceManager(context);

/// <summary>
/// Primary execution loop providing the user interface and routing input to specific services.
/// </summary>
while (true)
{
    Console.Clear();
    Console.WriteLine(" HOTEL MANAGEMENT SYSTEM");
    Console.WriteLine("1. View Guests");
    Console.WriteLine("2. Register Guest");
    Console.WriteLine("3. Delete Guest");
    Console.WriteLine("4. View Employees by Hotel");
    Console.WriteLine("5. View Service Prices");
    Console.WriteLine("6. Total System Revenue");
    Console.WriteLine("7. Exit");
    Console.Write("\nSelect: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            /// <summary>
            /// Queries the GuestService to list all guests for a specific hotel.
            /// </summary>
            Console.Write("Enter Hotel ID: ");
            if (int.TryParse(Console.ReadLine(), out int hId1))
                guestService.ViewGuestsByHotel(hId1);
            break;

        case "2":
            /// <summary>
            /// Handles the registration workflow: room suggestion, data collection, and validation.
            /// </summary>
            Console.Write("Hotel ID: ");
            if (!int.TryParse(Console.ReadLine(), out int regHId)) break;

            var rooms = guestService.GetFreeRooms(regHId);
            Console.WriteLine($"\n--- Available Rooms for Hotel {regHId} ---");
            for (int i = 0; i < rooms.Count; i++)
            {
                Console.Write($"[{rooms[i]}] ".PadRight(7));
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }

            Console.Write("\nRoom: "); string r = Console.ReadLine();
            Console.Write("First: "); string fn = Console.ReadLine();
            Console.Write("Last: "); string ln = Console.ReadLine();
            Console.Write("Email: "); string em = Console.ReadLine();
            Console.Write("Phone: "); string ph = Console.ReadLine();

            if (Validator.IsValidName(fn) && Validator.IsValidEmail(em))
            {
                guestService.AddGuest(new Guest
                {
                    FirstName = fn,
                    LastName = ln,
                    Email = em,
                    Phone = ph,
                    HotelId = regHId,
                    AssignedRoomNumber = r
                });
                Console.WriteLine("Guest Registered!");
            }
            break;

        case "3":
            /// <summary>
            /// Requests a deletion operation from the GuestService using a primary key.
            /// </summary>
            Console.Write("Guest ID: ");
            if (int.TryParse(Console.ReadLine(), out int delId))
            {
                if (guestService.DeleteGuest(delId)) Console.WriteLine("Deleted.");
                else Console.WriteLine("Not found.");
            }
            break;

        case "4":
            /// <summary>
            /// Queries the EmployeeService to display staff assigned to a specific hotel.
            /// </summary>
            Console.Write("Hotel ID: ");
            if (int.TryParse(Console.ReadLine(), out int hId4))
                employeeService.ViewEmployeesByHotel(hId4);
            break;

        case "5":
            /// <summary>
            /// Requests the ServiceManager to list all global service prices.
            /// </summary>
            serviceManager.ViewServicePrices();
            break;

        case "6":
            /// <summary>
            /// Calculates and displays the total accumulated revenue from the HotelService.
            /// </summary>
            Console.WriteLine($"Total Revenue: ${hotelService.GetTotalRevenue():F2}");
            break;

        case "7":
            return;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}