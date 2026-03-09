
	CREATE PROCEDURE EliminarEmpleado
	 @idUsuario AS UNIQUEIDENTIFIER
	  AS
	  BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
	DELETE
	FROM            Empleados
	WHERE Empleados.idUsuario = @idUsuario 
	SELECT @idUsuario
COMMIT TRANSACTION

END