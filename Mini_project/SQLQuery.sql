CREATE DATABASE TrainReservationDB;
USE TrainReservationDB;

CREATE TABLE Users
(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL 
);

CREATE TABLE Train
(
    TrainNo INT PRIMARY KEY,
    TrainName VARCHAR(100),
    SourceStation VARCHAR(100),
    DestinationStation VARCHAR(100),

    Seats_2AC INT DEFAULT 0,
    Seats_3AC INT DEFAULT 0,
    Seats_Sleeper INT DEFAULT 0,

    Charges_2AC DECIMAL(10,2),
    Charges_3AC DECIMAL(10,2),
    Charges_Sleeper DECIMAL(10,2),

    IsDeleted BIT DEFAULT 0
);

CREATE TABLE Booking
(
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    BookDate DATE,
    TravelDate DATE,
    TrainNo INT FOREIGN KEY REFERENCES Train(TrainNo),
    TravelClass VARCHAR(20),
    Passengers INT CHECK (Passengers <= 3),
    Amount DECIMAL(10,2),
    Status VARCHAR(20) DEFAULT 'Booked'
);

CREATE TABLE Cancellation
(
    CId INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT FOREIGN KEY REFERENCES Booking(BookingId),
    NoTickets INT,
    RefundAmount DECIMAL(10,2),
    CancelDate DATE DEFAULT GETDATE()
);

INSERT INTO Users VALUES ('admin', 'admin123', 'Admin');
INSERT INTO Users VALUES ('user1', 'user123', 'User');

CREATE PROCEDURE sp_AddTrain
(
    @TrainNo INT,
    @TrainName VARCHAR(100),
    @Source VARCHAR(100),
    @Destination VARCHAR(100),

    @Seats2AC INT,
    @Seats3AC INT,
    @SeatsSleeper INT,

    @Charges2AC DECIMAL(10,2),
    @Charges3AC DECIMAL(10,2),
    @ChargesSleeper DECIMAL(10,2)
)
AS
BEGIN
    INSERT INTO Train
    VALUES
    (
        @TrainNo,
        @TrainName,
        @Source,
        @Destination,
        @Seats2AC,
        @Seats3AC,
        @SeatsSleeper,
        @Charges2AC,
        @Charges3AC,
        @ChargesSleeper,
        0
    )
END


CREATE PROCEDURE sp_ViewTrains
AS
BEGIN
    SELECT * FROM Train
    WHERE IsDeleted = 0
END

CREATE PROCEDURE sp_DeleteTrain
(
    @TrainNo INT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Booking WHERE TrainNo = @TrainNo)
    BEGIN
        PRINT 'Cannot delete. Bookings exist.'
    END
    ELSE
    BEGIN
        UPDATE Train
        SET IsDeleted = 1
        WHERE TrainNo = @TrainNo

        PRINT 'Train deleted successfully.'
    END
END

CREATE PROCEDURE sp_BookTicket
(
    @BookDate DATE,
    @TravelDate DATE,
    @TrainNo INT,
    @TravelClass VARCHAR(20),
    @Passengers INT
)
AS
BEGIN
    DECLARE @Available INT
    DECLARE @Charge DECIMAL(10,2)
    DECLARE @Total DECIMAL(10,2)

    IF @TravelClass = '2AC'
        SELECT @Available = Seats_2AC, @Charge = Charges_2AC FROM Train WHERE TrainNo = @TrainNo

    ELSE IF @TravelClass = '3AC'
        SELECT @Available = Seats_3AC, @Charge = Charges_3AC FROM Train WHERE TrainNo = @TrainNo

    ELSE
        SELECT @Available = Seats_Sleeper, @Charge = Charges_Sleeper FROM Train WHERE TrainNo = @TrainNo

    IF @Available >= @Passengers
    BEGIN
        SET @Total = @Passengers * @Charge

        INSERT INTO Booking(BookDate, TravelDate, TrainNo, TravelClass, Passengers, Amount)
        VALUES(@BookDate, @TravelDate, @TrainNo, @TravelClass, @Passengers, @Total)

        IF @TravelClass = '2AC'
            UPDATE Train SET Seats_2AC = Seats_2AC - @Passengers WHERE TrainNo = @TrainNo
        ELSE IF @TravelClass = '3AC'
            UPDATE Train SET Seats_3AC = Seats_3AC - @Passengers WHERE TrainNo = @TrainNo
        ELSE
            UPDATE Train SET Seats_Sleeper = Seats_Sleeper - @Passengers WHERE TrainNo = @TrainNo

        PRINT 'Booking Successful'
    END
    ELSE
    BEGIN
        PRINT 'Seats Not Available'
    END
END


