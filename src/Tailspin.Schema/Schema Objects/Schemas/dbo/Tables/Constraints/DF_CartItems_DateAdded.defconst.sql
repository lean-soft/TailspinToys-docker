ALTER TABLE [dbo].[CartItems]
    ADD CONSTRAINT [DF_CartItems_DateAdded] DEFAULT (getdate()) FOR [DateAdded];

