USE [ShyjuDB]
GO

/****** Object: Table [dbo].[School] Script Date: 17-03-2020 17:22:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[School] (
    [Id]   SMALLINT      NOT NULL,
    [Name] NVARCHAR (50) NULL
);


/****** Object: Table [dbo].[Student] Script Date: 17-03-2020 17:24:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [SchoolId] SMALLINT       NOT NULL,
    [Name]     NVARCHAR (50)  NULL,
    [DOB]      DATETIME       NULL,
    [Address]  NVARCHAR (100) NULL
);


