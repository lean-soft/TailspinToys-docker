ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [DF_Orders_ShippingAmount] DEFAULT ((0)) FOR [ShippingAmount];

