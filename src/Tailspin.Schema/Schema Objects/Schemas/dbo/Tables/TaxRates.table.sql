CREATE TABLE [dbo].[TaxRates] (
    [TaxRateID]  INT           IDENTITY (1, 1) NOT NULL,
    [Rate]       MONEY         NOT NULL,
    [Region]     CHAR (2)      NOT NULL,
    [Country]    CHAR (2)      NOT NULL,
    [PostalCode] NVARCHAR (50) NULL
);

