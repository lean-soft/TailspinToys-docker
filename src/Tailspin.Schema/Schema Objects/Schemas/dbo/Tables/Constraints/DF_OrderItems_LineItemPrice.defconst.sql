ALTER TABLE [dbo].[OrderItems]
    ADD CONSTRAINT [DF_OrderItems_LineItemPrice] DEFAULT ((0)) FOR [LineItemPrice];

