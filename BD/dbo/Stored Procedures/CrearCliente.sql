
   CREATE PROCEDURE CrearCliente
   	@idUsuario AS UNIQUEIDENTIFIER,
	@Nombre AS NVARCHAR(MAX),
	@Direccion AS NVARCHAR(MAX),
	@MetodoPago AS NVARCHAR(MAX)
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].Clientes
               (idUsuario, 
			    Nombre,
			    Direccion,
				MetodoPago)
         VALUES
               (@idUsuario,
			    @Nombre,
			    @Direccion,
				@MetodoPago)
    SELECT @idUsuario
	COMMIT TRANSACTION
END