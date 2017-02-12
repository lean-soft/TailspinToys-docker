ALTER TABLE [dbo].[OrderItems]
    ADD CONSTRAINT [DF_OrderItems_Discount] DEFAULT ((0)) FOR [Discount];

