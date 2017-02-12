ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_EstimatedDelivery] DEFAULT (N'3-5 Days') FOR [EstimatedDelivery];

