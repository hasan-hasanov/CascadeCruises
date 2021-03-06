USE [master];
GO

CREATE DATABASE [CascadeCruises];

GO

USE [CascadeCruises];

CREATE TABLE [dbo].[Ships]
([Id]         [INT] IDENTITY(1,1) NOT NULL,
 [Name]       [NVARCHAR](250) NOT NULL,
 [Registry]   [NVARCHAR](250) NOT NULL,
 [CreateDate] [DATETIME] NOT NULL,
 CONSTRAINT [PK_Ships] PRIMARY KEY CLUSTERED([Id] ASC)
);

CREATE TABLE [dbo].[Cruises]
([Id]           [INT] IDENTITY(1,1) NOT NULL,
 [Name]         [NVARCHAR](250) NOT NULL,
 [ShipId]       [INT] NOT NULL,
 CONSTRAINT [PK_Cruises] PRIMARY KEY CLUSTERED([Id] ASC),
 CONSTRAINT [FK_Cruises_Ships] FOREIGN KEY([ShipId]) REFERENCES [dbo].[Ships]([Id])
);

CREATE TABLE [dbo].[Ports]
([Id]   [INT] IDENTITY(1,1) NOT NULL,
 [City] [NVARCHAR](250) NOT NULL,
 CONSTRAINT [PK_Ports] PRIMARY KEY CLUSTERED([Id] ASC)
);

CREATE TABLE [dbo].[CabinClasses]
([Id]    [INT] IDENTITY(1,1) NOT NULL,
 [Class] [NVARCHAR](250) NOT NULL,
 CONSTRAINT [PK_CabinClasses] PRIMARY KEY CLUSTERED([Id] ASC)
);

CREATE TABLE [dbo].[Cabins]
([Id]                [INT] IDENTITY(1,1) NOT NULL,
 [MaxNumberOfPeople] [INT] NOT NULL,
 [ShipId]            [INT] NOT NULL,
 [ClassId]           [INT] NOT NULL,
 [Number]            [INT] NOT NULL,
 [MaxPrice]          [DECIMAL](8,3) NOT NULL,
 CONSTRAINT [PK_Cabins] PRIMARY KEY CLUSTERED([Id] ASC),
 CONSTRAINT [FK_Cabins_CabinClasses] FOREIGN KEY([ClassId]) REFERENCES [dbo].[CabinClasses]([Id]),
 CONSTRAINT [FK_Cabins_Ships] FOREIGN KEY([ShipId]) REFERENCES [dbo].[Ships]([Id])
);

CREATE TABLE [dbo].[CruisePortStops]
([Id]            [INT] IDENTITY(1,1) NOT NULL,
 [ArrivalDate]   [DATETIME] NOT NULL,
 [DepartureDate] [DATETIME] NOT NULL,
 [CruiseId]      [INT] NOT NULL,
 [PortId]        [INT] NOT NULL,
 CONSTRAINT [PK_CruisePortStops] PRIMARY KEY CLUSTERED([Id] ASC),
 CONSTRAINT [FK_CruisePortStops_Cruises] FOREIGN KEY([CruiseId]) REFERENCES [dbo].[Cruises]([Id]),
 CONSTRAINT [FK_CruisePortStops_Ports] FOREIGN KEY([PortId]) REFERENCES [dbo].[Ports]([Id])
);

CREATE TABLE [dbo].[Passengers]
([Id]          [INT] IDENTITY(1,1) NOT NULL,
 [Name]        [NVARCHAR](250) NOT NULL,
 [Surname]     [NVARCHAR](250) NULL,
 [LastName]    [NVARCHAR](250) NOT NULL,
 [Address]     [NVARCHAR](250) NOT NULL,
 [PIN]         [NVARCHAR](20) NOT NULL,
 [DateOfBirth] [DATETIME] NOT NULL,
 CONSTRAINT [PK_Passengers] PRIMARY KEY CLUSTERED([Id] ASC)
);

CREATE TABLE [dbo].[TravelAgents]
([Id]       [INT] IDENTITY(1,1) NOT NULL,
 [Name]     [NVARCHAR](250) NOT NULL,
 [Surname]  [NVARCHAR](250) NULL,
 [LastName] [NVARCHAR](250) NOT NULL,
 [PIN]      [NVARCHAR](20) NOT NULL,
 [Address]  [NVARCHAR](250) NOT NULL,
 [Phone]    [NVARCHAR](20) NOT NULL,
 [Agency]   [NVARCHAR](250) NOT NULL,
 CONSTRAINT [PK_TravelAgents] PRIMARY KEY CLUSTERED([Id] ASC)
);

