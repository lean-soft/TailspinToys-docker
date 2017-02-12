ALTER TABLE [dbo].[Addresses]
    ADD CONSTRAINT [DF_Addresses_IsDefault] DEFAULT ((1)) FOR [IsDefault];

