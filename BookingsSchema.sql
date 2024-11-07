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

create table Admin (
    AdminId int identity(1,1) primary key,
    AdminName varchar(50),
    AdminEmail varchar(40),
    AdminPhone varchar(15)
);

create table BusRoute (
    RouteId int identity(1,1) primary key,
    BusId int foreign key references Buses(BusId),
    RouteSource varchar(50),
    RouteDestination varchar(50),
    RouteDistance float -- Distance in kilometers or miles
);

select * from Buses

INSERT INTO Buses (BusName, BusSource, BusDestination, BusTiming, SeatsAvailable) 
VALUES ('MP Travels', 'Gwalior', 'Indore', '2024-12-09 00:00:00', 30),
('Fast Express', 'Jhansi', 'Khargone', '2024-12-08 00:00:00', 25),
('Shatabdi Express', 'Mumbai', 'Pune', '2024-11-08 07:30:00', 40),
('Rajdhani Travels', 'Delhi', 'Jaipur', '2024-11-08 10:00:00', 35),
('Volvo Express', 'Bangalore', 'Mysore', '2024-11-08 09:00:00', 25),
('Himachal Roadways', 'Manali', 'Shimla', '2024-11-08 06:00:00', 50),
('RedBus Sleeper', 'Hyderabad', 'Vijayawada', '2024-11-08 21:30:00', 20),
('GreenLine AC', 'Chennai', 'Madurai', '2024-11-08 08:30:00', 30),
('SRS Travels', 'Mumbai', 'Goa', '2024-11-08 23:00:00', 15),
('Orange Tours', 'Kolkata', 'Durgapur', '2024-11-08 13:30:00', 28),
('KSRTC Express', 'Coimbatore', 'Ooty', '2024-11-08 12:00:00', 18),
('AP Travels', 'Visakhapatnam', 'Rajahmundry', '2024-11-08 16:45:00', 22);

INSERT INTO Users (UserName, UserrPhone, UserGender, UserEmail)
VALUES
('Aarav Mehta', '9123456789', 'Male', 'aarav.mehta@example.com'),
('Nisha Patel', '9876543210', 'Female', 'nisha.patel@example.com'),
('Rohan Kumar', '9234567890', 'Male', 'rohan.kumar@example.com'),
('Priya Sharma', '9345678901', 'Female', 'priya.sharma@example.com'),
('Amit Singh', '9456789012', 'Male', 'amit.singh@example.com'),
('Kavya Verma', '9567890123', 'Female', 'kavya.verma@example.com'),
('Vikram Choudhary', '9678901234', 'Male', 'vikram.choudhary@example.com'),
('Anjali Desai', '9789012345', 'Female', 'anjali.desai@example.com'),
('Sunil Joshi', '9890123456', 'Male', 'sunil.joshi@example.com'),
('Reema Reddy', '9991234567', 'Female', 'reema.reddy@example.com'),
('Manish Thakur', '9102345678', 'Male', 'manish.thakur@example.com');

select * from Users

INSERT INTO BusBooking (BookingDescription, BusID, UserId)
VALUES
('Booking for Gwalior to Indore', 1, 1),
('Booking for Jhansi to Khargone', 2, 2),
('Booking for Mumbai to Pune', 3, 3),
('Booking for Delhi to Jaipur', 4, 4),
('Booking for Hyderabad to Vijayawada', 7, 5),
('Booking for Chennai to Madurai', 8, 6),
('Booking for Mumbai to Goa', 9, 7),
('Booking for Kolkata to Durgapur', 10, 8),
('Booking for Coimbatore to Ooty', 11, 9),
('Booking for Visakhapatnam to Rajahmundry', 12, 10),
('Return booking for Pune to Mumbai', 1, 11);

select * from BusBooking

INSERT INTO BusOperator (OperatorName, OperatorPhone, OperatorGender, BusID)
VALUES
('Rajesh Kumar', '9812345678', 'Male', 1),
('Anita Desai', '9823456789', 'Female', 2),
('Rakesh Sharma', '9834567890', 'Male', 3),
('Sneha Verma', '9845678901', 'Female', 4),
('Manoj Singh', '9856789012', 'Male', 5),
('Priya Iyer', '9867890123', 'Female', 6),
('Arjun Patel', '9878901234', 'Male', 7),
('Deepa Nair', '9889012345', 'Female', 8),
('Vikash Gupta', '9890123456', 'Male', 9),
('Neha Choudhary', '9901234567', 'Female', 10),
('Amit Tiwari', '9912345678', 'Male', 11),
('Sonal Joshi', '9923456789', 'Female', 12),
('Suresh Reddy', '9934567890', 'Male', 3);

select * from BusOperator

INSERT INTO Admin (AdminName, AdminEmail, AdminPhone)
VALUES
('Vikas Mehta', 'vikas.mehta@example.com', '9812345678'),
('Anjali Rao', 'anjali.rao@example.com', '9823456789'),
('Rahul Sharma', 'rahul.sharma@example.com', '9834567890'),
('Priya Singh', 'priya.singh@example.com', '9845678901'),
('Sunil Joshi', 'sunil.joshi@example.com', '9856789012'),
('Neha Desai', 'neha.desai@example.com', '9867890123'),
('Ramesh Patil', 'ramesh.patil@example.com', '9878901234'),
('Deepa Verma', 'deepa.verma@example.com', '9889012345'),
('Amit Tiwari', 'amit.tiwari@example.com', '9890123456'),
('Sonal Kapoor', 'sonal.kapoor@example.com', '9901234567');

select * from Admin

INSERT INTO BusRoute (BusId, RouteSource, RouteDestination, RouteDistance)
VALUES (1, 'Gwaior', 'Indore', 148.5),
(2, 'Jhansi', 'Khargone', 139.5),
(3, 'Mumbai', 'Pune', 148.5),
(4, 'Delhi', 'Jaipur', 281.0),
(5, 'Bangalore', 'Mysore', 143.0),
(6, 'Manali', 'Shimla', 248.3),
(7, 'Hyderabad', 'Vijayawada', 275.4),
(8, 'Chennai', 'Madurai', 462.0),
(9, 'Mumbai', 'Goa', 583.0),
(10, 'Kolkata', 'Durgapur', 169.0),
(11, 'Coimbatore', 'Ooty', 86.4),
(12, 'Visakhapatnam', 'Rajahmundry', 191.6);

select * from BusRoute


select * from Buses