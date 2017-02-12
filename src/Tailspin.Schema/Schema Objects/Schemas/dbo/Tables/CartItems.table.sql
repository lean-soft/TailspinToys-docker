CREATE TABLE [dbo].[CartItems] (
    [SKU]            NVARCHAR (50)  NOT NULL,
    [UserName]       NVARCHAR (50)  NOT NULL,
    [Quantity]       INT            NOT NULL,
    [DateAdded]      DATETIME       NOT NULL,
    [DiscountAmount] DECIMAL (18)   NOT NULL,
    [DiscountReason] NVARCHAR (255) NULL
);

