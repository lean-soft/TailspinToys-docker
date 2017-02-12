ALTER TABLE [dbo].[CartItems]
    ADD CONSTRAINT [DF_CartItems_DiscountAmount] DEFAULT ((0)) FOR [DiscountAmount];

