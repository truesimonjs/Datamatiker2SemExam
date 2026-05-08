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

CREATE TABLE [OpeningHours] (
[Id] integer PRIMARY KEY,
[Day] nvarchar(250),
[StartTime] nvarchar(250) Null,
[EndTime] nvarchar(250) NULL,
[Open] bit
)


INSERT INTO [Treatment] (id, Price, Duration)
VALUES (1, 200, 30);

INSERT INTO [Treatment] (id, Price, Duration)
VALUES (2, 300, 45);

INSERT INTO [Treatment] (id, Price, Duration)
VALUES (3, 400, 60);

