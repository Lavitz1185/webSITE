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

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    ALTER TABLE [TblMahasiswa] DROP CONSTRAINT [PK_TblMahasiswa];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    EXEC(N'DELETE FROM [TblMahasiswa]
    WHERE [Nim] = N''2206080051'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    EXEC(N'DELETE FROM [TblMahasiswa]
    WHERE [Nim] = N''2206080052'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    EXEC(N'DELETE FROM [TblMahasiswa]
    WHERE [Nim] = N''2206080053'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    EXEC(N'DELETE FROM [TblMahasiswa]
    WHERE [Nim] = N''2206080054'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    EXEC(N'DELETE FROM [TblMahasiswa]
    WHERE [Nim] = N''2206080055'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    EXEC(N'DELETE FROM [TblMahasiswa]
    WHERE [Nim] = N''2206080056'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    EXEC(N'DELETE FROM [TblMahasiswa]
    WHERE [Nim] = N''2206080057'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    EXEC(N'DELETE FROM [TblMahasiswa]
    WHERE [Nim] = N''2206080058'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblMahasiswa]') AND [c].[name] = N'Nim');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TblMahasiswa] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [TblMahasiswa] ALTER COLUMN [Nim] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    ALTER TABLE [TblMahasiswa] ADD [Id] int NOT NULL IDENTITY;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    ALTER TABLE [TblMahasiswa] ADD CONSTRAINT [PK_TblMahasiswa] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'JenisKelamin', N'NamaLengkap', N'NamaPanggilan', N'Nim', N'Password', N'PhotoPath', N'TanggalLahir') AND [object_id] = OBJECT_ID(N'[TblMahasiswa]'))
        SET IDENTITY_INSERT [TblMahasiswa] ON;
    EXEC(N'INSERT INTO [TblMahasiswa] ([Id], [Email], [JenisKelamin], [NamaLengkap], [NamaPanggilan], [Nim], [Password], [PhotoPath], [TanggalLahir])
    VALUES (1, N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''2206080051'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (2, N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''2206080052'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (3, N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''2206080053'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (4, N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''2206080054'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (5, N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''2206080055'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (6, N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''2206080056'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (7, N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''2206080057'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000''),
    (8, N''aditaklal@gmail.com'', 0, N''Adi Juanito Taklal'', N''Adi'', N''2206080058'', N''adiairnona'', N''/img/contoh.jpeg'', ''2004-02-29T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'JenisKelamin', N'NamaLengkap', N'NamaPanggilan', N'Nim', N'Password', N'PhotoPath', N'TanggalLahir') AND [object_id] = OBJECT_ID(N'[TblMahasiswa]'))
        SET IDENTITY_INSERT [TblMahasiswa] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231222150047_Uodate Mahasiswa')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231222150047_Uodate Mahasiswa', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE TABLE [TblKegiatan] (
        [Id] int NOT NULL IDENTITY,
        [NamaKegiatan] nvarchar(max) NOT NULL,
        [TanggalMulai] datetime2 NOT NULL,
        [TanggalBerakhir] datetime2 NOT NULL,
        [TempatKegiatan] nvarchar(max) NOT NULL,
        [Keterangan] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TblKegiatan] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE TABLE [TblFoto] (
        [Id] int NOT NULL IDENTITY,
        [Tanggal] datetime2 NOT NULL,
        [PhotoPath] nvarchar(max) NOT NULL,
        [IdKegiatan] int NULL,
        [KegiatanId] int NULL,
        CONSTRAINT [PK_TblFoto] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TblFoto_TblKegiatan_KegiatanId] FOREIGN KEY ([KegiatanId]) REFERENCES [TblKegiatan] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE TABLE [TblPesertaKegiatan] (
        [IdMahasiswa] int NOT NULL,
        [IdKegiatan] int NOT NULL,
        [KegiatanId] int NULL,
        [MahasiswaId] int NULL,
        CONSTRAINT [PK_TblPesertaKegiatan] PRIMARY KEY ([IdKegiatan], [IdMahasiswa]),
        CONSTRAINT [FK_TblPesertaKegiatan_TblKegiatan_IdKegiatan] FOREIGN KEY ([IdKegiatan]) REFERENCES [TblKegiatan] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_TblPesertaKegiatan_TblKegiatan_KegiatanId] FOREIGN KEY ([KegiatanId]) REFERENCES [TblKegiatan] ([Id]),
        CONSTRAINT [FK_TblPesertaKegiatan_TblMahasiswa_IdMahasiswa] FOREIGN KEY ([IdMahasiswa]) REFERENCES [TblMahasiswa] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_TblPesertaKegiatan_TblMahasiswa_MahasiswaId] FOREIGN KEY ([MahasiswaId]) REFERENCES [TblMahasiswa] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE TABLE [TblMahasiswaFoto] (
        [IdMahasiswa] int NOT NULL,
        [IdFoto] int NOT NULL,
        [FotoId] int NULL,
        [MahasiswaId] int NULL,
        CONSTRAINT [PK_TblMahasiswaFoto] PRIMARY KEY ([IdFoto], [IdMahasiswa]),
        CONSTRAINT [FK_TblMahasiswaFoto_TblFoto_FotoId] FOREIGN KEY ([FotoId]) REFERENCES [TblFoto] ([Id]),
        CONSTRAINT [FK_TblMahasiswaFoto_TblFoto_IdFoto] FOREIGN KEY ([IdFoto]) REFERENCES [TblFoto] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_TblMahasiswaFoto_TblMahasiswa_IdMahasiswa] FOREIGN KEY ([IdMahasiswa]) REFERENCES [TblMahasiswa] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_TblMahasiswaFoto_TblMahasiswa_MahasiswaId] FOREIGN KEY ([MahasiswaId]) REFERENCES [TblMahasiswa] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE INDEX [IX_TblFoto_KegiatanId] ON [TblFoto] ([KegiatanId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE INDEX [IX_TblMahasiswaFoto_FotoId] ON [TblMahasiswaFoto] ([FotoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE INDEX [IX_TblMahasiswaFoto_IdMahasiswa] ON [TblMahasiswaFoto] ([IdMahasiswa]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE INDEX [IX_TblMahasiswaFoto_MahasiswaId] ON [TblMahasiswaFoto] ([MahasiswaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE INDEX [IX_TblPesertaKegiatan_IdMahasiswa] ON [TblPesertaKegiatan] ([IdMahasiswa]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE INDEX [IX_TblPesertaKegiatan_KegiatanId] ON [TblPesertaKegiatan] ([KegiatanId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    CREATE INDEX [IX_TblPesertaKegiatan_MahasiswaId] ON [TblPesertaKegiatan] ([MahasiswaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223015932_TambahTabel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231223015932_TambahTabel', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223040714_SeedDataKegiatanFoto')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IdKegiatan', N'KegiatanId', N'PhotoPath', N'Tanggal') AND [object_id] = OBJECT_ID(N'[TblFoto]'))
        SET IDENTITY_INSERT [TblFoto] ON;
    EXEC(N'INSERT INTO [TblFoto] ([Id], [IdKegiatan], [KegiatanId], [PhotoPath], [Tanggal])
    VALUES (1, 1, NULL, N''/img/contoh.jpeg'', ''2023-12-03T00:00:00.0000000''),
    (2, 1, NULL, N''/img/contoh.jpeg'', ''2023-12-04T00:00:00.0000000''),
    (3, 1, NULL, N''/img/contoh.jpeg'', ''2023-12-04T00:00:00.0000000''),
    (4, 1, NULL, N''/img/contoh.jpeg'', ''2023-12-05T00:00:00.0000000''),
    (5, 1, NULL, N''/img/contoh.jpeg'', ''2023-12-06T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IdKegiatan', N'KegiatanId', N'PhotoPath', N'Tanggal') AND [object_id] = OBJECT_ID(N'[TblFoto]'))
        SET IDENTITY_INSERT [TblFoto] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223040714_SeedDataKegiatanFoto')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Keterangan', N'NamaKegiatan', N'TanggalBerakhir', N'TanggalMulai', N'TempatKegiatan') AND [object_id] = OBJECT_ID(N'[TblKegiatan]'))
        SET IDENTITY_INSERT [TblKegiatan] ON;
    EXEC(N'INSERT INTO [TblKegiatan] ([Id], [Keterangan], [NamaKegiatan], [TanggalBerakhir], [TanggalMulai], [TempatKegiatan])
    VALUES (1, N''Kegiatan Pertama'', N''Kegiatan 1'', ''2023-12-07T00:00:00.0000000'', ''2023-12-03T00:00:00.0000000'', N''Undana'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Keterangan', N'NamaKegiatan', N'TanggalBerakhir', N'TanggalMulai', N'TempatKegiatan') AND [object_id] = OBJECT_ID(N'[TblKegiatan]'))
        SET IDENTITY_INSERT [TblKegiatan] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223040714_SeedDataKegiatanFoto')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdFoto', N'IdMahasiswa', N'FotoId', N'MahasiswaId') AND [object_id] = OBJECT_ID(N'[TblMahasiswaFoto]'))
        SET IDENTITY_INSERT [TblMahasiswaFoto] ON;
    EXEC(N'INSERT INTO [TblMahasiswaFoto] ([IdFoto], [IdMahasiswa], [FotoId], [MahasiswaId])
    VALUES (1, 1, NULL, NULL),
    (1, 2, NULL, NULL),
    (2, 1, NULL, NULL),
    (2, 2, NULL, NULL),
    (3, 1, NULL, NULL),
    (3, 2, NULL, NULL),
    (4, 1, NULL, NULL),
    (4, 2, NULL, NULL),
    (5, 1, NULL, NULL),
    (5, 2, NULL, NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdFoto', N'IdMahasiswa', N'FotoId', N'MahasiswaId') AND [object_id] = OBJECT_ID(N'[TblMahasiswaFoto]'))
        SET IDENTITY_INSERT [TblMahasiswaFoto] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223040714_SeedDataKegiatanFoto')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdKegiatan', N'IdMahasiswa', N'KegiatanId', N'MahasiswaId') AND [object_id] = OBJECT_ID(N'[TblPesertaKegiatan]'))
        SET IDENTITY_INSERT [TblPesertaKegiatan] ON;
    EXEC(N'INSERT INTO [TblPesertaKegiatan] ([IdKegiatan], [IdMahasiswa], [KegiatanId], [MahasiswaId])
    VALUES (1, 1, NULL, NULL),
    (1, 2, NULL, NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdKegiatan', N'IdMahasiswa', N'KegiatanId', N'MahasiswaId') AND [object_id] = OBJECT_ID(N'[TblPesertaKegiatan]'))
        SET IDENTITY_INSERT [TblPesertaKegiatan] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223040714_SeedDataKegiatanFoto')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231223040714_SeedDataKegiatanFoto', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    ALTER TABLE [TblMahasiswaFoto] DROP CONSTRAINT [FK_TblMahasiswaFoto_TblFoto_FotoId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    ALTER TABLE [TblMahasiswaFoto] DROP CONSTRAINT [FK_TblMahasiswaFoto_TblMahasiswa_MahasiswaId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    ALTER TABLE [TblPesertaKegiatan] DROP CONSTRAINT [FK_TblPesertaKegiatan_TblKegiatan_KegiatanId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    ALTER TABLE [TblPesertaKegiatan] DROP CONSTRAINT [FK_TblPesertaKegiatan_TblMahasiswa_MahasiswaId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    DROP INDEX [IX_TblPesertaKegiatan_KegiatanId] ON [TblPesertaKegiatan];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    DROP INDEX [IX_TblPesertaKegiatan_MahasiswaId] ON [TblPesertaKegiatan];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    DROP INDEX [IX_TblMahasiswaFoto_FotoId] ON [TblMahasiswaFoto];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    DROP INDEX [IX_TblMahasiswaFoto_MahasiswaId] ON [TblMahasiswaFoto];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblPesertaKegiatan]') AND [c].[name] = N'KegiatanId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TblPesertaKegiatan] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [TblPesertaKegiatan] DROP COLUMN [KegiatanId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblPesertaKegiatan]') AND [c].[name] = N'MahasiswaId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TblPesertaKegiatan] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [TblPesertaKegiatan] DROP COLUMN [MahasiswaId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblMahasiswaFoto]') AND [c].[name] = N'FotoId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [TblMahasiswaFoto] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [TblMahasiswaFoto] DROP COLUMN [FotoId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblMahasiswaFoto]') AND [c].[name] = N'MahasiswaId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [TblMahasiswaFoto] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [TblMahasiswaFoto] DROP COLUMN [MahasiswaId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223042428_PerbaikiModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231223042428_PerbaikiModel', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223052511_PerbaikiModelFoto')
BEGIN
    ALTER TABLE [TblFoto] DROP CONSTRAINT [FK_TblFoto_TblKegiatan_KegiatanId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223052511_PerbaikiModelFoto')
BEGIN
    DROP INDEX [IX_TblFoto_KegiatanId] ON [TblFoto];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223052511_PerbaikiModelFoto')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TblFoto]') AND [c].[name] = N'KegiatanId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [TblFoto] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [TblFoto] DROP COLUMN [KegiatanId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223052511_PerbaikiModelFoto')
BEGIN
    CREATE INDEX [IX_TblFoto_IdKegiatan] ON [TblFoto] ([IdKegiatan]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223052511_PerbaikiModelFoto')
BEGIN
    ALTER TABLE [TblFoto] ADD CONSTRAINT [FK_TblFoto_TblKegiatan_IdKegiatan] FOREIGN KEY ([IdKegiatan]) REFERENCES [TblKegiatan] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231223052511_PerbaikiModelFoto')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231223052511_PerbaikiModelFoto', N'7.0.14');
END;
GO

COMMIT;
GO

