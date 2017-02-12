ALTER TABLE [dbo].[Transactions]
    ADD CONSTRAINT [DF_Transactions_Amount] DEFAULT ((0)) FOR [Amount];

