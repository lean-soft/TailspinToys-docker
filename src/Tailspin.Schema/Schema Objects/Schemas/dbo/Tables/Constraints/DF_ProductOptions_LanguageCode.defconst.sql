ALTER TABLE [dbo].[ProductOptions]
    ADD CONSTRAINT [DF_ProductOptions_LanguageCode] DEFAULT ('en') FOR [LanguageCode];

