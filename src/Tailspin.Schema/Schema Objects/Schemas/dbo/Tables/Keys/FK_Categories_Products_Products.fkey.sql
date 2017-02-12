ALTER TABLE [dbo].[Categories_Products]
    ADD CONSTRAINT [FK_Categories_Products_Products] FOREIGN KEY ([SKU]) REFERENCES [dbo].[Products] ([SKU]) ON DELETE NO ACTION ON UPDATE NO ACTION;

