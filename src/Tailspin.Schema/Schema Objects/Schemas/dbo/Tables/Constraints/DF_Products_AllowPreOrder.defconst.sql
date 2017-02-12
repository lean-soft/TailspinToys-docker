ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_AllowPreOrder] DEFAULT ((1)) FOR [AllowPreOrder];

