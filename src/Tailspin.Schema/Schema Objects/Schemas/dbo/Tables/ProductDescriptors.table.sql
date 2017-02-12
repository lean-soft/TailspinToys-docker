CREATE TABLE [dbo].[ProductDescriptors] (
    [DescriptorID] INT             IDENTITY (1, 1) NOT NULL,
    [SKU]          NVARCHAR (50)   NOT NULL,
    [LanguageCode] CHAR (2)        NOT NULL,
    [Title]        NVARCHAR (50)   NOT NULL,
    [IsDefault]    BIT             NOT NULL,
    [Body]         NVARCHAR (2500) NOT NULL
);

