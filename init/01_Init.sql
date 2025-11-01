USE Product
-- Create Products table
CREATE TABLE [Products] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(200) NOT NULL,
    [MainImage] NVARCHAR(2083) NOT NULL,
    [Price] DECIMAL(18,2) NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Stock] INT NULL,
    [CreatedOn] DATETIME2 NOT NULL,
    [ModifiedOn] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL,
    [RowVersion] ROWVERSION NOT NULL
);