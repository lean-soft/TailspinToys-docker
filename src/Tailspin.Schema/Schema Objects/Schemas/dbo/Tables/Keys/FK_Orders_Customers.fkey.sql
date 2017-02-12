ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([UserName]) REFERENCES [dbo].[Customers] ([UserName]) ON DELETE NO ACTION ON UPDATE NO ACTION;

