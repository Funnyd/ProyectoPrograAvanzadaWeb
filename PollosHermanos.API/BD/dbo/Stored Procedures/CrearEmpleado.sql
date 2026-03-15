
   CREATE PROCEDURE CrearEmpleado
   	@idUsuario AS UNIQUEIDENTIFIER,
	@Nombre AS NVARCHAR(MAX),
	@idRestaurante AS NVARCHAR(MAX)
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].Empleados
               (idUsuario, 
			    Nombre,
			    idRestaurante)
         VALUES
               (@idUsuario,
			    @Nombre,
			    @idRestaurante)
    SELECT @idUsuario
	COMMIT TRANSACTION
END