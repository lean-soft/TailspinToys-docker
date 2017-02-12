ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_Addresses1] FOREIGN KEY ([BillingAddressID]) REFERENCES [dbo].[Addresses] ([AddressID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

