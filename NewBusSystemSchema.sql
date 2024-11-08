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
