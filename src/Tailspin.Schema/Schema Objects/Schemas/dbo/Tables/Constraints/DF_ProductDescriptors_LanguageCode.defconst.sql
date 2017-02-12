ALTER TABLE [dbo].[ProductDescriptors]
    ADD CONSTRAINT [DF_ProductDescriptors_LanguageCode] DEFAULT ('en') FOR [LanguageCode];

