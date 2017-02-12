ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_UnitPrice] DEFAULT ((0)) FOR [BasePrice];

