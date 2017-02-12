ALTER TABLE [dbo].[OrderItems]
    ADD CONSTRAINT [DF_OrderItems_LineItemWeightInPounds] DEFAULT ((5)) FOR [LineItemWeightInPounds];

