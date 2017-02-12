ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [DF_Orders_DiscountAmount] DEFAULT ((0)) FOR [DiscountAmount];

