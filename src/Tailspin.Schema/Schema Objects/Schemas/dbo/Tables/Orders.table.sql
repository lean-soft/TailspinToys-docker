CREATE TABLE [dbo].[Orders] (
    [OrderID]           UNIQUEIDENTIFIER NOT NULL,
    [OrderNumber]       NVARCHAR (50)    NULL,
    [UserName]          NVARCHAR (50)    NOT NULL,
    [UserLanguageCode]  CHAR (2)         NOT NULL,
    [TaxAmount]         MONEY            NOT NULL,
    [ShippingService]   NVARCHAR (50)    NULL,
    [ShippingAmount]    MONEY            NOT NULL,
    [DiscountAmount]    MONEY            NOT NULL,
    [DiscountReason]    NVARCHAR (50)    NULL,
    [ShippingAddressID] INT              NULL,
    [BillingAddressID]  INT              NULL,
    [DateShipped]       DATETIME         NULL,
    [TrackingNumber]    NVARCHAR (50)    NULL,
    [EstimatedDelivery] DATETIME         NULL,
    [SubTotal]          MONEY            NOT NULL,
    [OrderStatusID]     INT              NOT NULL,
    [CreatedOn]         DATETIME         NOT NULL,
    [ExecutedOn]        DATETIME         NULL,
    [ModifiedOn]        DATETIME         NOT NULL,
    [Version]           TIMESTAMP        NOT NULL
);