CREATE TABLE [dbo].[CruiseReservations]
([Id]                         [INT] IDENTITY(1,1) NOT NULL,
 [TravelAgentId]              [INT] NOT NULL,
 [PercentCommissionPerPerson] [FLOAT] NOT NULL,
 [CruiseId]                   [INT] NOT NULL,
 CONSTRAINT [PK_CruiseReservations] PRIMARY KEY CLUSTERED([Id] ASC),
 CONSTRAINT [FK_CruiseReservations_Cruises] FOREIGN KEY([CruiseId]) REFERENCES [dbo].[Cruises]([Id]),
 CONSTRAINT [FK_CruiseReservations_TravelAgents] FOREIGN KEY([TravelAgentId]) REFERENCES [dbo].[TravelAgents]([Id])
);

CREATE TABLE [dbo].[PassengerReservations]
([Id]            [INT] IDENTITY(1,1) NOT NULL,
 [PassengerId]   [INT] NOT NULL,
 [Price]         [DECIMAL](8,3) NOT NULL,
 [CabinId]       [INT] NOT NULL,
 [Date]          [DATETIME] NOT NULL,
 [CruiseId]      [INT] NOT NULL,
 [TravelAgentId] [INT] NOT NULL,
 CONSTRAINT [PK_PassengerReservations] PRIMARY KEY CLUSTERED([Id] ASC),
 CONSTRAINT [FK_PassengerReservations_Cabins] FOREIGN KEY([CabinId]) REFERENCES [dbo].[Cabins]([Id]),
 CONSTRAINT [FK_PassengerReservations_Passengers] FOREIGN KEY([PassengerId]) REFERENCES [dbo].[Passengers]([Id]),
 CONSTRAINT [FK_PassengerReservations_Cruises] FOREIGN KEY([CruiseId]) REFERENCES [dbo].[Cruises]([Id]),
 CONSTRAINT [FK_PassengerReservations_TravelAgents] FOREIGN KEY([TravelAgentId]) REFERENCES [dbo].[TravelAgents]([Id])
);
GO

CREATE PROCEDURE SP_SELECT_PASSANGER_AGE_ABOVE_SIXTY @CruiseId INT
AS
    BEGIN
        SELECT p.[Id],
               p.[Name],
               p.[Surname],
               p.[LastName],
               p.[Address],
               p.[PIN],
               p.[DateOfBirth]
        FROM PassengerReservations pr
             JOIN Passengers p ON pr.PassengerId = p.Id
        WHERE pr.CruiseId = @CruiseId
              AND DATEDIFF(year,p.DateOfBirth,GETDATE()) > 60;
    END;
GO

CREATE PROCEDURE SP_SELECT_SHIPS_BY_MAX_ROOMS_COUNT
AS
    BEGIN
        SELECT s.Id,
		       s.Name,
               s.Registry,
               s.CreateDate,
               COUNT(c.ShipId) AS RoomsCount,
               MAX(CASE
                       WHEN c.ClassId = 1
                       THEN c.MaxPrice
                   END) AS FirstClassRoomPrice,
               MAX(CASE
                       WHEN c.ClassId = 2
                       THEN c.MaxPrice
                   END) AS SecondClassRoomPrice,
               MAX(CASE
                       WHEN c.ClassId = 3
                       THEN c.MaxPrice
                   END) AS ThirdClassRoomPrice
        FROM Cabins c
             JOIN Ships s ON c.ShipId = s.id
        GROUP BY s.Id,
		         s.Name,
                 s.Registry,
                 s.CreateDate
        ORDER BY RoomsCount DESC;
    END;
GO

