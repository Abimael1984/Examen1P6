﻿CREATE PROCEDURE [dbo].[ParametroActualizar]
	 @Id_Parametro INT,
	 @Codigo VARCHAR(250) NULL,
	 @Descripcion VARCHAR(250) NULL,
	 @Valor VARCHAR(250) NOT NULL,
	 @Estado BIT NOT NULL

AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA
		BEGIN TRY
			UPDATE dbo.Parametro SET
				 Codigo = @Codigo
				,Descripcion = @Descripcion
				,Valor = @Valor
				,Estado = @Estado
			WHERE 
				Id_Parametro = @Id_Parametro

			COMMIT TRANSACTION TRASA 
			SELECT 0 AS CodeError, ' ' AS MsgError

		END TRY

	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS CodeError,
			ERROR_MESSAGE() AS MsgError
		
			ROLLBACK TRANSACTION TRASA

	END CATCH
END
