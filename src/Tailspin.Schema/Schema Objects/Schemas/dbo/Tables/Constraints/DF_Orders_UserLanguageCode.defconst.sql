ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [DF_Orders_UserLanguageCode] DEFAULT ('en') FOR [UserLanguageCode];

