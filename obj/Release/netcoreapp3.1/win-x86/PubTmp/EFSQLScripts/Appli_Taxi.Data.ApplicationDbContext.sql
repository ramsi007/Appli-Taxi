IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510151156_First4TableInDb')
BEGIN
    CREATE TABLE [Taxes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Discount] float NOT NULL,
        CONSTRAINT [PK_Taxes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510151156_First4TableInDb')
BEGIN
    CREATE TABLE [TypeCats] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TypeCats] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510151156_First4TableInDb')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [TypeId] int NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Categories_TypeCats_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [TypeCats] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510151156_First4TableInDb')
BEGIN
    CREATE TABLE [Produits] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [SalePrice] float NOT NULL,
        [PurchasePrice] float NOT NULL,
        [TypePS] nvarchar(max) NULL,
        [CategoryId] int NOT NULL,
        [TaxId] int NOT NULL,
        CONSTRAINT [PK_Produits] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Produits_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Produits_Taxes_TaxId] FOREIGN KEY ([TaxId]) REFERENCES [Taxes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510151156_First4TableInDb')
BEGIN
    CREATE INDEX [IX_Categories_TypeId] ON [Categories] ([TypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510151156_First4TableInDb')
BEGIN
    CREATE INDEX [IX_Produits_CategoryId] ON [Produits] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510151156_First4TableInDb')
BEGIN
    CREATE INDEX [IX_Produits_TaxId] ON [Produits] ([TaxId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210510151156_First4TableInDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210510151156_First4TableInDb', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511050540_RemoveProductTable')
BEGIN
    DROP TABLE [Produits];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511050540_RemoveProductTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210511050540_RemoveProductTable', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511051259_AddProductToDb')
BEGIN
    CREATE TABLE [Produits] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [SalePrice] float NOT NULL,
        [PurchasePrice] float NOT NULL,
        [TypePS] nvarchar(max) NULL,
        [CategoryId] int NOT NULL,
        [TaxId] int NOT NULL,
        CONSTRAINT [PK_Produits] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Produits_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Produits_Taxes_TaxId] FOREIGN KEY ([TaxId]) REFERENCES [Taxes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511051259_AddProductToDb')
BEGIN
    CREATE INDEX [IX_Produits_CategoryId] ON [Produits] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511051259_AddProductToDb')
BEGIN
    CREATE INDEX [IX_Produits_TaxId] ON [Produits] ([TaxId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511051259_AddProductToDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210511051259_AddProductToDb', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BillingAdresse] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BillingCity] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BillingCountry] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BillingName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BillingPhone] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BillingPostalCode] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BillingState] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BirthDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [EmployeeAdresse] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [EmployeeCity] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [EmployeeCountry] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [EmployeePostalCode] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FirstName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [HiringDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LastName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ShippingAdresse] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ShippingCity] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ShippingCountry] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ShippingName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ShippingPhone] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ShippingPostalCode] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ShippingState] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [UserRole] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511110806_AddApplicationUserToDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210511110806_AddApplicationUserToDb', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'Name');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [Name] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'LoginProvider');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'ProviderKey');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [ProviderKey] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'LoginProvider');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    CREATE TABLE [Contrats] (
        [Id] int NOT NULL IDENTITY,
        [Reference] nvarchar(max) NULL,
        [Path] varbinary(max) NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Contrats] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Contrats_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    CREATE TABLE [Proposals] (
        [Id] int NOT NULL IDENTITY,
        [NumProposal] nvarchar(max) NULL,
        [UserId] nvarchar(450) NULL,
        [ProposalDate] datetime2 NOT NULL,
        [ProposalTotalOrginal] float NOT NULL,
        [ProposalTotal] float NOT NULL,
        [Remise] float NOT NULL,
        [PoposalType] nvarchar(max) NULL,
        [Status] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [TransactionId] nvarchar(max) NULL,
        CONSTRAINT [PK_Proposals] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Proposals_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    CREATE TABLE [ShooppingCarts] (
        [Id] int NOT NULL IDENTITY,
        [ApplicationUserId] nvarchar(max) NULL,
        [ProduitId] int NOT NULL,
        [Count] int NOT NULL,
        [Remise] float NOT NULL,
        [Description] nvarchar(max) NULL,
        [NumProposal] nvarchar(max) NULL,
        [NumBill] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [Tax] float NOT NULL,
        [Montant] float NOT NULL,
        CONSTRAINT [PK_ShooppingCarts] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    CREATE TABLE [ProposalDetails] (
        [Id] int NOT NULL IDENTITY,
        [ProposalId] int NOT NULL,
        [ProduitId] int NOT NULL,
        [Remise] float NOT NULL,
        [Count] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [Tax] float NOT NULL,
        CONSTRAINT [PK_ProposalDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProposalDetails_Produits_ProduitId] FOREIGN KEY ([ProduitId]) REFERENCES [Produits] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProposalDetails_Proposals_ProposalId] FOREIGN KEY ([ProposalId]) REFERENCES [Proposals] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    CREATE INDEX [IX_Contrats_UserId] ON [Contrats] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    CREATE INDEX [IX_ProposalDetails_ProduitId] ON [ProposalDetails] ([ProduitId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    CREATE INDEX [IX_ProposalDetails_ProposalId] ON [ProposalDetails] ([ProposalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    CREATE INDEX [IX_Proposals_UserId] ON [Proposals] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511132628_AddContartToDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210511132628_AddContartToDb', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511134440_AddBillAndBillDetails')
BEGIN
    CREATE TABLE [Bills] (
        [Id] int NOT NULL IDENTITY,
        [NumBill] nvarchar(max) NULL,
        [UserId] nvarchar(450) NULL,
        [IssueDate] datetime2 NOT NULL,
        [DueDate] datetime2 NOT NULL,
        [BillTotalOrginal] float NOT NULL,
        [BillTotal] float NOT NULL,
        [Remise] float NOT NULL,
        [Paid] float NOT NULL,
        [Rest] float NOT NULL,
        [BillType] nvarchar(max) NULL,
        [Status] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [TransactionId] nvarchar(max) NULL,
        CONSTRAINT [PK_Bills] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Bills_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511134440_AddBillAndBillDetails')
BEGIN
    CREATE TABLE [BillDetails] (
        [Id] int NOT NULL IDENTITY,
        [BillId] int NOT NULL,
        [ProduitId] int NOT NULL,
        [Remise] float NOT NULL,
        [Count] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [Tax] float NOT NULL,
        CONSTRAINT [PK_BillDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BillDetails_Bills_BillId] FOREIGN KEY ([BillId]) REFERENCES [Bills] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BillDetails_Produits_ProduitId] FOREIGN KEY ([ProduitId]) REFERENCES [Produits] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511134440_AddBillAndBillDetails')
BEGIN
    CREATE INDEX [IX_BillDetails_BillId] ON [BillDetails] ([BillId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511134440_AddBillAndBillDetails')
BEGIN
    CREATE INDEX [IX_BillDetails_ProduitId] ON [BillDetails] ([ProduitId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511134440_AddBillAndBillDetails')
BEGIN
    CREATE INDEX [IX_Bills_UserId] ON [Bills] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511134440_AddBillAndBillDetails')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210511134440_AddBillAndBillDetails', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511140010_AddReceiptAndNoteCredit')
BEGIN
    CREATE TABLE [CreditNotes] (
        [Id] int NOT NULL IDENTITY,
        [NoteDate] datetime2 NOT NULL,
        [Montant] float NOT NULL,
        [Description] nvarchar(max) NULL,
        [BillId] int NOT NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_CreditNotes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CreditNotes_Bills_BillId] FOREIGN KEY ([BillId]) REFERENCES [Bills] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CreditNotes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511140010_AddReceiptAndNoteCredit')
BEGIN
    CREATE TABLE [Receipts] (
        [Id] int NOT NULL IDENTITY,
        [Reference] nvarchar(max) NOT NULL,
        [RecieptDate] datetime2 NOT NULL,
        [Montant] float NOT NULL,
        [Description] nvarchar(max) NULL,
        [BillId] int NOT NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Receipts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Receipts_Bills_BillId] FOREIGN KEY ([BillId]) REFERENCES [Bills] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Receipts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511140010_AddReceiptAndNoteCredit')
BEGIN
    CREATE INDEX [IX_CreditNotes_BillId] ON [CreditNotes] ([BillId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511140010_AddReceiptAndNoteCredit')
BEGIN
    CREATE INDEX [IX_CreditNotes_UserId] ON [CreditNotes] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511140010_AddReceiptAndNoteCredit')
BEGIN
    CREATE INDEX [IX_Receipts_BillId] ON [Receipts] ([BillId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511140010_AddReceiptAndNoteCredit')
BEGIN
    CREATE INDEX [IX_Receipts_UserId] ON [Receipts] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511140010_AddReceiptAndNoteCredit')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210511140010_AddReceiptAndNoteCredit', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511142627_AddHoliday-HolidayType-Expense')
BEGIN
    CREATE TABLE [ExpenseReports] (
        [Id] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [Montant] float NOT NULL,
        [Comment] nvarchar(max) NOT NULL,
        [Status] nvarchar(max) NULL,
        [ConfirmId] int NOT NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_ExpenseReports] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ExpenseReports_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511142627_AddHoliday-HolidayType-Expense')
BEGIN
    CREATE TABLE [HolidayTypes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_HolidayTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511142627_AddHoliday-HolidayType-Expense')
BEGIN
    CREATE TABLE [Holidays] (
        [Id] int NOT NULL IDENTITY,
        [DemandeDate] datetime2 NOT NULL,
        [StartDate] datetime2 NOT NULL,
        [EndDate] datetime2 NOT NULL,
        [Nbdays] int NOT NULL,
        [Comment] nvarchar(max) NULL,
        [Status] nvarchar(max) NULL,
        [TypeId] int NOT NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Holidays] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Holidays_HolidayTypes_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [HolidayTypes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Holidays_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511142627_AddHoliday-HolidayType-Expense')
BEGIN
    CREATE INDEX [IX_ExpenseReports_UserId] ON [ExpenseReports] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511142627_AddHoliday-HolidayType-Expense')
BEGIN
    CREATE INDEX [IX_Holidays_TypeId] ON [Holidays] ([TypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511142627_AddHoliday-HolidayType-Expense')
BEGIN
    CREATE INDEX [IX_Holidays_UserId] ON [Holidays] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210511142627_AddHoliday-HolidayType-Expense')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210511142627_AddHoliday-HolidayType-Expense', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512115738_UpdateRemisetoString')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShooppingCarts]') AND [c].[name] = N'Remise');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ShooppingCarts] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [ShooppingCarts] ALTER COLUMN [Remise] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512115738_UpdateRemisetoString')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Proposals]') AND [c].[name] = N'Remise');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Proposals] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Proposals] ALTER COLUMN [Remise] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512115738_UpdateRemisetoString')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProposalDetails]') AND [c].[name] = N'Remise');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ProposalDetails] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [ProposalDetails] ALTER COLUMN [Remise] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512115738_UpdateRemisetoString')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'Remise');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Bills] ALTER COLUMN [Remise] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512115738_UpdateRemisetoString')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BillDetails]') AND [c].[name] = N'Remise');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [BillDetails] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [BillDetails] ALTER COLUMN [Remise] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512115738_UpdateRemisetoString')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210512115738_UpdateRemisetoString', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210513140925_ReconvertRemiseToDouble')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Proposals]') AND [c].[name] = N'Remise');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Proposals] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Proposals] ALTER COLUMN [Remise] float NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210513140925_ReconvertRemiseToDouble')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProposalDetails]') AND [c].[name] = N'Remise');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [ProposalDetails] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [ProposalDetails] ALTER COLUMN [Remise] float NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210513140925_ReconvertRemiseToDouble')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'Remise');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Bills] ALTER COLUMN [Remise] float NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210513140925_ReconvertRemiseToDouble')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BillDetails]') AND [c].[name] = N'Remise');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [BillDetails] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [BillDetails] ALTER COLUMN [Remise] float NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210513140925_ReconvertRemiseToDouble')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210513140925_ReconvertRemiseToDouble', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210518224543_UpdateCreditNote')
