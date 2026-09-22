INSERT INTO Guests
    (FullName, Nationality, PassportNumber, DateOfBirth)
VALUES
    (N'Khalad Mohamed', N'Egyptian', 'A12345677', '2000-04-15');


INSERT INTO Guests
    (FullName, Nationality, PassportNumber, DateOfBirth)
VALUES
    (N'Ahmed Mohamed', N'Egyptian', 'A12345678', '2000-05-15'),
    (N'Mohamed Ali', N'Egyptian', 'A12345679', '1999-10-20'),
    (N'Omar Hassan', N'Saudi', 'B98765432', '2001-03-12');



SELECT * FROM Guests;



ALTER TABLE Reservations
DROP CONSTRAINT CK_Reservations_Status; 

ALTER TABLE Reservations
ADD CONSTRAINT CK_Reservations_Status
CHECK (ReservationStatus IN (
    'Pending',
    'Confirmed',
    'CheckedIn',
    'CheckedOut',
    'Cancelled',
    'Completed',
    'Upcoming',
    'Active'
));


UPDATE ROOMS
SET DailyRate = DailyRate * 1.15
WHERE RoomType = N'Suite';


UPDATE Reservations
SET ReservationStatus =
    CASE
        WHEN CheckOutDate < CAST(GETDATE() AS DATE)
            THEN 'Completed'

        WHEN CheckInDate > CAST(GETDATE() AS DATE)
            THEN 'Upcoming'

        ELSE 'Active'
    END;





