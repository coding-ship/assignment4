IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220528053900_mig')
BEGIN
    CREATE TABLE [Login] (
        [Email_Id] nvarchar(450) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Login] PRIMARY KEY ([Email_Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220528053900_mig')
BEGIN
    CREATE TABLE [Venue] (
        [Event_Place] nvarchar(450) NOT NULL,
        [Event_Type] nvarchar(max) NOT NULL,
        [Guest_Capability] int NOT NULL,
        [Per_Guest_Cost] int NOT NULL,
        CONSTRAINT [PK_Venue] PRIMARY KEY ([Event_Place])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220528053900_mig')
BEGIN
    CREATE TABLE [AdminDetails] (
        [Id] int NOT NULL IDENTITY,
        [Email_Id] nvarchar(450) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [First_Name] nvarchar(max) NOT NULL,
        [Last_Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_AdminDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AdminDetails_Login_Email_Id] FOREIGN KEY ([Email_Id]) REFERENCES [Login] ([Email_Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220528053900_mig')
BEGIN
    CREATE TABLE [VenueDetail] (
        [Id] int NOT NULL IDENTITY,
        [Event_Place] nvarchar(450) NULL,
        [DJ_Cost] int NOT NULL,
        [Stage_Cost] int NOT NULL,
        [Mike_Speaker_Cost] int NOT NULL,
        CONSTRAINT [PK_VenueDetail] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_VenueDetail_Venue_Event_Place] FOREIGN KEY ([Event_Place]) REFERENCES [Venue] ([Event_Place]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220528053900_mig')
BEGIN
    CREATE INDEX [IX_AdminDetails_Email_Id] ON [AdminDetails] ([Email_Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220528053900_mig')
BEGIN
    CREATE INDEX [IX_VenueDetail_Event_Place] ON [VenueDetail] ([Event_Place]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220528053900_mig')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220528053900_mig', N'3.1.25');
END;

GO

