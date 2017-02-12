ALTER TABLE [dbo].[Transactions]
    ADD CONSTRAINT [DF_Transactions_TransactionDate] DEFAULT (getdate()) FOR [TransactionDate];

