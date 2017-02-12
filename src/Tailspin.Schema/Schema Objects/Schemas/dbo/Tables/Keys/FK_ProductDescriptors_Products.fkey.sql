ALTER TABLE [dbo].[ProductDescriptors]
    ADD CONSTRAINT [FK_ProductDescriptors_Products] FOREIGN KEY ([SKU]) REFERENCES [dbo].[Products] ([SKU]) ON DELETE NO ACTION ON UPDATE NO ACTION;

