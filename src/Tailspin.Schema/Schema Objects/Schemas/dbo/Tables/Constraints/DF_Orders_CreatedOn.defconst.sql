ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [DF_Orders_CreatedOn] DEFAULT (getdate()) FOR [CreatedOn];

