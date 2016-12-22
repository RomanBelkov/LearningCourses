
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/22/2016 21:18:32
-- Generated from EDMX file: C:\Users\RB\Documents\GitHub\LearningCourses\SPBU\dotNet\6\MyMovieApp\MyMovieApp\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DirectorMovie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movies] DROP CONSTRAINT [FK_DirectorMovie];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieActor_Movie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieActor] DROP CONSTRAINT [FK_MovieActor_Movie];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieActor_Actor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieActor] DROP CONSTRAINT [FK_MovieActor_Actor];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Movies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movies];
GO
IF OBJECT_ID(N'[dbo].[Directors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Directors];
GO
IF OBJECT_ID(N'[dbo].[Actors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actors];
GO
IF OBJECT_ID(N'[dbo].[MovieActor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieActor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [FilmingCountry] nvarchar(255)  NOT NULL,
    [Year] int  NOT NULL,
    [ImageUrl] nvarchar(255)  NOT NULL,
    [Director1_Id] int  NOT NULL
);
GO

-- Creating table 'Directors'
CREATE TABLE [dbo].[Directors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Actors'
CREATE TABLE [dbo].[Actors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MovieActor'
CREATE TABLE [dbo].[MovieActor] (
    [Movies_Id] int  NOT NULL,
    [Actors_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Directors'
ALTER TABLE [dbo].[Directors]
ADD CONSTRAINT [PK_Directors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Actors'
ALTER TABLE [dbo].[Actors]
ADD CONSTRAINT [PK_Actors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Movies_Id], [Actors_Id] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [PK_MovieActor]
    PRIMARY KEY CLUSTERED ([Movies_Id], [Actors_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Director1_Id] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [FK_DirectorMovie]
    FOREIGN KEY ([Director1_Id])
    REFERENCES [dbo].[Directors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DirectorMovie'
CREATE INDEX [IX_FK_DirectorMovie]
ON [dbo].[Movies]
    ([Director1_Id]);
GO

-- Creating foreign key on [Movies_Id] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [FK_MovieActor_Movie]
    FOREIGN KEY ([Movies_Id])
    REFERENCES [dbo].[Movies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Actors_Id] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [FK_MovieActor_Actor]
    FOREIGN KEY ([Actors_Id])
    REFERENCES [dbo].[Actors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieActor_Actor'
CREATE INDEX [IX_FK_MovieActor_Actor]
ON [dbo].[MovieActor]
    ([Actors_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------