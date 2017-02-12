ALTER TABLE [dbo].[Products_Options]
    ADD CONSTRAINT [FK_Products_Options_ProductOptions] FOREIGN KEY ([OptionID]) REFERENCES [dbo].[ProductOptions] ([OptionID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

