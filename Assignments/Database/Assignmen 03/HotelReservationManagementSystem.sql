CREATE DATABASE HotelReservationManagementSystem;
GO
 
USE HotelReservationManagementSystem;
GO


CREATE TABLE Hotels (
    HotelId         INT IDENTITY(1,1) NOT NULL,
    [Name]          NVARCHAR(100)     NOT NULL,
    Address         NVARCHAR(200)     NOT NULL,
    City            NVARCHAR(100)     NOT NULL,
    StarRating      TINYINT           NOT NULL,
    ContactNumber   VARCHAR(20)       NOT NULL,
    ManagerId       INT               NULL,
    CONSTRAINT PK_Hotels PRIMARY KEY (HotelId),
    CONSTRAINT UQ_Hotels_ManagerId UNIQUE (ManagerId),
    CONSTRAINT CK_Hotels_StarRating CHECK (StarRating BETWEEN 1 AND 5)
);
GO

CREATE TABLE Staff (
    StaffId     INT IDENTITY(1,1) NOT NULL,
    FullName    NVARCHAR(100)     NOT NULL,
    [Position]  NVARCHAR(50)      NOT NULL,
    Salary      DECIMAL(10,2)     NOT NULL,
    HotelId     INT               NOT NULL,
    CONSTRAINT PK_Staff PRIMARY KEY (StaffId),
    CONSTRAINT FK_Staff_Hotels FOREIGN KEY (HotelId)
        REFERENCES Hotels (HotelId),
    CONSTRAINT CK_Staff_Salary CHECK (Salary >= 0)
);
GO

ALTER TABLE Hotels
    ADD CONSTRAINT FK_Hotels_Staff_Manager FOREIGN KEY (ManagerId)
        REFERENCES Staff (StaffId);
GO

CREATE TABLE Services (
    ServiceId    INT IDENTITY(1,1) NOT NULL,
    ServiceName  NVARCHAR(100)     NOT NULL,
    Charge       DECIMAL(10,2)     NOT NULL,
    RequestDate  DATE              NOT NULL,
    StaffId      INT               NOT NULL,
    CONSTRAINT PK_Services PRIMARY KEY (ServiceId),
    CONSTRAINT FK_Services_Staff FOREIGN KEY (StaffId)
        REFERENCES Staff (StaffId),
    CONSTRAINT CK_Services_Charge CHECK (Charge >= 0)
);
GO

CREATE TABLE Rooms (
    RoomNumber   INT             NOT NULL,
    RoomType     NVARCHAR(50)    NOT NULL,
    Capacity     INT             NOT NULL,
    DailyRate    DECIMAL(10,2)   NOT NULL,
    Availability BIT             NOT NULL DEFAULT (1),
    HotelId      INT             NOT NULL,
    CONSTRAINT PK_Rooms PRIMARY KEY (RoomNumber),
    CONSTRAINT FK_Rooms_Hotels FOREIGN KEY (HotelId)
        REFERENCES Hotels (HotelId),
    CONSTRAINT CK_Rooms_Capacity CHECK (Capacity > 0),
    CONSTRAINT CK_Rooms_DailyRate CHECK (DailyRate >= 0)
);
GO

CREATE TABLE Amenities (
    RoomNumber INT           NOT NULL,
    Amenity    NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_Amenities PRIMARY KEY (RoomNumber, Amenity),
    CONSTRAINT FK_Amenities_Rooms FOREIGN KEY (RoomNumber)
        REFERENCES Rooms (RoomNumber)
);
GO

CREATE TABLE Guests (
    GuestId        INT IDENTITY(1,1) NOT NULL,
    FullName       NVARCHAR(100)     NOT NULL,
    Nationality    NVARCHAR(50)      NOT NULL,
    PassportNumber VARCHAR(20)       NOT NULL,
    DateOfBirth    DATE              NOT NULL,
    CONSTRAINT PK_Guests PRIMARY KEY (GuestId),
    CONSTRAINT UQ_Guests_PassportNumber UNIQUE (PassportNumber)
);
GO

