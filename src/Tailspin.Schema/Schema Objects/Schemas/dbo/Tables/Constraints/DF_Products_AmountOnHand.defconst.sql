ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_AmountOnHand] DEFAULT ((10)) FOR [AmountOnHand];

