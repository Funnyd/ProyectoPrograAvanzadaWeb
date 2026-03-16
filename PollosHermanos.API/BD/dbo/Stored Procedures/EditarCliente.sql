
   CREATE PROCEDURE EditarCliente
   	@idUsuario AS UNIQUEIDENTIFIER,
	@Nombre AS NVARCHAR(MAX),
	@Direccion AS NVARCHAR(MAX),
	@MetodoPago AS NVARCHAR(MAX)
	 AS
	 BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].Clientes
          SET Nombre = @Nombre
			 ,Direccion = @Direccion
			 ,MetodoPago = @MetodoPago
        WHERE idUsuario = @idUsuario
        SELECT @idUsuario
	COMMIT TRANSACTION
END