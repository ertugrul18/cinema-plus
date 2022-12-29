
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/29/2022 15:22:40
-- Generated from EDMX file: C:\Users\Ertuğrul\source\repos\cinema-plus\cinema-plus\CinemaTicketDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaTicket];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_rezervasyon_filmler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[rezervasyon] DROP CONSTRAINT [FK_rezervasyon_filmler];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[filmler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[filmler];
GO
IF OBJECT_ID(N'[dbo].[musteriler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[musteriler];
GO
IF OBJECT_ID(N'[dbo].[rezervasyon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rezervasyon];
GO
IF OBJECT_ID(N'[dbo].[seanslar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[seanslar];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'filmlers'
CREATE TABLE [dbo].[filmlers] (
    [film_id] int IDENTITY(1,1) NOT NULL,
    [film_adi] nvarchar(50)  NULL,
    [süresi] nvarchar(50)  NULL,
    [vizyon_tarihi] datetime  NULL,
    [tur_adi] nvarchar(50)  NULL,
    [ozet] nvarchar(max)  NULL,
    [imdb_puani] decimal(18,0)  NULL,
    [yapimi] nvarchar(50)  NULL,
    [yonetmen] nvarchar(50)  NULL,
    [dil] nvarchar(10)  NULL,
    [Image] nvarchar(max)  NULL
);
GO

-- Creating table 'rezervasyons'
CREATE TABLE [dbo].[rezervasyons] (
    [rez_id] int IDENTITY(1,1) NOT NULL,
    [musteri_id] int  NULL,
    [film_id] int  NULL,
    [koltuk_no] int  NULL,
    [seans_id] int  NULL
);
GO

-- Creating table 'seanslars'
CREATE TABLE [dbo].[seanslars] (
    [seans_id] int IDENTITY(1,1) NOT NULL,
    [film_id] int  NULL,
    [tarih] datetime  NULL,
    [saat] time  NULL
);
GO

-- Creating table 'musterilers'
CREATE TABLE [dbo].[musterilers] (
    [musteri_id] int IDENTITY(1,1) NOT NULL,
    [musteri_adi] nvarchar(50)  NULL,
    [musteri_soyadi] nvarchar(50)  NULL,
    [tel_no] nvarchar(20)  NULL,
    [eposta] nvarchar(100)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [film_id] in table 'filmlers'
ALTER TABLE [dbo].[filmlers]
ADD CONSTRAINT [PK_filmlers]
    PRIMARY KEY CLUSTERED ([film_id] ASC);
GO

-- Creating primary key on [rez_id] in table 'rezervasyons'
ALTER TABLE [dbo].[rezervasyons]
ADD CONSTRAINT [PK_rezervasyons]
    PRIMARY KEY CLUSTERED ([rez_id] ASC);
GO

-- Creating primary key on [seans_id] in table 'seanslars'
ALTER TABLE [dbo].[seanslars]
ADD CONSTRAINT [PK_seanslars]
    PRIMARY KEY CLUSTERED ([seans_id] ASC);
GO

-- Creating primary key on [musteri_id] in table 'musterilers'
ALTER TABLE [dbo].[musterilers]
ADD CONSTRAINT [PK_musterilers]
    PRIMARY KEY CLUSTERED ([musteri_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [film_id] in table 'rezervasyons'
ALTER TABLE [dbo].[rezervasyons]
ADD CONSTRAINT [FK_rezervasyon_filmler]
    FOREIGN KEY ([film_id])
    REFERENCES [dbo].[filmlers]
        ([film_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_rezervasyon_filmler'
CREATE INDEX [IX_FK_rezervasyon_filmler]
ON [dbo].[rezervasyons]
    ([film_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------