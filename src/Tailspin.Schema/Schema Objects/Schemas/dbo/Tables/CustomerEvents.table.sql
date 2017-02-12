CREATE TABLE [dbo].[CustomerEvents] (
    [EventID]        INT              IDENTITY (1, 1) NOT NULL,
    [UserBehaviorID] INT              NOT NULL,
    [UserName]       NVARCHAR (50)    NOT NULL,
    [EventDate]      DATETIME         NOT NULL,
    [IP]             NVARCHAR (50)    NOT NULL,
    [SKU]            NVARCHAR (50)    NULL,
    [CategoryID]     INT              NULL,
    [OrderID]        UNIQUEIDENTIFIER NULL
);

