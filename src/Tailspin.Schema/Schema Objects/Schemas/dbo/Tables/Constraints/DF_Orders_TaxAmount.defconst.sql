ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [DF_Orders_TaxAmount] DEFAULT ((0)) FOR [TaxAmount];

