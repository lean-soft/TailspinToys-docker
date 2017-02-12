ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_OrderStatus] FOREIGN KEY ([OrderStatusID]) REFERENCES [dbo].[OrderStatus] ([OrderStatusID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

