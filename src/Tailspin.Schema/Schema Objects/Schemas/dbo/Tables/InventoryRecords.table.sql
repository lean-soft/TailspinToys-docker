CREATE TABLE [dbo].[InventoryRecords] (
    [InventoryRecordID] INT            IDENTITY (1, 1) NOT NULL,
    [SKU]               NVARCHAR (50)  NOT NULL,
    [Increment]         INT            NOT NULL,
    [DateEntered]       DATETIME       NOT NULL,
    [Notes]             NVARCHAR (500) NULL
);

