Drop table if exists [dbo].BookingHistory
Drop table if exists [dbo].Booking
Drop table if exists [dbo].Competency
Drop table if exists [dbo].Customer
Drop table if exists [dbo].Treatment
Drop table if exists [dbo].Vacation
Drop table if exists [dbo].Worker
Drop table if exists [dbo].[User]
Drop table if exists [dbo].[OpeningHours]



CREATE TABLE [User] (
  [id] integer PRIMARY KEY,
  [username] nvarchar(255),
  [password] nvarchar(255),
  [role] nvarchar(255)
)
GO
CREATE TABLE [Treatment] (
  [Id] integer PRIMARY KEY,
  [price] float NOT NULL,
  [Duration] float
)
GO



CREATE TABLE [Customer] (
  [id] integer PRIMARY KEY,
  [Name] nvarchar(255),
  [Email] nvarchar(255),
  [Phonenumber] nvarchar(255)
)
GO

CREATE TABLE [Worker] (
  [id] integer PRIMARY KEY,
  [Name] nvarchar(255)
)
GO
CREATE TABLE [Booking] (
  [id] integer PRIMARY KEY,
  [StartTime] Char(255),
  [Duration] float,
  [treatmentId] int NOT NULL,
  [customerId] int NOT NULL,
  [workerId] int NOT NULL,
  foreign key ([treatmentId]) references [Treatment] (Id),
  foreign key ([customerId]) references [Customer] (Id),
  foreign key (workerId) references [Worker] (Id)
)
GO

CREATE TABLE [BookingHistory] (
  [id] integer PRIMARY KEY,
  [StartTime] timestamp,
  [Duration] float,
  [customerId] int NOT NULL,
  [workerId] int NOT NULL,
  [bookingId] int NOT NULL,
  foreign key ([customerId]) references [Customer] (Id),
  foreign key (workerId) references [Worker] (Id),
  foreign key (bookingId) references Booking (Id),

)
GO

CREATE TABLE [Vacation] (
  [id] integer PRIMARY KEY,
  [start] datetime NOT NULL,
  [end] datetime NOT NULL,
  [workerId] integer NOT NULL,
   foreign key (workerId) references [Worker] (Id),

)
GO



CREATE TABLE [Competency] (
  [id] integer PRIMARY KEY,
  [treatmentId] integer,
  [workerId] integer,
  foreign key ([treatmentId]) references [Treatment] (Id),
  foreign key (workerId) references [Worker] (Id),
)
GO

CREATE TABLE [OpeningHours] (
[Id] integer PRIMARY KEY,
[Day] nvarchar(250),
[StartTime] nvarchar(250) Null,
[EndTime] nvarchar(250) NULL,
[ErOpen] bit
)
GO




-- =========================
-- TEST DATA
-- =========================

-- USERS
INSERT INTO [User] (Id, Username, Password, Role)
VALUES 
(1, 'admin', 'admin123', 'Admin'),
(2, 'anna', 'anna123', 'Worker'),
(3, 'mikkel', 'mikkel123', 'Worker'),
(4, 'reception', 'recep123', 'Receptionist');


-- CUSTOMERS
INSERT INTO [Customer] (Id, Name, Email, PhoneNumber)
VALUES
(1, 'Peter Hansen', 'peter@gmail.com', '20112233'),
(2, 'Maria Jensen', 'maria@gmail.com', '22334455'),
(3, 'Lars Nielsen', 'lars@gmail.com', '33445566'),
(4, 'Sofie Andersen', 'sofie@gmail.com', '44556677'),
(5, 'Emma Pedersen', 'emma@gmail.com', '55667788');


-- WORKERS
INSERT INTO [Worker] (Id, Name)
VALUES
(1, 'Anna Frisør'),
(2, 'Mikkel Barber'),
(3, 'Louise Stylist');


-- TREATMENTS
INSERT INTO [Treatment] (Id, Price, Duration)
VALUES
(1, 200, 30),
(2, 300, 45),
(3, 400, 60),
(4, 550, 90),
(5, 150, 20);


-- COMPETENCIES
INSERT INTO [Competency] (Id, TreatmentId, WorkerId)
VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 2),
(4, 4, 3),
(5, 5, 2),
(6, 1, 3),
(7, 2, 2);


-- OPENING HOURS
INSERT INTO [OpeningHours] (Id, Day, StartTime, EndTime, ErOpen)
VALUES
(1, 'Monday', '08:00', '17:00', 1),
(2, 'Tuesday', '08:00', '17:00', 1),
(3, 'Wednesday', '08:00', '17:00', 1),
(4, 'Thursday', '08:00', '18:00', 1),
(5, 'Friday', '08:00', '16:00', 1),
(6, 'Saturday', '10:00', '14:00', 1),
(7, 'Sunday', NULL, NULL, 0);


-- BOOKINGS
INSERT INTO [Booking] 
(Id, StartTime, Duration, TreatmentId, CustomerId, WorkerId)
VALUES
(1, '2026-05-10 09:00', 30, 1, 1, 1),
(2, '2026-05-10 10:00', 45, 2, 2, 1),
(3, '2026-05-10 11:00', 60, 3, 3, 2),
(4, '2026-05-11 13:00', 90, 4, 4, 3),
(5, '2026-05-11 14:30', 20, 5, 5, 2);


