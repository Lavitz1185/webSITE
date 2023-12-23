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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222022407_InitialMigrations')
BEGIN
    CREATE TABLE [TblMahasiswa] (
        [Nim] nvarchar(450) NOT NULL,
        [NamaLengkap] nvarchar(max) NOT NULL,
        [NamaPanggilan] nvarchar(max) NOT NULL,
        [TanggalLahir] datetime2 NOT NULL,
        [JenisKelamin] int NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [PhotoPath] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TblMahasiswa] PRIMARY KEY ([Nim])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222022407_InitialMigrations')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231222022407_InitialMigrations', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222022917_SeedingData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nim', N'Email', N'JenisKelamin', N'NamaLengkap', N'NamaPanggilan', N'Password', N'PhotoPath', N'TanggalLahir') AND [object_id] = OBJECT_ID(N'[TblMahasiswa]'))
        SET IDENTITY_INSERT [TblMahasiswa] ON;
    EXEC(N'INSERT INTO [TblMahasiswa] ([Nim], [Email], [JenisKelamin], [NamaLengkap], [NamaPanggilan], [Password], [PhotoPath], [TanggalLahir])
    VALUES (N''2206080051'', N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (N''2206080052'', N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (N''2206080053'', N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (N''2206080054'', N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (N''2206080055'', N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (N''2206080056'', N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (N''2206080057'', N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (N''2206080058'', N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nim', N'Email', N'JenisKelamin', N'NamaLengkap', N'NamaPanggilan', N'Password', N'PhotoPath', N'TanggalLahir') AND [object_id] = OBJECT_ID(N'[TblMahasiswa]'))
        SET IDENTITY_INSERT [TblMahasiswa] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222022917_SeedingData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231222022917_SeedingData', N'7.0.14');
END;
GO

COMMIT;
GO

