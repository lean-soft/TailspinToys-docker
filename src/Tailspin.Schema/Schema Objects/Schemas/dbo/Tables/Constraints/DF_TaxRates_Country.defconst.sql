ALTER TABLE [dbo].[TaxRates]
    ADD CONSTRAINT [DF_TaxRates_Country] DEFAULT ('US') FOR [Country];

