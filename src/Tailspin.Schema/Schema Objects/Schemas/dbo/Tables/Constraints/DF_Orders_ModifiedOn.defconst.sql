ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [DF_Orders_ModifiedOn] DEFAULT (getdate()) FOR [ModifiedOn];

