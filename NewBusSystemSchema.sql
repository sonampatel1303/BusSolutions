create database BusSystem

create table Users(
	UserId int identity(1,1) primary key,
	UserName varchar(50),
	PhoneNumber varchar(20),
	Gender varchar(10),
	Email varchar(40),
	Address VARCHAR(255),
	Role VARCHAR(50), -- 'User', 'Admin', 'Operator'
	DateCreated DATETIME DEFAULT CURRENT_TIMESTAMP
)
--added price per seat
create table Buses(
	BusId int identity(1,1) primary key,
	BusName varchar(50),
	Bustype varchar(50),
	Amenities varchar(255),
	NumberofSeats int,
	PricePerSeat int,
)
--added source and destination,and made busid as foreign key
CREATE TABLE Routes (
    RouteId INT IDENTITY(1,1) PRIMARY KEY,
    SourcePoint VARCHAR(255),
    Destination VARCHAR(255),
    BusId INT FOREIGN KEY REFERENCES Buses(BusId),
    DepartureTime DATETIME,
    ArrivalTime DATETIME
);

create table Bookings(
	BookingId int identity(1,1) primary key,
	UserId int,
	RouteId int,
	NumberofSeats int,
	TotalPrice DECIMAL(10, 2),
    BookingDate DATETIME DEFAULT CURRENT_TIMESTAMP,
	 FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (RouteId) REFERENCES Routes(RouteId)
)

create table BusOperator(
	OperatorId int identity(1,1) primary key,
	OperatorName varchar(50),
	OperatorPhone varchar(11),
	DateCreated DATETIME DEFAULT CURRENT_TIMESTAMP,
	BusID int foreign key references Buses(BusId)

)
--added payment mode
create table Payments (
    Id int identity(1,1) primary key,
    BookingId INT,
    PaymentAmount DECIMAL(10, 2),
	PaymentMode varchar(100), --Online ,Cash (if online,we will keep status as completed,in case of cash, status will be pending)
    PaymentDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status VARCHAR(50), -- 'Pending', 'Completed'
    FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
);




INSERT INTO Users (UserName, PhoneNumber, Gender, Email, Address, Role, DateCreated) VALUES
('Rajesh Kumar', '9876543210', 'Male', 'rajesh.kumar@example.com', 'Mumbai, Maharashtra', 'User', GETDATE()),
('Priya Sharma', '9765432109', 'Female', 'priya.sharma@example.com', 'Delhi', 'User', GETDATE()),
('Amit Singh', '9654321098', 'Male', 'amit.singh@example.com', 'Bangalore, Karnataka', 'User', GETDATE()),
('Anjali Patel', '9543210987', 'Female', 'anjali.patel@example.com', 'Ahmedabad, Gujarat', 'User', GETDATE()),
('Suresh Reddy', '9432109876', 'Male', 'suresh.reddy@example.com', 'Hyderabad, Telangana', 'User', GETDATE()),
('Neha Gupta', '9321098765', 'Female', 'neha.gupta@example.com', 'Chennai, Tamil Nadu', 'User', GETDATE()),
('Vikram Desai', '9210987654', 'Male', 'vikram.desai@example.com', 'Pune, Maharashtra', 'BusOperator', GETDATE()),
('Ravi Mehta', '9109876543', 'Male', 'ravi.mehta@example.com', 'Kolkata, West Bengal', 'BusOperator', GETDATE()),
('Admin User', '9998887777', 'Male', 'admin@example.com', 'Mumbai, Maharashtra', 'Admin', GETDATE()),
('Rohit Singh', '9098765432', 'Male', 'rohit.singh@example.com', 'Jaipur, Rajasthan', 'User', GETDATE());


