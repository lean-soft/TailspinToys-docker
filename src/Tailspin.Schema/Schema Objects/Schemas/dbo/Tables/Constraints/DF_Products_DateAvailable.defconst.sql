ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_DateAvailable] DEFAULT ('1/1/2003') FOR [DateAvailable];

