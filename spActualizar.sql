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
-- Description:	Actualizar un registro en la tabla tblExamen dado un Id, Nombre y Descripcion.
-- =============================================
CREATE PROCEDURE spActualizar
	@Id INT,
	@Nombre NVARCHAR(255),
	@Descripcion NVARCHAR(255)
AS
BEGIN
	DECLARE @RC int; -- Código de retorno
	BEGIN TRY
		UPDATE BdiExamen.dbo.tblExamen SET Nombre = @Nombre, Descripcion = @Descripcion 
		WHERE idExamen = @Id;
		SELECT 'Registro actualizado satisfactoriamente';
		SET @RC = 0;
	END TRY

	BEGIN CATCH
		PRINT Error_Number();
		PRINT Error_Message();
		SET @RC = -1;
	END CATCH
	RETURN @RC
END
GO
