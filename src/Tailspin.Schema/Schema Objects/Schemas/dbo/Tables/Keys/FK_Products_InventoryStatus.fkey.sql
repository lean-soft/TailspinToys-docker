ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [FK_Products_InventoryStatus] FOREIGN KEY ([InventoryStatusID]) REFERENCES [dbo].[InventoryStatus] ([InventoryStatusID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

