ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [DF_Products_InventoryStatusID] DEFAULT ((1)) FOR [InventoryStatusID];