CREATE TABLE Guest_Contact_Details (
    GuestId INT           NOT NULL,
    Detail  NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_Guest_Contact_Details PRIMARY KEY (GuestId, Detail),
    CONSTRAINT FK_GuestContact_Guests FOREIGN KEY (GuestId)
        REFERENCES Guests (GuestId) ON DELETE CASCADE
);
GO

CREATE TABLE Payments (
    PaymentId          INT IDENTITY(1,1) NOT NULL,
    Method             NVARCHAR(50)      NOT NULL,
    [Date]             DATE              NOT NULL,
    Amount             DECIMAL(10,2)     NOT NULL,
    ConfirmationNumber VARCHAR(50)       NOT NULL,
    CONSTRAINT PK_Payments PRIMARY KEY (PaymentId),
    CONSTRAINT CK_Payments_Amount CHECK (Amount >= 0)
);
GO

CREATE TABLE Reservations (
    ReservationId     INT IDENTITY(1,1) NOT NULL,
    BookingDate       DATE              NOT NULL,
    CheckInDate       DATE              NOT NULL,
    CheckOutDate      DATE              NOT NULL,
    ReservationStatus NVARCHAR(20)      NOT NULL,
    TotalPrice        DECIMAL(10,2)     NOT NULL,
    NumberOfAdults    INT               NOT NULL,
    NumberOfChildren  INT               NOT NULL DEFAULT (0),
    CONSTRAINT PK_Reservations PRIMARY KEY (ReservationId),
    CONSTRAINT CK_Reservations_Dates CHECK (CheckOutDate > CheckInDate),
    CONSTRAINT CK_Reservations_TotalPrice CHECK (TotalPrice >= 0),
    CONSTRAINT CK_Reservations_Adults CHECK (NumberOfAdults > 0),
    CONSTRAINT CK_Reservations_Children CHECK (NumberOfChildren >= 0),
    CONSTRAINT CK_Reservations_Status CHECK (ReservationStatus IN
        ('Pending', 'Confirmed', 'CheckedIn', 'CheckedOut', 'Cancelled'))
);
GO

CREATE TABLE Reservations_Rooms (
    ReservationId INT NOT NULL,
    RoomNumber    INT NOT NULL,
    CONSTRAINT PK_Reservations_Rooms PRIMARY KEY (ReservationId, RoomNumber),
    CONSTRAINT FK_ResRooms_Reservations FOREIGN KEY (ReservationId)
        REFERENCES Reservations (ReservationId),
    CONSTRAINT FK_ResRooms_Rooms FOREIGN KEY (RoomNumber)
        REFERENCES Rooms (RoomNumber)
);
GO

CREATE TABLE ReservationService (
    ServiceId     INT NOT NULL,
    ReservationId INT NOT NULL,
    CONSTRAINT PK_ReservationService PRIMARY KEY (ServiceId, ReservationId),
    CONSTRAINT FK_ResService_Services FOREIGN KEY (ServiceId)
        REFERENCES Services (ServiceId),
    CONSTRAINT FK_ResService_Reservations FOREIGN KEY (ReservationId)
        REFERENCES Reservations (ReservationId)
);
GO

CREATE TABLE Reservations_Guest (
    ReservationId INT NOT NULL,
    GuestId       INT NOT NULL,
    CONSTRAINT PK_Reservations_Guest PRIMARY KEY (ReservationId, GuestId),
    CONSTRAINT FK_ResGuest_Reservations FOREIGN KEY (ReservationId)
        REFERENCES Reservations (ReservationId),
    CONSTRAINT FK_ResGuest_Guests FOREIGN KEY (GuestId)
        REFERENCES Guests (GuestId)
);
GO

CREATE TABLE Reservations_Payment (
    ReservationId INT NOT NULL,
    PaymentId     INT NOT NULL,
    CONSTRAINT PK_Reservations_Payment PRIMARY KEY (ReservationId, PaymentId),
    CONSTRAINT FK_ResPayment_Reservations FOREIGN KEY (ReservationId)
        REFERENCES Reservations (ReservationId),
    CONSTRAINT FK_ResPayment_Payments FOREIGN KEY (PaymentId)
        REFERENCES Payments (PaymentId)
);
GO