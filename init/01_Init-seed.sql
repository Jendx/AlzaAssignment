USE Product
-- Create Products table
IF (NOT EXISTS (SELECT *
            FROM INFORMATION_SCHEMA.TABLES
            WHERE TABLE_NAME = 'Products'))
BEGIN
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
    
    INSERT INTO Products ([Id], [Name], [MainImage], [Price], [Description], [Stock], [CreatedOn], [ModifiedOn], [CreatedBy])
    VALUES
        (NEWID(), 'Laptop', 'https://example.com/images/laptop.png', 1299.99, 'High-end gaming laptop', 10, SYSUTCDATETIME(), SYSUTCDATETIME(), 'Seeder'),
        (NEWID(), 'Smartphone', 'https://example.com/images/smartphone.png', 799.50, 'Latest model smartphone', 25, SYSUTCDATETIME(), SYSUTCDATETIME(), 'Seeder'),
        (NEWID(), 'Wireless Mouse', 'https://example.com/images/mouse.png', 49.99, 'Ergonomic wireless mouse', 100, SYSUTCDATETIME(), SYSUTCDATETIME(), 'Seeder');
END