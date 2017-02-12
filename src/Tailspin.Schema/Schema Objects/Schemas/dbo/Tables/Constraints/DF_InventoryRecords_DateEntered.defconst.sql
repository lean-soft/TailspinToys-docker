ALTER TABLE [dbo].[InventoryRecords]
    ADD CONSTRAINT [DF_InventoryRecords_DateEntered] DEFAULT (getdate()) FOR [DateEntered];

