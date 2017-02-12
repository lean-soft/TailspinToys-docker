ALTER TABLE [dbo].[ShippingMethods]
    ADD CONSTRAINT [DF_ShippingMethods_DaysToDeliver] DEFAULT ((2)) FOR [DaysToDeliver];