CREATE PROCEDURE sp_CancelTicket
(
    @BookingId INT,
    @NoTickets INT
)
AS
BEGIN
    DECLARE @TrainNo INT
    DECLARE @Class VARCHAR(20)

    SELECT @TrainNo = TrainNo, @Class = TravelClass
    FROM Booking
    WHERE BookingId = @BookingId

    INSERT INTO Cancellation(BookingId, NoTickets, RefundAmount)
    VALUES(@BookingId, @NoTickets, @NoTickets * 900)

    UPDATE Booking
    SET Status = 'Cancelled'
    WHERE BookingId = @BookingId

    IF @Class = '2AC'
        UPDATE Train SET Seats_2AC = Seats_2AC + @NoTickets WHERE TrainNo = @TrainNo
    ELSE IF @Class = '3AC'
        UPDATE Train SET Seats_3AC = Seats_3AC + @NoTickets WHERE TrainNo = @TrainNo
    ELSE
        UPDATE Train SET Seats_Sleeper = Seats_Sleeper + @NoTickets WHERE TrainNo = @TrainNo

    PRINT 'Cancellation Successful'
END

CREATE PROCEDURE sp_GetTrains
AS
BEGIN
    SELECT * FROM Train
    WHERE IsDeleted = 0
END

CREATE PROCEDURE sp_SearchTrains
(
    @Source VARCHAR(100),
    @Destination VARCHAR(100)
)
AS
BEGIN
    SELECT * FROM Train
    WHERE SourceStation = @Source
    AND DestinationStation = @Destination
    AND IsDeleted = 0
END

CREATE PROCEDURE sp_GetLastBooking
AS
BEGIN
    SELECT TOP 1 * FROM Booking
    ORDER BY BookingId DESC
END

CREATE PROCEDURE sp_GetBookings
AS
BEGIN
    SELECT * FROM Booking
END

CREATE PROCEDURE sp_UpdateTrain
(
    @TrainNo INT,
    @TrainName VARCHAR(100),
    @Source VARCHAR(100),
    @Destination VARCHAR(100),

    @Seats2AC INT,
    @Seats3AC INT,
    @SeatsSleeper INT,

    @Charges2AC DECIMAL(10,2),
    @Charges3AC DECIMAL(10,2),
    @ChargesSleeper DECIMAL(10,2)
)
AS
BEGIN
    UPDATE Train
    SET
        TrainName = @TrainName,
        SourceStation = @Source,
        DestinationStation = @Destination,
        Seats_2AC = @Seats2AC,
        Seats_3AC = @Seats3AC,
        Seats_Sleeper = @SeatsSleeper,
        Charges_2AC = @Charges2AC,
        Charges_3AC = @Charges3AC,
        Charges_Sleeper = @ChargesSleeper
    WHERE TrainNo = @TrainNo
      AND IsDeleted = 0
END

CREATE PROCEDURE sp_RegisterUser
(
    @Username VARCHAR(50),
    @Password VARCHAR(50)
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Users WHERE Username = @Username)
    BEGIN
        PRINT 'Username already exists'
    END
    ELSE
    BEGIN
        INSERT INTO Users(Username, Password, Role)
        VALUES(@Username, @Password, 'User')

        PRINT 'Registration Successful'
    END
END

CREATE PROCEDURE sp_GetCancellations
AS
BEGIN
    SELECT *
    FROM Cancellation
    ORDER BY CancelDate DESC;
END

ALTER PROCEDURE sp_CancelTicket
(
    @BookingId INT,
    @NoTickets INT
)
AS
BEGIN
    DECLARE @TrainNo INT
    DECLARE @Class VARCHAR(20)
    DECLARE @BookedPassengers INT
    DECLARE @Amount DECIMAL(10,2)

    SELECT
        @TrainNo = TrainNo,
        @Class = TravelClass,
        @BookedPassengers = Passengers,
        @Amount = Amount
    FROM Booking
    WHERE BookingId = @BookingId

    IF @BookedPassengers IS NULL
    BEGIN
        PRINT 'Invalid Booking ID'
        RETURN
    END

    IF EXISTS
    (
        SELECT 1
        FROM Booking
        WHERE BookingId = @BookingId
        AND Status = 'Cancelled'
    )
    BEGIN
        PRINT 'Booking already cancelled'
        RETURN
    END

    -- Cannot cancel more than booked
    IF @NoTickets > @BookedPassengers
    BEGIN
        PRINT 'Cannot cancel more tickets than booked'
        RETURN
    END

    INSERT INTO Cancellation
    (
        BookingId,
        NoTickets,
        RefundAmount
    )
    VALUES
    (
        @BookingId,
        @NoTickets,
        @NoTickets * 900
    )

    IF @NoTickets = @BookedPassengers
    BEGIN
        UPDATE Booking
        SET Status = 'Cancelled',
            Passengers = 0
        WHERE BookingId = @BookingId
    END
    ELSE
    BEGIN
        UPDATE Booking
        SET Passengers = Passengers - @NoTickets
        WHERE BookingId = @BookingId
    END

    IF @Class = '2AC'
        UPDATE Train
        SET Seats_2AC = Seats_2AC + @NoTickets
        WHERE TrainNo = @TrainNo

    ELSE IF @Class = '3AC'
        UPDATE Train
        SET Seats_3AC = Seats_3AC + @NoTickets
        WHERE TrainNo = @TrainNo

    ELSE
        UPDATE Train
        SET Seats_Sleeper = Seats_Sleeper + @NoTickets
        WHERE TrainNo = @TrainNo

    PRINT 'Cancellation Successful'
END