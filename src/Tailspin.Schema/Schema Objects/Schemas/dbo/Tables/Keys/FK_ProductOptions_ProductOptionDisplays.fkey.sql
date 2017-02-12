ALTER TABLE [dbo].[ProductOptions]
    ADD CONSTRAINT [FK_ProductOptions_ProductOptionDisplays] FOREIGN KEY ([DisplayID]) REFERENCES [dbo].[ProductOptionDisplays] ([OptionDisplayID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

