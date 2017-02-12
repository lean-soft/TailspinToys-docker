ALTER TABLE [dbo].[InventoryRecords]
    ADD CONSTRAINT [FK_InventoryRecords_Products] FOREIGN KEY ([SKU]) REFERENCES [dbo].[Products] ([SKU]) ON DELETE NO ACTION ON UPDATE NO ACTION;

