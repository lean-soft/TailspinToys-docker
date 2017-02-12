ALTER TABLE [dbo].[Products_CrossSell]
    ADD CONSTRAINT [FK_Products_CrossSell_Products] FOREIGN KEY ([SKU]) REFERENCES [dbo].[Products] ([SKU]) ON DELETE NO ACTION ON UPDATE NO ACTION;