CREATE PROCEDURE SP_SELECT_SHIPS_INFORMATION_WITH_PORTS
AS
    BEGIN
        DECLARE @FirstAndLastPortStops TABLE
        (CruiseId      INT,
         ArrivalDate   DATETIME,
         DepartureDate DATETIME,
         PortId        INT,
         PortCity      NVARCHAR(250),
         LastPortId    INT,
         LastPortCity  NVARCHAR(250)
        );

        DECLARE @PassengersForCruise TABLE
        (CruiseId       INT,
         PassengerCount INT
        );

        INSERT INTO @PassengersForCruise
        (CruiseId,
         PassengerCount
        )
               SELECT pr.CruiseId,
                      COUNT(pr.PassengerId)
               FROM PassengerReservations pr
               GROUP BY pr.CruiseId;

        WITH Cte
             AS (SELECT *,
                        RnAsc=ROW_NUMBER() OVER(PARTITION BY CruiseId
                        ORDER BY ArrivalDate),
                        RnDesc=ROW_NUMBER() OVER(PARTITION BY CruiseId
                        ORDER BY ArrivalDate DESC)
                 FROM CruisePortStops)
             INSERT INTO @FirstAndLastPortStops
             (CruiseId,
              ArrivalDate,
              DepartureDate,
              PortId,
              PortCity,
              LastPortId,
              LastPortCity
             )
                    SELECT cps.CruiseId,
                           cps.ArrivalDate,
                           cps.DepartureDate,
                           cps.PortId,
                           (
                               SELECT City FROM Ports p WHERE p.Id = cps.PortId
                           ),
                           (
                               SELECT PortId
                               FROM Cte x
                               WHERE x.CruiseId = cps.CruiseId
                                     AND x.RnDesc = 1
                           ) AS LastPortId,
                           (
                               SELECT City
                               FROM Ports p
                               WHERE p.Id =
                                     (
                                         SELECT TOP 1 PortId
                                         FROM Cte x
                                         WHERE x.CruiseId = cps.CruiseId
                                               AND x.RnDesc = 1
                                     )
                           ) AS LastPortCity
                    FROM Cte cps
                    WHERE RnAsc = 1
                    GROUP BY cps.CruiseId,
                             cps.ArrivalDate,
                             cps.DepartureDate,
                             cps.PortId
                    ORDER BY cps.CruiseId,
                             cps.ArrivalDate;

        SELECT s.Id,
		       s.Name,
               s.CreateDate,
               s.Registry,
               COUNT(CASE
                         WHEN c.ClassId = 1
                         THEN c.Id
                     END) AS FirstClassRoomCount,
               COUNT(CASE
                         WHEN c.ClassId = 2
                         THEN c.Id
                     END) AS SecondClassRoomCount,
               COUNT(CASE
                         WHEN c.ClassId = 3
                         THEN c.Id
                     END) AS ThirdClassRoomCount,
               MIN(ps.ArrivalDate) AS FirstStopDate,
               MAX(ps.ArrivalDate) AS LasStopDate,
               ps.PortCity,
               ps.LastPortCity,
               pfc.PassengerCount
        FROM Ships s
             JOIN Cruises cr ON s.Id = cr.ShipId
             JOIN @FirstAndLastPortStops ps ON ps.CruiseId = cr.Id
             JOIN Cabins c ON c.ShipId = s.Id
             JOIN Ports p ON p.Id = ps.PortId
             JOIN @PassengersForCruise pfc ON pfc.CruiseId = cr.Id
        GROUP BY s.Id,
		         s.Name,
                 s.Registry,
                 s.CreateDate,
                 ps.ArrivalDate,
                 ps.PortCity,
                 ps.LastPortCity,
                 pfc.PassengerCount
        ORDER BY PassengerCount DESC,
                 FirstStopDate DESC;
    END;
GO

CREATE PROCEDURE SP_SELECT_CRUISE_PROFITS
AS
    BEGIN
        DECLARE @MiddlePortStops TABLE
        (CruiseId  INT,
         PortCount INT
        );

        DECLARE @PassangerProfit TABLE
        (CruiseId        INT,
         PassangerProfit INT
        );

        WITH Cte
             AS (SELECT *,
                        RnAsc=ROW_NUMBER() OVER(PARTITION BY CruiseId
                        ORDER BY ArrivalDate),
                        RnDesc=ROW_NUMBER() OVER(PARTITION BY CruiseId
                        ORDER BY ArrivalDate DESC)
                 FROM CruisePortStops)
             INSERT INTO @MiddlePortStops
             (CruiseId,
              PortCount
             )
                    SELECT cps.CruiseId,
                           COUNT(cps.Id)
                    FROM Cte cps
                    WHERE RnAsc <> 1
                          AND RnDesc <> 1
                    GROUP BY cps.CruiseId
                    ORDER BY cps.CruiseId;

        INSERT INTO @PassangerProfit
        (CruiseId,
         PassangerProfit
        )
               SELECT cr.Id,
                      SUM(pr.Price) AS PassangerProfit
               FROM Cruises cr
                    JOIN PassengerReservations pr ON cr.Id = pr.CruiseId
               GROUP BY cr.Id;

        SELECT c.Name AS CruiseName,
               pp.PassangerProfit AS PassangerProfit,
               mps.PortCount * 10000 AS FuelCost,
               pp.PassangerProfit - (mps.PortCount * 10000) AS Profit
        FROM @MiddlePortStops mps
             JOIN @PassangerProfit pp ON mps.CruiseId = pp.CruiseId
             JOIN Cruises c ON mps.CruiseId = c.Id
        ORDER BY Profit DESC;
    END;