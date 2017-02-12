ALTER TABLE [dbo].[Transactions]
    ADD CONSTRAINT [FK_Transactions_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

