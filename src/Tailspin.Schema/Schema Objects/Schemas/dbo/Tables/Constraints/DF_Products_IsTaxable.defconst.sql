ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_IsTaxable] DEFAULT ((1)) FOR [IsTaxable];

