CREATE TABLE [dbo].[ProductOptions] (
    [OptionID]     INT            IDENTITY (1, 1) NOT NULL,
    [Description]  NVARCHAR (50)  NOT NULL,
    [LanguageCode] CHAR (2)       NOT NULL,
    [DisplayID]    INT            NOT NULL,
    [Prompt]       NVARCHAR (255) NOT NULL
);

