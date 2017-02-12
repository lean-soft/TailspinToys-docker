CREATE TABLE [dbo].[ProductImages] (
    [ProductImageID] INT            IDENTITY (1, 1) NOT NULL,
    [SKU]            NVARCHAR (50)  NOT NULL,
    [ThumbUrl]       NVARCHAR (150) NOT NULL,
    [FullImageUrl]   NVARCHAR (150) NOT NULL
);

