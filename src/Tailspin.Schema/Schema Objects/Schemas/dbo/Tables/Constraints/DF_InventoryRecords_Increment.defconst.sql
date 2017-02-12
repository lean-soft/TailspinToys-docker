ALTER TABLE [dbo].[InventoryRecords]
    ADD CONSTRAINT [DF_InventoryRecords_Increment] DEFAULT ((0)) FOR [Increment];

