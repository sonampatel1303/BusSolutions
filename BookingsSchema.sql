create table Buses(
BusId int identity(1,1) primary key,
BusName varchar(50),
BusSource varchar(50),
BusDestination varchar(50),
BusTiming datetime,
SeatsAvailable int
)


create table BusBooking(
Bookingid int identity(1,1) primary key,
BookingDescription varchar(100),
BusID int foreign key references Buses(BusId),
UserId int foreign key references Users(UserId)
)

create table BusOperator(
OperatorId int identity(1,1) primary key,
OperatorName varchar(50),
OperatorPhone varchar(11),
OperatorGender varchar(10),
BusID int foreign key references Buses(BusId)

)

create table Users(
UserId int identity(1,1) primary key,
UserName varchar(50),
UserrPhone varchar(11),
UserGender varchar(10),
UserEmail varchar(40)
)