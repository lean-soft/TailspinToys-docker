ALTER TABLE [dbo].[Customers]
    ADD CONSTRAINT [DF_Customers_Last] DEFAULT (N'en') FOR [Last];

