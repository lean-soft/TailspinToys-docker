ALTER TABLE [dbo].[ProductDescriptors]
    ADD CONSTRAINT [DF_ProductDescriptors_IsDefault] DEFAULT ((0)) FOR [IsDefault];

