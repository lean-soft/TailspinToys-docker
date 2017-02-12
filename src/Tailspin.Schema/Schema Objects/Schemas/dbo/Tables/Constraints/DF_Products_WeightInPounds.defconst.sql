ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_WeightInPounds] DEFAULT ((0)) FOR [WeightInPounds];

