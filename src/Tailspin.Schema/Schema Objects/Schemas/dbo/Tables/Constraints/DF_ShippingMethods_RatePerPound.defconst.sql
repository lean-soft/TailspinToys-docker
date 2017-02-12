ALTER TABLE [dbo].[ShippingMethods]
    ADD CONSTRAINT [DF_ShippingMethods_RatePerPound] DEFAULT ((0)) FOR [RatePerPound];

