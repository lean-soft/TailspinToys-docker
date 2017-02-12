ALTER TABLE [dbo].[CartItems]
    ADD CONSTRAINT [FK_CartItems_Customers] FOREIGN KEY ([UserName]) REFERENCES [dbo].[Customers] ([UserName]) ON DELETE NO ACTION ON UPDATE NO ACTION;

