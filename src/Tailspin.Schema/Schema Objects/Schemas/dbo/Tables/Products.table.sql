CREATE TABLE [dbo].[Products] (
    [SKU]               NVARCHAR (50)    NOT NULL,
    [DeliveryMethodID]  INT              NOT NULL,
    [ProductName]       NVARCHAR (50)    NOT NULL,
	[Blurb]				NVARCHAR (127)	 NOT NULL,
    [BasePrice]         DECIMAL (18)     NOT NULL,
    [WeightInPounds]    MONEY            NOT NULL,
    [DateAvailable]     DATETIME         NOT NULL,
    [InventoryStatusID] INT              NOT NULL,
    [EstimatedDelivery] NVARCHAR (50)    NOT NULL,
    [AllowBackOrder]    BIT              NOT NULL,
    [IsTaxable]         BIT              NOT NULL,
    [DefaultImageFile]  NVARCHAR (255)   NULL,
    [Version]           TIMESTAMP        NOT NULL,
    [AmountOnHand]      INT              NOT NULL,
    [AllowPreOrder]     BIT              NOT NULL
);

