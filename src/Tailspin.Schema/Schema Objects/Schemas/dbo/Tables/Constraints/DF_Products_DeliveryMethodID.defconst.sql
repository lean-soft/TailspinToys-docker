ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_DeliveryMethodID] DEFAULT ((1)) FOR [DeliveryMethodID];

