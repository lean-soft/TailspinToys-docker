ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_Addresses] FOREIGN KEY ([ShippingAddressID]) REFERENCES [dbo].[Addresses] ([AddressID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

