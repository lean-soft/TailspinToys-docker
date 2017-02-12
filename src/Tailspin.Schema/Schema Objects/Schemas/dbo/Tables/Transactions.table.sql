CREATE TABLE [dbo].[Transactions] (
    [TransactionID]     UNIQUEIDENTIFIER NOT NULL,
    [OrderID]           UNIQUEIDENTIFIER NOT NULL,
    [TransactionDate]   DATETIME         NOT NULL,
    [Amount]            MONEY            NOT NULL,
    [AuthorizationCode] NVARCHAR (50)    NULL,
    [Notes]             NVARCHAR (50)    NULL,
    [Processor]         NVARCHAR (50)    NULL
);

