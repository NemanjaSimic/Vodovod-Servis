﻿/*
Deployment script for Vodovod

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Vodovod"
:setvar DefaultFilePrefix "Vodovod"
:setvar DefaultDataPath "D:\Install\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "D:\Install\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
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
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
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
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
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
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
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
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
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
PRINT N'Creating [dbo].[DEO_OPREME]...';


GO
CREATE TABLE [dbo].[DEO_OPREME] (
    [TIP_OPREME]              VARCHAR (MAX) NOT NULL,
    [VODOVODNA_MREZA_ID_MREZ] VARCHAR (10)  NULL,
    [ID_TIP]                  TINYINT       NOT NULL,
    [DUBINA]                  TINYINT       NULL,
    CONSTRAINT [DEO_OPREME_PK] PRIMARY KEY CLUSTERED ([ID_TIP] ASC)
);


GO
PRINT N'Creating [dbo].[EKIPA]...';


GO
CREATE TABLE [dbo].[EKIPA] (
    [ID_EK]                      VARCHAR (10) NOT NULL,
    [BR_RAD]                     TINYINT      NOT NULL,
    [RADNI_NALOG_ID_RADNAL]      VARCHAR (10) NULL,
    [RADNI_NALOG_PRIMA_JMBG_ZAP] CHAR (13)    NULL,
    [RADNI_NALOG_PRIMA_JMBG_KOR] CHAR (13)    NULL,
    [RADNI_NALOG_PRIMA_ID_KVAR]  VARCHAR (10) NULL,
    CONSTRAINT [EKIPA_PK] PRIMARY KEY CLUSTERED ([ID_EK] ASC)
);


GO
PRINT N'Creating [dbo].[KORISNIK]...';


GO
CREATE TABLE [dbo].[KORISNIK] (
    [IME_KOR]  VARCHAR (MAX) NOT NULL,
    [PREZ_KOR] VARCHAR (MAX) NOT NULL,
    [JMBG_KOR] CHAR (13)     NOT NULL,
    CONSTRAINT [KORISNIK_PK] PRIMARY KEY CLUSTERED ([JMBG_KOR] ASC)
);


GO
PRINT N'Creating [dbo].[KVAR]...';


GO
CREATE TABLE [dbo].[KVAR] (
    [ID_KVAR]  VARCHAR (10) NOT NULL,
    [TIP_KVAR] INT          NOT NULL,
    CONSTRAINT [KVAR_PK] PRIMARY KEY CLUSTERED ([ID_KVAR] ASC)
);


GO
PRINT N'Creating [dbo].[LOKACIJA]...';


GO
CREATE TABLE [dbo].[LOKACIJA] (
    [SIF_LOK] VARCHAR (10)  NOT NULL,
    [ULICA]   VARCHAR (MAX) NOT NULL,
    [BROJ]    VARCHAR (5)   NOT NULL,
    [GRAD]    VARCHAR (MAX) NOT NULL,
    CONSTRAINT [LOKACIJA_PK] PRIMARY KEY CLUSTERED ([SIF_LOK] ASC)
);


GO
PRINT N'Creating [dbo].[MAGACIN]...';


GO
CREATE TABLE [dbo].[MAGACIN] (
    [ID_MAG]    VARCHAR (10) NOT NULL,
    [KAPACITET] SMALLINT     NOT NULL,
    CONSTRAINT [MAGACIN_PK] PRIMARY KEY CLUSTERED ([ID_MAG] ASC)
);


GO
PRINT N'Creating [dbo].[NADLEZNI]...';


GO
CREATE TABLE [dbo].[NADLEZNI] (
    [JMBG_ZAP] CHAR (13) NOT NULL,
    CONSTRAINT [NADLEZNI_PK] PRIMARY KEY CLUSTERED ([JMBG_ZAP] ASC)
);


GO
PRINT N'Creating [dbo].[NALAZI_SE_NA]...';


GO
CREATE TABLE [dbo].[NALAZI_SE_NA] (
    [ID_DEO_LOK]        VARCHAR (10) NOT NULL,
    [DUBINA]            FLOAT (2)    NOT NULL,
    [LOKACIJA_SIF_LOK]  VARCHAR (10) NOT NULL,
    [DEO_OPREME_ID_TIP] TINYINT      NOT NULL,
    CONSTRAINT [NALAZI_SE_NA_PK] PRIMARY KEY CLUSTERED ([ID_DEO_LOK] ASC, [LOKACIJA_SIF_LOK] ASC, [DEO_OPREME_ID_TIP] ASC)
);


GO
PRINT N'Creating [dbo].[NALAZI_U]...';


GO
CREATE TABLE [dbo].[NALAZI_U] (
    [MAGACIN_ID_MAG]    VARCHAR (10) NOT NULL,
    [DEO_OPREME_ID_TIP] TINYINT      NOT NULL,
    [ID_DEO]            VARCHAR (10) NOT NULL,
    [EKIPA_ID_EK]       VARCHAR (10) NULL,
    CONSTRAINT [NALAZI_U_PK] PRIMARY KEY CLUSTERED ([DEO_OPREME_ID_TIP] ASC, [MAGACIN_ID_MAG] ASC, [ID_DEO] ASC)
);


GO
PRINT N'Creating [dbo].[PRIJAVLJUJE]...';


GO
CREATE TABLE [dbo].[PRIJAVLJUJE] (
    [KORISNIK_JMBG_KOR]       CHAR (13)    NOT NULL,
    [KVAR_ID_KVAR]            VARCHAR (10) NOT NULL,
    [NALAZI_SE_NA_ID_DEO_LOK] VARCHAR (10) NOT NULL,
    [NALAZI_SE_NA_SIF_LOK]    VARCHAR (10) NOT NULL,
    [NALAZI_SE_NA_ID_TIP]     TINYINT      NOT NULL,
    CONSTRAINT [PRIJAVLJUJE_PK] PRIMARY KEY CLUSTERED ([KORISNIK_JMBG_KOR] ASC, [KVAR_ID_KVAR] ASC)
);


GO
PRINT N'Creating [dbo].[PRIMA]...';


GO
CREATE TABLE [dbo].[PRIMA] (
    [NADLEZNI_JMBG_ZAP]             CHAR (13)    NOT NULL,
    [PRIJAVLJUJE_KORISNIK_JMBG_KOR] CHAR (13)    NOT NULL,
    [PRIJAVLJUJE_KVAR_ID_KVAR]      VARCHAR (10) NOT NULL,
    CONSTRAINT [PRIMA_PK] PRIMARY KEY CLUSTERED ([NADLEZNI_JMBG_ZAP] ASC, [PRIJAVLJUJE_KORISNIK_JMBG_KOR] ASC, [PRIJAVLJUJE_KVAR_ID_KVAR] ASC)
);


GO
PRINT N'Creating [dbo].[RACUN]...';


GO
CREATE TABLE [dbo].[RACUN] (
    [ID_RAC]         VARCHAR (10) NOT NULL,
    [CENA]           MONEY        NOT NULL,
    [PRIMA_JMBG_ZAP] CHAR (13)    NOT NULL,
    [PRIMA_JMBG_KOR] CHAR (13)    NOT NULL,
    [PRIMA_ID_KVAR]  VARCHAR (10) NOT NULL,
    CONSTRAINT [RACUN_PK] PRIMARY KEY CLUSTERED ([ID_RAC] ASC)
);


GO
PRINT N'Creating [dbo].[RADNI_NALOG]...';


GO
CREATE TABLE [dbo].[RADNI_NALOG] (
    [ID_RADNAL]      VARCHAR (10) NOT NULL,
    [PRIMA_JMBG_ZAP] CHAR (13)    NOT NULL,
    [PRIMA_JMBG_KOR] CHAR (13)    NOT NULL,
    [PRIMA_ID_KVAR]  VARCHAR (10) NOT NULL,
    CONSTRAINT [RADNI_NALOG_PK] PRIMARY KEY CLUSTERED ([ID_RADNAL] ASC, [PRIMA_JMBG_ZAP] ASC, [PRIMA_JMBG_KOR] ASC, [PRIMA_ID_KVAR] ASC)
);


GO
PRINT N'Creating [dbo].[RADNIIK]...';


GO
CREATE TABLE [dbo].[RADNIIK] (
    [JMBG_ZAP]    CHAR (13)    NOT NULL,
    [EKIPA_ID_EK] VARCHAR (10) NULL,
    CONSTRAINT [RADNIIK_PK] PRIMARY KEY CLUSTERED ([JMBG_ZAP] ASC)
);


GO
PRINT N'Creating [dbo].[VODOVODNA_MREZA]...';


GO
CREATE TABLE [dbo].[VODOVODNA_MREZA] (
    [ID_MREZ] VARCHAR (10)  NOT NULL,
    [GRAD]    VARCHAR (MAX) NOT NULL,
    CONSTRAINT [VODOVODNA_MREZA_PK] PRIMARY KEY CLUSTERED ([ID_MREZ] ASC)
);


GO
PRINT N'Creating [dbo].[ZAPOSLENI]...';


GO
CREATE TABLE [dbo].[ZAPOSLENI] (
    [JMBG_ZAP] CHAR (13)     NOT NULL,
    [IME_ZAP]  VARCHAR (MAX) NOT NULL,
    [PREZ_ZAP] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [ZAPOSLENI_PK] PRIMARY KEY CLUSTERED ([JMBG_ZAP] ASC)
);


GO
PRINT N'Creating [dbo].[DEO_OPREME_VODOVODNA_MREZA_FK]...';


GO
ALTER TABLE [dbo].[DEO_OPREME]
    ADD CONSTRAINT [DEO_OPREME_VODOVODNA_MREZA_FK] FOREIGN KEY ([VODOVODNA_MREZA_ID_MREZ]) REFERENCES [dbo].[VODOVODNA_MREZA] ([ID_MREZ]);


GO
PRINT N'Creating [dbo].[EKIPA_RADNI_NALOG_FK]...';


GO
ALTER TABLE [dbo].[EKIPA]
    ADD CONSTRAINT [EKIPA_RADNI_NALOG_FK] FOREIGN KEY ([RADNI_NALOG_ID_RADNAL], [RADNI_NALOG_PRIMA_JMBG_ZAP], [RADNI_NALOG_PRIMA_JMBG_KOR], [RADNI_NALOG_PRIMA_ID_KVAR]) REFERENCES [dbo].[RADNI_NALOG] ([ID_RADNAL], [PRIMA_JMBG_ZAP], [PRIMA_JMBG_KOR], [PRIMA_ID_KVAR]);


GO
PRINT N'Creating [dbo].[NADLEZNI_ZAPOSLENI_FK]...';


GO
ALTER TABLE [dbo].[NADLEZNI]
    ADD CONSTRAINT [NADLEZNI_ZAPOSLENI_FK] FOREIGN KEY ([JMBG_ZAP]) REFERENCES [dbo].[ZAPOSLENI] ([JMBG_ZAP]);


GO
PRINT N'Creating [dbo].[NALAZI_SE_NA_LOKACIJA_FK]...';


GO
ALTER TABLE [dbo].[NALAZI_SE_NA]
    ADD CONSTRAINT [NALAZI_SE_NA_LOKACIJA_FK] FOREIGN KEY ([LOKACIJA_SIF_LOK]) REFERENCES [dbo].[LOKACIJA] ([SIF_LOK]);


GO
PRINT N'Creating [dbo].[NALAZI_SE_NA_DEO_OPREME_FK]...';


GO
ALTER TABLE [dbo].[NALAZI_SE_NA]
    ADD CONSTRAINT [NALAZI_SE_NA_DEO_OPREME_FK] FOREIGN KEY ([DEO_OPREME_ID_TIP]) REFERENCES [dbo].[DEO_OPREME] ([ID_TIP]);


GO
PRINT N'Creating [dbo].[NALAZI_U_MAGACIN_FK]...';


GO
ALTER TABLE [dbo].[NALAZI_U]
    ADD CONSTRAINT [NALAZI_U_MAGACIN_FK] FOREIGN KEY ([MAGACIN_ID_MAG]) REFERENCES [dbo].[MAGACIN] ([ID_MAG]);


GO
PRINT N'Creating [dbo].[NALAZI_U_DEO_OPREME_FK]...';


GO
ALTER TABLE [dbo].[NALAZI_U]
    ADD CONSTRAINT [NALAZI_U_DEO_OPREME_FK] FOREIGN KEY ([DEO_OPREME_ID_TIP]) REFERENCES [dbo].[DEO_OPREME] ([ID_TIP]);


GO
PRINT N'Creating [dbo].[NALAZI_U_EKIPA_FK]...';


GO
ALTER TABLE [dbo].[NALAZI_U]
    ADD CONSTRAINT [NALAZI_U_EKIPA_FK] FOREIGN KEY ([EKIPA_ID_EK]) REFERENCES [dbo].[EKIPA] ([ID_EK]);


GO
PRINT N'Creating [dbo].[PRIJAVLJUJE_KORISNIK_FK]...';


GO
ALTER TABLE [dbo].[PRIJAVLJUJE]
    ADD CONSTRAINT [PRIJAVLJUJE_KORISNIK_FK] FOREIGN KEY ([KORISNIK_JMBG_KOR]) REFERENCES [dbo].[KORISNIK] ([JMBG_KOR]);


GO
PRINT N'Creating [dbo].[PRIJAVLJUJE_NALAZI_SE_NA_FK]...';


GO
ALTER TABLE [dbo].[PRIJAVLJUJE]
    ADD CONSTRAINT [PRIJAVLJUJE_NALAZI_SE_NA_FK] FOREIGN KEY ([NALAZI_SE_NA_ID_DEO_LOK], [NALAZI_SE_NA_SIF_LOK], [NALAZI_SE_NA_ID_TIP]) REFERENCES [dbo].[NALAZI_SE_NA] ([ID_DEO_LOK], [LOKACIJA_SIF_LOK], [DEO_OPREME_ID_TIP]);


GO
PRINT N'Creating [dbo].[PRIJAVLJUJE_KVAR_FK]...';


GO
ALTER TABLE [dbo].[PRIJAVLJUJE]
    ADD CONSTRAINT [PRIJAVLJUJE_KVAR_FK] FOREIGN KEY ([KVAR_ID_KVAR]) REFERENCES [dbo].[KVAR] ([ID_KVAR]);


GO
PRINT N'Creating [dbo].[PRIMA_NADLEZNI_FK]...';


GO
ALTER TABLE [dbo].[PRIMA]
    ADD CONSTRAINT [PRIMA_NADLEZNI_FK] FOREIGN KEY ([NADLEZNI_JMBG_ZAP]) REFERENCES [dbo].[NADLEZNI] ([JMBG_ZAP]);


GO
PRINT N'Creating [dbo].[PRIMA_PRIJAVLJUJE_FK]...';


GO
ALTER TABLE [dbo].[PRIMA]
    ADD CONSTRAINT [PRIMA_PRIJAVLJUJE_FK] FOREIGN KEY ([PRIJAVLJUJE_KORISNIK_JMBG_KOR], [PRIJAVLJUJE_KVAR_ID_KVAR]) REFERENCES [dbo].[PRIJAVLJUJE] ([KORISNIK_JMBG_KOR], [KVAR_ID_KVAR]);


GO
PRINT N'Creating [dbo].[RACUN_PRIMA_FK]...';


GO
ALTER TABLE [dbo].[RACUN]
    ADD CONSTRAINT [RACUN_PRIMA_FK] FOREIGN KEY ([PRIMA_JMBG_ZAP], [PRIMA_JMBG_KOR], [PRIMA_ID_KVAR]) REFERENCES [dbo].[PRIMA] ([NADLEZNI_JMBG_ZAP], [PRIJAVLJUJE_KORISNIK_JMBG_KOR], [PRIJAVLJUJE_KVAR_ID_KVAR]);


GO
PRINT N'Creating [dbo].[RADNI_NALOG_PRIMA_FK]...';


GO
ALTER TABLE [dbo].[RADNI_NALOG]
    ADD CONSTRAINT [RADNI_NALOG_PRIMA_FK] FOREIGN KEY ([PRIMA_JMBG_ZAP], [PRIMA_JMBG_KOR], [PRIMA_ID_KVAR]) REFERENCES [dbo].[PRIMA] ([NADLEZNI_JMBG_ZAP], [PRIJAVLJUJE_KORISNIK_JMBG_KOR], [PRIJAVLJUJE_KVAR_ID_KVAR]);


GO
PRINT N'Creating [dbo].[RADNIIK_ZAPOSLENI_FK]...';


GO
ALTER TABLE [dbo].[RADNIIK]
    ADD CONSTRAINT [RADNIIK_ZAPOSLENI_FK] FOREIGN KEY ([JMBG_ZAP]) REFERENCES [dbo].[ZAPOSLENI] ([JMBG_ZAP]);


GO
PRINT N'Creating [dbo].[RADNIIK_EKIPA_FK]...';


GO
ALTER TABLE [dbo].[RADNIIK]
    ADD CONSTRAINT [RADNIIK_EKIPA_FK] FOREIGN KEY ([EKIPA_ID_EK]) REFERENCES [dbo].[EKIPA] ([ID_EK]);


GO
PRINT N'Creating [dbo].[DodavanjeRadnikaTriger]...';


GO
CREATE TRIGGER [DodavanjeRadnikaTriger]
		ON [dbo].RADNIIK
	FOR  UPDATE
	AS
	BEGIN
	declare @oldVal varchar(10), @newVal varchar(10)
	declare @oldNum int

	select @oldVal = EKIPA_ID_EK from deleted
	select @newVal = EKIPA_ID_EK from inserted
	if @oldVal is null
	begin
		set @oldVal = ''
	end
	if @newVal is null
	begin
		set @newVal = ''
	end
	if (@oldVal not like @newVal)
	BEGIN
			if ( @newVal like '')
				BEGIN			
				select @oldNum = BR_RAD from EKIPA where ID_EK = @oldVal
				update EKIPA set BR_RAD = @oldNum - 1 where ID_EK = @oldVal
				END
			else if (@oldVal like '')
				BEGIN
				select @oldNum = BR_RAD from EKIPA where ID_EK = @newVal
				update EKIPA set BR_RAD = @oldNum + 1 where ID_EK = @newVal
				END
	END
END
GO
PRINT N'Creating [dbo].[BrojMagacina]...';


GO
CREATE FUNCTION [dbo].[BrojMagacina]
(
	@id char(13)
)
RETURNS INT
AS
BEGIN
	DECLARE @count INT
	DECLARE @idEkipe varchar(13)
	DECLARE @deo TINYINT
	DECLARE @sum INT
	set @sum = 0
	select @idEkipe = EKIPA_ID_EK from RADNIIK where JMBG_ZAP = @id
	IF @idEkipe is not null
		BEGIN
			SELECT @sum = COUNT(*) FROM NALAZI_U WHERE EKIPA_ID_EK = @idEkipe
		 END
	RETURN @sum
END
GO
PRINT N'Creating [dbo].[BrojRezervisanihDelova]...';


GO
CREATE PROCEDURE [dbo].[BrojRezervisanihDelova]
    @id CHAR(13),
	@sum INT out
AS
	BEGIN
	DECLARE @count INT
	DECLARE @idEkipe varchar(13)
	DECLARE @deo TINYINT

	SET @sum = 0

	select @idEkipe = EKIPA_ID_EK from RADNIIK where JMBG_ZAP = @id
	IF @idEkipe is not null
		BEGIN
			DECLARE Deo_CURSOR CURSOR
			FOR SELECT DEO_OPREME_ID_TIP FROM NALAZI_U WHERE EKIPA_ID_EK = @idEkipe

			OPEN Deo_CURSOR;

			FETCH NEXT FROM Deo_CURSOR
			INTO @deo;
			WHILE @@FETCH_STATUS = 0
			BEGIN
				SET @sum += 1;
				FETCH NEXT FROM Deo_CURSOR INTO @deo
			END;

			CLOSE Deo_CURSOR;
			DEALLOCATE Deo_CURSOR;
		 END
END
GO
PRINT N'Creating [dbo].[ProsecnaDubina]...';


GO
CREATE PROCEDURE [dbo].[ProsecnaDubina]
 @id char(13), @avg decimal out
 as 
 begin
	declare @idEkipe varchar(10)
	declare @sum decimal
	declare @deo tinyint
	declare @counter decimal
	declare @temp tinyint

	set @sum = 0
	set @avg = 0


			select @idEkipe = EKIPA_ID_EK from RADNIIK where JMBG_ZAP = @id
			set @counter = 0
			set @avg = 0
			if @idEkipe is not null
			Begin
			DECLARE Deo_CURSOR CURSOR
				FOR SELECT DEO_OPREME_ID_TIP FROM NALAZI_U WHERE EKIPA_ID_EK = @idEkipe

				OPEN Deo_CURSOR;

				FETCH NEXT FROM Deo_CURSOR
				INTO @deo
				WHILE @@FETCH_STATUS = 0
				BEGIN
					if @deo is not null
					begin
					set @counter += 1
					SELECT @temp = DUBINA from DEO_OPREME where ID_TIP = @deo
					set @sum += CAST (@temp as decimal)
					FETCH NEXT FROM Deo_CURSOR INTO @deo
					end
				END
				set @avg = @sum / @counter
				CLOSE Deo_CURSOR;
				DEALLOCATE Deo_CURSOR
				end
end
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
PRINT N'Update complete.';


GO
