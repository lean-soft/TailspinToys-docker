CREATE TABLE [dbo].[ShippingMethods] (
    [ShippingMethodID]  INT           NOT NULL,
    [Carrier]           NVARCHAR (50) NOT NULL,
    [ServiceName]       NVARCHAR (50) NOT NULL,
    [RatePerPound]      DECIMAL (18)  NOT NULL,
    [BaseRate]          DECIMAL (18)  NOT NULL,
    [EstimatedDelivery] NVARCHAR (50) NULL,
    [DaysToDeliver]     INT           NOT NULL
);

