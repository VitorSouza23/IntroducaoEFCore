IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201110201542_PrimeiraMigracao')
BEGIN
    CREATE TABLE [Customers] (
        [Id] int NOT NULL IDENTITY,
        [Name] VARCHAR(80) NOT NULL,
        [Phone] CHAR(11) NULL,
        [CEP] CHAR(8) NOT NULL,
        [UF] CHAR(2) NOT NULL,
        [City] nvarchar(60) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201110201542_PrimeiraMigracao')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [BarCode] VARCHAR(14) NOT NULL,
        [Description] VARCHAR(60) NULL,
        [Value] decimal(18,2) NOT NULL,
        [ProductType] nvarchar(max) NOT NULL,
        [Actived] bit NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201110201542_PrimeiraMigracao')
BEGIN
    CREATE TABLE [Order] (
        [Id] int NOT NULL IDENTITY,
        [CustomerId] int NOT NULL,
        [StartIn] datetime2 NOT NULL DEFAULT (GETDATE()),
        [EndIn] datetime2 NOT NULL,
        [FreightType] int NOT NULL,
        [OrderState] nvarchar(max) NOT NULL,
        [Observation] VARCHAR(512) NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Order_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201110201542_PrimeiraMigracao')
BEGIN
    CREATE TABLE [OrderItems] (
        [Id] int NOT NULL IDENTITY,
        [OrderId] int NOT NULL,
        [ProductId] int NOT NULL,
        [Amount] int NOT NULL DEFAULT 1,
        [Value] decimal(18,2) NOT NULL,
        [Discount] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderItems_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201110201542_PrimeiraMigracao')
BEGIN
    CREATE INDEX [idx_customern_phone] ON [Customers] ([Phone]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201110201542_PrimeiraMigracao')
BEGIN
    CREATE INDEX [IX_Order_CustomerId] ON [Order] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201110201542_PrimeiraMigracao')
BEGIN
    CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201110201542_PrimeiraMigracao')
BEGIN
    CREATE INDEX [IX_OrderItems_ProductId] ON [OrderItems] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201110201542_PrimeiraMigracao')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201110201542_PrimeiraMigracao', N'5.0.0');
END;
GO

COMMIT;
GO

