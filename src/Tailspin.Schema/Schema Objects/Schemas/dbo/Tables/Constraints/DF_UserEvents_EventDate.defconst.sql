ALTER TABLE [dbo].[CustomerEvents]
    ADD CONSTRAINT [DF_UserEvents_EventDate] DEFAULT (getdate()) FOR [EventDate];

