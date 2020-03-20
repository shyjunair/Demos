USE [ShyjuDB]
GO

/****** Object: SqlProcedure [dbo].[p_GetStudent] Script Date: 17-03-2020 17:27:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[p_GetStudent]
	@id int = 0
AS
	SELECT * from Student where Id = @id or @id = 0
RETURN 0

GO

/****** Object: SqlProcedure [dbo].[p_GetStudentAge] Script Date: 17-03-2020 17:27:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[p_GetStudentAge]
	@id int = 0
AS
	select Year(getdate()) - year(DOB) from Student where Id = @id
RETURN 0
