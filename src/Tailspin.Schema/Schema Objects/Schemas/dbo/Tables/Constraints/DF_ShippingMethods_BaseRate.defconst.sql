ALTER TABLE [dbo].[ShippingMethods]
    ADD CONSTRAINT [DF_ShippingMethods_BaseRate] DEFAULT ((0)) FOR [BaseRate];

