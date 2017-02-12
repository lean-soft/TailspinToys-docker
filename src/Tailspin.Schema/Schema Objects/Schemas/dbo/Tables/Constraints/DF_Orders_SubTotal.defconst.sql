ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [DF_Orders_SubTotal] DEFAULT ((0)) FOR [SubTotal];

