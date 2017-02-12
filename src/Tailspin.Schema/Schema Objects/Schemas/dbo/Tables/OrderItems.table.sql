CREATE TABLE [dbo].[OrderItems] (
    [OrderID]                UNIQUEIDENTIFIER NOT NULL,
    [SKU]                    NVARCHAR (50)    NOT NULL,
    [Quantity]               INT              NOT NULL,
    [DateAdded]              DATETIME         NOT NULL,
    [LineItemPrice]          DECIMAL (18)     NOT NULL,
    [Discount]               DECIMAL (18)     NOT NULL,
    [DiscountReason]         NVARCHAR (255)   NULL,
    [Version]                TIMESTAMP        NOT NULL,
    [LineItemWeightInPounds] DECIMAL (18)     NOT NULL
);

