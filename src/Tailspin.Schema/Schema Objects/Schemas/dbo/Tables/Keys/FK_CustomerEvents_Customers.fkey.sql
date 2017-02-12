ALTER TABLE [dbo].[CustomerEvents]
    ADD CONSTRAINT [FK_CustomerEvents_Customers] FOREIGN KEY ([UserName]) REFERENCES [dbo].[Customers] ([UserName]) ON DELETE NO ACTION ON UPDATE NO ACTION;

