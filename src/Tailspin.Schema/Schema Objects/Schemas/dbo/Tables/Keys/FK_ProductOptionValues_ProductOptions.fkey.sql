ALTER TABLE [dbo].[ProductOptionValues]
    ADD CONSTRAINT [FK_ProductOptionValues_ProductOptions] FOREIGN KEY ([OptionID]) REFERENCES [dbo].[ProductOptions] ([OptionID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

