ALTER TABLE [dbo].[OrderItems]
    ADD CONSTRAINT [DF_ShoppingCartItem_Quantity] DEFAULT ((1)) FOR [Quantity];

