ALTER TABLE [dbo].[CustomerEvents]
    ADD CONSTRAINT [FK_UserEvents_UseBehaviors] FOREIGN KEY ([UserBehaviorID]) REFERENCES [dbo].[CustomerBehaviors] ([UserBehaviorID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

