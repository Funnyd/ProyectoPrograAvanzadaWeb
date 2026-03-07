
   CREATE PROCEDURE EditarEmpleado
   	@idUsuario AS UNIQUEIDENTIFIER,
	@Nombre AS NVARCHAR(MAX),
	@idRestaurante AS NVARCHAR(MAX)
	 AS
	 BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].Empleados
          SET Nombre = @Nombre
			 ,@idRestaurante = @idRestaurante
        WHERE idUsuario = @idUsuario
        SELECT @idUsuario
	COMMIT TRANSACTION
END