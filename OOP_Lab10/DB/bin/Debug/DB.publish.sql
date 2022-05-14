/*
Скрипт развертывания для DB

Этот код был создан программным средством.
Изменения, внесенные в этот файл, могут привести к неверному выполнению кода и будут потеряны
в случае его повторного формирования.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB"
:setvar DefaultFilePrefix "DB"
:setvar DefaultDataPath "C:\Users\valda\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDb\"
:setvar DefaultLogPath "C:\Users\valda\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDb\"

GO
:on error exit
GO
/*
Проверьте режим SQLCMD и отключите выполнение скрипта, если режим SQLCMD не поддерживается.
Чтобы повторно включить скрипт после включения режима SQLCMD выполните следующую инструкцию:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Для успешного выполнения этого скрипта должен быть включен режим SQLCMD.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Идет создание базы данных $(DatabaseName)…'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Параметры базы данных изменить нельзя. Применить эти параметры может только пользователь SysAdmin.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Параметры базы данных изменить нельзя. Применить эти параметры может только пользователь SysAdmin.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Идет создание Таблица [dbo].[Roles]…';


GO
CREATE TABLE [dbo].[Roles] (
    [Id]       INT           NOT NULL,
    [RoleName] NVARCHAR (32) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Roles_RoleName] UNIQUE NONCLUSTERED ([RoleName] ASC)
);


GO
PRINT N'Идет создание Таблица [dbo].[Users]…';


GO
CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Email]        NVARCHAR (128)   NOT NULL,
    [PasswordHash] NVARCHAR (128)   NOT NULL,
    [UserName]     NVARCHAR (128)   NOT NULL,
    [UserSurname]  NVARCHAR (128)   NOT NULL,
    [IsActive]     BIT              NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Users_Email] UNIQUE NONCLUSTERED ([Email] ASC)
);


GO
PRINT N'Идет создание Таблица [dbo].[UsersRoles]…';


GO
CREATE TABLE [dbo].[UsersRoles] (
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] INT              NOT NULL,
    CONSTRAINT [PK_UsersRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC)
);


GO
PRINT N'Идет создание Индекс [dbo].[UsersRoles].[IX_UsersRoles_UserId]…';


GO
CREATE NONCLUSTERED INDEX [IX_UsersRoles_UserId]
    ON [dbo].[UsersRoles]([UserId] ASC);


GO
PRINT N'Идет создание Индекс [dbo].[UsersRoles].[IX_UsersRoles_RoleId]…';


GO
CREATE NONCLUSTERED INDEX [IX_UsersRoles_RoleId]
    ON [dbo].[UsersRoles]([RoleId] ASC);


GO
PRINT N'Идет создание Внешний ключ [dbo].[FK_UsersRoles_Users]…';


GO
ALTER TABLE [dbo].[UsersRoles]
    ADD CONSTRAINT [FK_UsersRoles_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Идет создание Внешний ключ [dbo].[FK_UsersRoles_Roles]…';


GO
ALTER TABLE [dbo].[UsersRoles]
    ADD CONSTRAINT [FK_UsersRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]);


GO
insert into dbo.Roles (Id, RoleName) 
values
(30, N'Проектный менеджер'),
(110, N'Инженер-программист'),
(250, N'Программист-тестировщик')
insert into dbo.Users(Id, Email, PasswordHash, UserName, UserSurname, IsActive)
values
('A08374E3-EAE7-4464-8877-0FA3BCD2368A', N'valdaitsevv@mail.ru', N'3ab8ace778aafec3cb4b02e5217b784e', N'Александр', N'Валдайцев', 1),
('18D36C62-92B9-48E9-A655-FEAC8F0989E3', N'klepaski@mail.ru', N'0ea1e236ecd66e5ef21a1220dbe62fdb', N'Ольга', N'Чистякова', 1),
('05FC0747-C25C-4038-803E-34A072892473', N'alimake_eugene@mail.ru', N'7294d21f95ab136e9313d81fc16328b3', N'Евгения', N'Николаева', 1),
('B2772010-106F-44CA-8AC7-4A0CF1DB8957', N't0x1ch@mail.ru', N'07dae6b6d30f254480bfc2efbc11010e', N'Антон', N'Димитриади', 1),
('A93D134B-48C4-48CA-A6F3-4BD9706E3E61', N'pereigrall122@mail.ru', N'e92d71902c1565579ff72baef97e88db', N'Антон', N'Ткачёв', 1),
('ECBE0111-1FCD-4124-800D-FAD9098757E7', N'nevrublevskayyaa996@mail.ru', N'ac198c77becb731588bf4fa89fde3ed6', N'Екатерина', N'Врублевская', 1),
('AA575CFE-F1C0-4A37-A35F-81F2B0CC30AF', N'wjxqvix@mail.ru', N'ac6f4413edd7a23b3a15485f251c21aa', N'Анастасия', N'Шейно', 0),
('D45A2363-ED1C-4AF9-81DC-608FAC33DD1C', N'imazenkovaa@mail.ru', N'f99d01b8b82dbe4f8902b6c0d1262e57', N'Ирина', N'Мазенкова', 0),
('05FB84FF-991B-41F0-AE39-4CE69DB9B77C', N'fresshkkaa8876@mail.ru', N'27c50fe348902bbe9f8f83b328618399', N'Дарья', N'Домуть', 1),
('748078D4-A83E-45E2-8DD9-DB5B621A151C', N'barbarianelitian@mail.ru', N'3912ad3095cd7f9b0e0c23e5f877968f', N'Даниил', N'Мороз', 0),
('0762CF48-B5DC-422A-AB81-29C1D179918B', N'yudeshk00_01@mail.ru', N'82bfe7d977154bff0b4a8c8a7ac68e14', N'Роман', N'Юдешко', 1),
('E9CB07B3-9B71-4E87-A376-21A23D3A536C', N'ghosttownboy1337@mail.ru', N'24f2526da91d012949a903de944af444', N'Даниил', N'Столыпин', 0),
('0E8B0DB7-2656-412B-B1A1-EDFE710C7771', N'zxcvashkevich663@mail.ru', N'2a9cfbb4acb7439107fa3f14ba7a21ea', N'Александр', N'Ивашкевич', 1),
('199FAE8D-88CD-429E-BB96-1D82308CA85C', N'kashperskaya1143@mail.ru', N'b7d4d79ad6ea3ee26f15e185e58f075c', N'Надежда', N'Маликова', 1),
('71F28A95-0E2C-4FFD-BED1-6D9C08EE5674', N'telmankzz02@mail.ru', N'a96178deb8026bad81cae3f4d591d470', N'Александра', N'Качевская', 0),
('4E2249AA-EA09-4BBC-9263-44B3E927BE39', N'alohadanceqq@mail.ru', N'f21b94b847c0b794ad1ca8cb8577ab2b', N'Илья', N'Коробкин', 1)
insert into dbo.UsersRoles (UserId, RoleId)
values
('A08374E3-EAE7-4464-8877-0FA3BCD2368A', 30),
('05FC0747-C25C-4038-803E-34A072892473', 30),
('ECBE0111-1FCD-4124-800D-FAD9098757E7', 110),
('0762CF48-B5DC-422A-AB81-29C1D179918B', 110),
('4E2249AA-EA09-4BBC-9263-44B3E927BE39', 110),
('A93D134B-48C4-48CA-A6F3-4BD9706E3E61', 110),
('A93D134B-48C4-48CA-A6F3-4BD9706E3E61', 250),
('0E8B0DB7-2656-412B-B1A1-EDFE710C7771', 250),
('71F28A95-0E2C-4FFD-BED1-6D9C08EE5674', 250),
('B2772010-106F-44CA-8AC7-4A0CF1DB8957', 250),
('D45A2363-ED1C-4AF9-81DC-608FAC33DD1C', 250)
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Обновление завершено.';


GO
