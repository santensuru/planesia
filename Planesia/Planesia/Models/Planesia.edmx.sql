
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/31/2014 18:38:05
-- Generated from EDMX file: C:\Users\Yusro Tsaqova\Source\Repos\planesia\Planesia\Planesia\Models\Planesia.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PlanesiaDBs];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CampaignUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Campaign] DROP CONSTRAINT [FK_CampaignUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaunaUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fauna] DROP CONSTRAINT [FK_FaunaUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FloraUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flora] DROP CONSTRAINT [FK_FloraUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Campaign]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Campaign];
GO
IF OBJECT_ID(N'[dbo].[Distribution]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Distribution];
GO
IF OBJECT_ID(N'[dbo].[Fauna]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fauna];
GO
IF OBJECT_ID(N'[dbo].[Flora]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Flora];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Campaigns'
CREATE TABLE [dbo].[Campaigns] (
    [CampaignId] int  NOT NULL,
    [CampaignName] varchar(50)  NULL,
    [CampaignDescription] varchar(50)  NULL,
    [CampaignDate] datetime  NULL,
    [UserId] int  NULL,
    [CampaignStatus] varchar(50)  NULL
);
GO

-- Creating table 'Distributions'
CREATE TABLE [dbo].[Distributions] (
    [DistributionArea] int  NOT NULL,
    [DistributionLongitude] float  NULL,
    [DistributionLatitude] float  NULL
);
GO

-- Creating table 'Faunas'
CREATE TABLE [dbo].[Faunas] (
    [FaunaId] int IDENTITY(1,1) NOT NULL,
    [FaunaName] varchar(50)  NULL,
    [FaunaLatinName] varchar(50)  NULL,
    [FaunaDate] datetime  NULL,
    [FaunaDistribution] varchar(50)  NULL,
    [FaunaDiscoverer] varchar(50)  NULL,
    [FaunaOtherDescription] varchar(50)  NULL,
    [FaunaPhoto] varchar(50)  NULL,
    [UserId] int  NULL,
    [FaunaStatus] varchar(50)  NULL
);
GO

-- Creating table 'Floras'
CREATE TABLE [dbo].[Floras] (
    [FloraId] int IDENTITY(1,1) NOT NULL,
    [FloraName] varchar(50)  NULL,
    [FloraLatinName] varchar(50)  NULL,
    [FloraDate] datetime  NULL,
    [FloraDistribution] varchar(50)  NULL,
    [FloraDiscoverer] varchar(50)  NULL,
    [FloraOtherDescription] varchar(50)  NULL,
    [FloraPhoto] varchar(50)  NULL,
    [UserId] int  NULL,
    [FloraStatus] varchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [Birthday] datetime  NULL,
    [Phone] varchar(50)  NULL,
    [Address] varchar(50)  NULL,
    [Photo] varchar(50)  NULL,
    [Gender] varchar(50)  NULL,
    [Username] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [Status] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CampaignId] in table 'Campaigns'
ALTER TABLE [dbo].[Campaigns]
ADD CONSTRAINT [PK_Campaigns]
    PRIMARY KEY CLUSTERED ([CampaignId] ASC);
GO

-- Creating primary key on [DistributionArea] in table 'Distributions'
ALTER TABLE [dbo].[Distributions]
ADD CONSTRAINT [PK_Distributions]
    PRIMARY KEY CLUSTERED ([DistributionArea] ASC);
GO

-- Creating primary key on [FaunaId] in table 'Faunas'
ALTER TABLE [dbo].[Faunas]
ADD CONSTRAINT [PK_Faunas]
    PRIMARY KEY CLUSTERED ([FaunaId] ASC);
GO

-- Creating primary key on [FloraId] in table 'Floras'
ALTER TABLE [dbo].[Floras]
ADD CONSTRAINT [PK_Floras]
    PRIMARY KEY CLUSTERED ([FloraId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Campaigns'
ALTER TABLE [dbo].[Campaigns]
ADD CONSTRAINT [FK_CampaignUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampaignUser'
CREATE INDEX [IX_FK_CampaignUser]
ON [dbo].[Campaigns]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Faunas'
ALTER TABLE [dbo].[Faunas]
ADD CONSTRAINT [FK_FaunaUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FaunaUser'
CREATE INDEX [IX_FK_FaunaUser]
ON [dbo].[Faunas]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Floras'
ALTER TABLE [dbo].[Floras]
ADD CONSTRAINT [FK_FloraUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FloraUser'
CREATE INDEX [IX_FK_FloraUser]
ON [dbo].[Floras]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------