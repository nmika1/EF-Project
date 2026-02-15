
-- Stores information about individual hotel branches and their capacity
CREATE TABLE Hotels (
    HotelID INT PRIMARY KEY IDENTITY(1,1),
    HotelName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    TotalRooms INT DEFAULT 250 CHECK (TotalRooms > 0)
);

-- Stores personal information for customers and links them to a specific hotel
CREATE TABLE Guests (
    GuestID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    HotelID INT,
    AssignedRoomNumber NVARCHAR(10),
    FOREIGN KEY (HotelID) REFERENCES Hotels(HotelID)
);

-- Defines the physical rooms available in each hotel, including type and pricing
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    HotelID INT FOREIGN KEY REFERENCES Hotels(HotelID),
    RoomNumber NVARCHAR(10) NOT NULL,
    RoomType NVARCHAR(50) DEFAULT 'Standard',
    PricePerNight DECIMAL(10,2) NOT NULL
);

-- Maintains staff records, roles, and payroll information per hotel branch
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Position NVARCHAR(50),
    Salary DECIMAL(10, 2) CHECK (Salary > 0),
    Status NVARCHAR(20) DEFAULT 'Active',
    HotelID INT FOREIGN KEY REFERENCES Hotels(HotelID)
);

-- Catalog of extra amenities (like spa or gym) offered by each hotel
CREATE TABLE Services (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    HotelID INT FOREIGN KEY REFERENCES Hotels(HotelID),
    ServiceName NVARCHAR(100) NOT NULL,
    ServicePrice DECIMAL(10, 2) DEFAULT 0.00 
);

-- Records guest stay durations and projected costs for specific hotels
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    GuestID INT FOREIGN KEY REFERENCES Guests(GuestID),
    HotelID INT FOREIGN KEY REFERENCES Hotels(HotelID),
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    TotalAmount DECIMAL(10,2)
);

-- Links specific extra services used to a particular booking (Many-to-Many relationship)
CREATE TABLE BookingServices ( 
    BookingID INT FOREIGN KEY REFERENCES Bookings(BookingID),
    ServiceID INT FOREIGN KEY REFERENCES Services(ServiceID),
    Quantity INT DEFAULT 1,
    PRIMARY KEY (BookingID, ServiceID)
);

-- Stores customer feedback and numerical ratings for hotel quality
CREATE TABLE Reviews (
    ReviewID INT PRIMARY KEY IDENTITY(1,1),
    HotelID INT FOREIGN KEY REFERENCES Hotels(HotelID),
    GuestID INT FOREIGN KEY REFERENCES Guests(GuestID),
    Rating INT CHECK (Rating >= 1 AND Rating <= 5), 
    Comments NVARCHAR(MAX),
    ReviewDate DATE DEFAULT GETDATE()
);

-- Tracks financial transactions and payment methods linked to bookings
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT FOREIGN KEY REFERENCES Bookings(BookingID),
    Amount DECIMAL(10,2) NOT NULL,
    PaymentMethod NVARCHAR(50) DEFAULT 'Credit Card'
);

-- Logs repair history and descriptions for specific room maintenance tasks
CREATE TABLE RoomMaintenance (
    MaintenanceID INT PRIMARY KEY IDENTITY(1,1),
    RoomID INT FOREIGN KEY REFERENCES Rooms(RoomID),
    Description NVARCHAR(255),
    MaintenanceDate DATE DEFAULT GETDATE()
);
GO