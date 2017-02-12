ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_AllowBackOrder] DEFAULT ((1)) FOR [AllowBackOrder];

