CREATE TABLE [dbo].[ProductOptionValues] (
    [OptionValueID] INT            IDENTITY (1, 1) NOT NULL,
    [OptionID]      INT            NOT NULL,
    [Description]   NVARCHAR (255) NOT NULL
);