INSERT INTO Buses (BusName, Bustype, Amenities, NumberofSeats, PricePerSeat) VALUES
('Sharma Travels', 'Sleeper', 'WiFi, AC, Blanket', 40, 600),
('Raj Ratan Travels', 'Seater', 'AC, Charging Point', 50, 500),
('Patel Tours', 'Sleeper', 'AC, Blanket', 40, 700),
('VRL Travels', 'Seater', 'Charging Point', 45, 250),
('Neeta Travels', 'Semi-Sleeper', 'WiFi, AC, Charging Point', 50, 750),
('Orange Tours', 'Sleeper', 'AC, Blanket, Charging Point', 40, 650),
('Jabbar Travels', 'Sleeper', 'AC, WiFi, Blanket', 40, 600),
('SRS Travels', 'Semi-Sleeper', 'WiFi,Non-AC, Charging Point', 50, 200),
('KSRTC', 'Seater', 'AC', 60, 400),
('KPN Travels', 'Sleeper', 'WiFi, AC, Blanket', 42, 700);

INSERT INTO Routes (SourcePoint, Destination, BusId, DepartureTime, ArrivalTime) VALUES
('Mumbai', 'Pune', 1, '2024-11-10 08:00:00', '2024-11-10 11:00:00'),
('Delhi', 'Agra', 2, '2024-11-10 09:30:00', '2024-11-10 12:30:00'),
('Bangalore', 'Chennai', 3, '2024-11-11 07:00:00', '2024-11-11 13:00:00'),
('Hyderabad', 'Vijayawada', 4, '2024-11-11 10:00:00', '2024-11-11 14:00:00'),
('Ahmedabad', 'Surat', 5, '2024-11-12 06:30:00', '2024-11-12 10:00:00'),
('Jaipur', 'Jodhpur', 6, '2024-11-12 05:00:00', '2024-11-12 10:00:00'),
('Kolkata', 'Durgapur', 7, '2024-11-12 15:00:00', '2024-11-12 18:00:00'),
('Chennai', 'Coimbatore', 8, '2024-11-13 07:30:00', '2024-11-13 12:00:00'),
('Mumbai', 'Goa', 9, '2024-11-13 20:00:00', '2024-11-14 08:00:00'),
('Pune', 'Nagpur', 10, '2024-11-14 08:00:00', '2024-11-14 20:00:00');

INSERT INTO Bookings (UserId, RouteId, NumberofSeats, TotalPrice, BookingDate) VALUES
(1, 1, 2, 1200.00, GETDATE()),
(2, 2, 1, 500.00, GETDATE()),
(3, 3, 3, 2100.00, GETDATE()),
(4, 4, 2, 1300.00, GETDATE()),
(5, 5, 1, 700.00, GETDATE()),
(6, 6, 4, 3200.00, GETDATE()),
(7, 7, 1, 600.00, GETDATE()),
(8, 8, 2, 1600.00, GETDATE()),
(9, 9, 3, 2100.00, GETDATE()),
(10, 10, 1, 800.00, GETDATE());

INSERT INTO BusOperator (OperatorName, OperatorPhone, BusID) VALUES
('Rakesh Kumar', '9876543210', 1),
('Sunita Singh', '8765432109', 2),
('Amit Sharma', '7654321098', 3),
('Priya Patel', '6543210987', 4),
('Rajesh Rathi', '5432109876', 5),
('Anjali Rao', '4321098765', 6),
('Vikram Mehta', '3210987654', 7),
('Sneha Gupta', '2109876543', 8),
('Manish Tiwari', '1098765432', 9),
('Pooja Verma', '1987654321', 10);

INSERT INTO Payments (BookingId, PaymentAmount, PaymentMode, Status) VALUES
(1, 1200.00, 'Online', 'Completed'),
(2, 500.00, 'Cash', 'Pending'),
(3, 2100.00, 'Online', 'Completed'),
(4, 1300.00, 'Cash', 'Pending'),
(5, 700.00, 'Online', 'Completed'),
(6, 3200.00, 'Cash', 'Pending'),
(7, 600.00, 'Online', 'Completed'),
(8, 1600.00, 'Cash', 'Pending'),
(9, 2100.00, 'Online', 'Completed'),
(10, 800.00, 'Cash', 'Pending');

ALTER TABLE Bookings
ADD BookingStatus VARCHAR(50) DEFAULT 'Booked';

UPDATE Bookings
SET BookingStatus = 'Booked'
WHERE BookingStatus IS NULL;

select * from Bookings