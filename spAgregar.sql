-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sarid García Pérez
-- Create date: Mayo 25, 2023
-- Description:	Insertar un registro en la tabla exámen con parametros ID, Nombre y Descripción.
-- =============================================
CREATE PROCEDURE spAgregar
	@Nombre NVARCHAR(255),
	@Descripcion NVARCHAR(255)
AS
BEGIN
	DECLARE @RC int; -- Código de retorno

	BEGIN TRY
		INSERT INTO BdiExamen.dbo.tblExamen (Nombre, Descripcion) VALUES (@Nombre, @Descripcion);
		SELECT 'Registro insertado satisfactoriamente';
		SET @RC = 0;
	END TRY

	BEGIN CATCH
		PRINT Error_Number();
		PRINT Error_Message();
		SET @RC = -1;
	END CATCH

	RETURN @RC;
END
GO
