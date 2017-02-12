ALTER TABLE [dbo].[Categories_Products]
    ADD CONSTRAINT [FK_Categories_Products_Categories] FOREIGN KEY ([CategoryCode]) REFERENCES [dbo].[Categories] ([Code]) ON DELETE NO ACTION ON UPDATE NO ACTION;

