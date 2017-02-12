ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [FK_Products_DeliveryMethod] FOREIGN KEY ([DeliveryMethodID]) REFERENCES [dbo].[DeliveryMethod] ([DeliveryMethodID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

