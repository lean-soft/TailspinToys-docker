ALTER TABLE [dbo].[Products_Options]
    ADD CONSTRAINT [FK_Products_Options_Products] FOREIGN KEY ([SKU]) REFERENCES [dbo].[Products] ([SKU]) ON DELETE NO ACTION ON UPDATE NO ACTION;

