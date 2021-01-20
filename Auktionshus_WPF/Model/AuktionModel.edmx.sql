
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/08/2020 20:50:11
-- Generated from EDMX file: C:\Users\Jacob\source\repos\Eksamen_Auktionshus\Auktionshus_WPF\Model\AuktionModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AuktionDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccountPurchaseOffer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOffers] DROP CONSTRAINT [FK_AccountPurchaseOffer];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountSalesOffer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOffers] DROP CONSTRAINT [FK_AccountSalesOffer];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesOfferPurchaseOffer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOffers] DROP CONSTRAINT [FK_SalesOfferPurchaseOffer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[PurchaseOffers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseOffers];
GO
IF OBJECT_ID(N'[dbo].[SalesOffers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesOffers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PurchaseOffers'
CREATE TABLE [dbo].[PurchaseOffers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] nvarchar(max)  NOT NULL,
    [AccountId] int  NULL,
    [SalesOfferId] int  NULL
);
GO

-- Creating table 'SalesOffers'
CREATE TABLE [dbo].[SalesOffers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MetalType] int  NOT NULL,
    [Amount] nvarchar(max)  NOT NULL,
    [Deadline] datetime  NOT NULL,
    [AccountId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PurchaseOffers'
ALTER TABLE [dbo].[PurchaseOffers]
ADD CONSTRAINT [PK_PurchaseOffers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SalesOffers'
ALTER TABLE [dbo].[SalesOffers]
ADD CONSTRAINT [PK_SalesOffers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountId] in table 'PurchaseOffers'
ALTER TABLE [dbo].[PurchaseOffers]
ADD CONSTRAINT [FK_AccountPurchaseOffer]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountPurchaseOffer'
CREATE INDEX [IX_FK_AccountPurchaseOffer]
ON [dbo].[PurchaseOffers]
    ([AccountId]);
GO

-- Creating foreign key on [SalesOfferId] in table 'PurchaseOffers'
ALTER TABLE [dbo].[PurchaseOffers]
ADD CONSTRAINT [FK_SalesOfferPurchaseOffer]
    FOREIGN KEY ([SalesOfferId])
    REFERENCES [dbo].[SalesOffers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesOfferPurchaseOffer'
CREATE INDEX [IX_FK_SalesOfferPurchaseOffer]
ON [dbo].[PurchaseOffers]
    ([SalesOfferId]);
GO

-- Creating foreign key on [AccountId] in table 'SalesOffers'
ALTER TABLE [dbo].[SalesOffers]
ADD CONSTRAINT [FK_AccountSalesOffer]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountSalesOffer'
CREATE INDEX [IX_FK_AccountSalesOffer]
ON [dbo].[SalesOffers]
    ([AccountId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------