ALTER TABLE [dbo].[Products_CrossSell]
    ADD CONSTRAINT [FK_Products_CrossSell_Products1] FOREIGN KEY ([CrossSKU]) REFERENCES [dbo].[Products] ([SKU]) ON DELETE NO ACTION ON UPDATE NO ACTION;

