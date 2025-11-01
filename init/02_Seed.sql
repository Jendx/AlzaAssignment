USE Product

-- Insert dummy data
INSERT INTO Products ([Id], [Name], [MainImage], [Price], [Description], [Stock], [CreatedOn], [ModifiedOn], [CreatedBy])
VALUES
    (NEWID(), 'Laptop', 'https://example.com/images/laptop.png', 1299.99, 'High-end gaming laptop', 10, SYSUTCDATETIME(), SYSUTCDATETIME(), 'Seeder'),
    (NEWID(), 'Smartphone', 'https://example.com/images/smartphone.png', 799.50, 'Latest model smartphone', 25, SYSUTCDATETIME(), SYSUTCDATETIME(), 'Seeder'),
    (NEWID(), 'Wireless Mouse', 'https://example.com/images/mouse.png', 49.99, 'Ergonomic wireless mouse', 100, SYSUTCDATETIME(), SYSUTCDATETIME(), 'Seeder');
