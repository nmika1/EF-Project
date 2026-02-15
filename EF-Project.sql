-- Retrieves guest contact details, room assignments, and their submitted feedback. 
SELECT 
    g.GuestID AS [ID],
    g.FirstName AS [Name],
    g.LastName AS [Last Name],
    g.Email AS [Email Address],
    g.AssignedRoomNumber AS [Room],
    ISNULL(CAST(r.Rating AS VARCHAR), 'No Rating') AS [Rating],
    ISNULL(r.Comments, 'No Comment') AS [Feedback]
FROM Guests g
LEFT JOIN Reviews r ON g.GuestID = r.GuestID
ORDER BY g.LastName;


--  Lists all hotel services and their local currency pricing. 
SELECT 
    s.ServiceID AS [ID],
    h.HotelName AS [Hotel],
    s.ServiceName AS [Service Name],
    FORMAT(s.ServicePrice, 'C', 'ka-GE') AS [Price] 
FROM Services s
JOIN Hotels h ON s.HotelID = h.HotelID
ORDER BY h.HotelName;

-- Displays a directory of all hotel branches and their room capacities. 
SELECT 
    HotelID AS [ID], 
    HotelName AS [Hotel Name], 
    Location AS [City/Region], 
    TotalRooms AS [Capacity]
FROM Hotels
ORDER BY Location;

--  Shows the volume of reviews and the average satisfaction score for each hotel.
SELECT 
    h.HotelID,
    h.HotelName AS [Hotel],
    COUNT(r.ReviewID) AS [Total Reviews],
    CAST(AVG(CAST(r.Rating AS DECIMAL(10,2))) AS DECIMAL(10,1)) AS [Average Rating]
FROM Hotels h
LEFT JOIN Reviews r ON h.HotelID = r.HotelID
GROUP BY h.HotelID, h.HotelName
ORDER BY [Average Rating] DESC;

-- Reports the total monetary value of all services provided by each hotel branch. 
SELECT 
    h.HotelName AS [Hotel Name],
    h.HotelID AS [ID],
    FORMAT(ISNULL(SUM(s.ServicePrice), 0), 'C', 'ka-GE') AS [Total Service Value]
FROM Hotels h
LEFT JOIN Services s ON h.HotelID = s.HotelID
GROUP BY h.HotelID, h.HotelName
ORDER BY SUM(s.ServicePrice) DESC;

-- Provides a complete staff directory with roles, pay, and their workplace assignment. 
SELECT 
    e.FirstName + ' ' + e.LastName AS [Full Name],
    e.EmployeeID AS [ID],
    e.Position,
    e.Salary,
    e.Status,
    h.HotelName AS [Works At]
FROM Employees e
JOIN Hotels h ON e.HotelID = h.HotelID
ORDER BY h.HotelName, e.Salary DESC;


