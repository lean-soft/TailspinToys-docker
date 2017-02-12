ALTER TABLE [dbo].[Products_Options]
    ADD CONSTRAINT [FK_Products_Options_ProductOptionValues] FOREIGN KEY ([OptionValueID]) REFERENCES [dbo].[ProductOptionValues] ([OptionValueID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