BEGIN
    DROP TABLE [CreditNotes];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210518224543_UpdateCreditNote')
BEGIN
    CREATE TABLE [CreeditNotes] (
        [Id] int NOT NULL IDENTITY,
        [NoteDate] datetime2 NOT NULL,
        [Montant] float NOT NULL,
        [Description] nvarchar(max) NULL,
        [BillId] int NOT NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_CreeditNotes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CreeditNotes_Bills_BillId] FOREIGN KEY ([BillId]) REFERENCES [Bills] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CreeditNotes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210518224543_UpdateCreditNote')
BEGIN
    CREATE INDEX [IX_CreeditNotes_BillId] ON [CreeditNotes] ([BillId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210518224543_UpdateCreditNote')
BEGIN
    CREATE INDEX [IX_CreeditNotes_UserId] ON [CreeditNotes] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210518224543_UpdateCreditNote')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210518224543_UpdateCreditNote', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716195607_UpdateBillAndProposalDetails')
BEGIN
    ALTER TABLE [BillDetails] DROP CONSTRAINT [FK_BillDetails_Produits_ProduitId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716195607_UpdateBillAndProposalDetails')
BEGIN
    ALTER TABLE [ProposalDetails] DROP CONSTRAINT [FK_ProposalDetails_Produits_ProduitId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716195607_UpdateBillAndProposalDetails')
BEGIN
    DROP INDEX [IX_ProposalDetails_ProduitId] ON [ProposalDetails];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716195607_UpdateBillAndProposalDetails')
BEGIN
    DROP INDEX [IX_BillDetails_ProduitId] ON [BillDetails];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716195607_UpdateBillAndProposalDetails')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProposalDetails]') AND [c].[name] = N'ProduitId');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [ProposalDetails] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [ProposalDetails] DROP COLUMN [ProduitId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716195607_UpdateBillAndProposalDetails')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BillDetails]') AND [c].[name] = N'ProduitId');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [BillDetails] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [BillDetails] DROP COLUMN [ProduitId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716195607_UpdateBillAndProposalDetails')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210716195607_UpdateBillAndProposalDetails', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716201301_UpdateProductId')
BEGIN
    ALTER TABLE [ProposalDetails] ADD [ProduitId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716201301_UpdateProductId')
BEGIN
    ALTER TABLE [BillDetails] ADD [ProduitId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716201301_UpdateProductId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210716201301_UpdateProductId', N'3.1.13');
END;

GO

