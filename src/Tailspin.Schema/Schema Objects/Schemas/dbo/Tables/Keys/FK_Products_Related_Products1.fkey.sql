ALTER TABLE [dbo].[Products_Related]
    ADD CONSTRAINT [FK_Products_Related_Products1] FOREIGN KEY ([RelatedSKU]) REFERENCES [dbo].[Products] ([SKU]) ON DELETE NO ACTION ON UPDATE NO ACTION;

