ALTER TABLE [dbo].[OrderItems]
    ADD CONSTRAINT [DF_ShoppingCartItem_CreatedOn] DEFAULT (getdate()) FOR [DateAdded];

