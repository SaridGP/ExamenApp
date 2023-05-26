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
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spEliminar 
	@Id INT
AS
BEGIN
	DECLARE @RC int; -- Código de retorno
	BEGIN TRY
		DELETE FROM BdiExamen.dbo.tblExamen WHERE idExamen = @Id;
		SELECT 'Registro eliminado satisfactoriamente';
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
