CREATE TABLE [dbo].[Addresses] (
    [AddressID]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName]        NVARCHAR (50)  NOT NULL,
    [FirstName]       NVARCHAR (50)  NOT NULL,
    [LastName]        NVARCHAR (50)  NOT NULL,
    [Email]           NVARCHAR (50)  NOT NULL,
    [Street1]         NVARCHAR (50)  NOT NULL,
    [Street2]         NVARCHAR (50)  NULL,
    [City]            NVARCHAR (150) NOT NULL,
    [StateOrProvince] NVARCHAR (50)  NOT NULL,
    [Zip]             NVARCHAR (50)  NOT NULL,
    [Country]         NVARCHAR (50)  NOT NULL,
    [Latitude]        NVARCHAR (50)  NULL,
    [Longitude]       NVARCHAR (50)  NULL,
    [IsDefault]       BIT            NOT NULL
);

