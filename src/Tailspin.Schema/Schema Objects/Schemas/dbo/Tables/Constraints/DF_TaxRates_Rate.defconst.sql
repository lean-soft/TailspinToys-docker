ALTER TABLE [dbo].[TaxRates]
    ADD CONSTRAINT [DF_TaxRates_Rate] DEFAULT ((0)) FOR [Rate];

