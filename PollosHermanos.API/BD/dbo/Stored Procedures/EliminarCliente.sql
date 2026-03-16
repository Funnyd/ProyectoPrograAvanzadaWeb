
	CREATE PROCEDURE EliminarCliente
	 @idUsuario AS UNIQUEIDENTIFIER
	  AS
	  BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
	DELETE
	FROM            Clientes
	WHERE Clientes.idUsuario = @idUsuario 
	SELECT @idUsuario
COMMIT TRANSACTION

END