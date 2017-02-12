ALTER TABLE [dbo].[Products_Related]
    ADD CONSTRAINT [FK_Products_Related_Products] FOREIGN KEY ([SKU]) REFERENCES [dbo].[Products] ([SKU]) ON DELETE NO ACTION ON UPDATE NO ACTION;

