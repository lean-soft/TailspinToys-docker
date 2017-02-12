ALTER TABLE [dbo].[ProductImages]
    ADD CONSTRAINT [FK_ProductImages_Products] FOREIGN KEY ([SKU]) REFERENCES [dbo].[Products] ([SKU]) ON DELETE NO ACTION ON UPDATE NO ACTION;

