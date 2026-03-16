
   CREATE PROCEDURE CrearReserva
   	@Id AS UNIQUEIDENTIFIER,
	@idCliente AS UNIQUEIDENTIFIER,
   	@idRestaurante AS UNIQUEIDENTIFIER,
	@Cantidad AS INT,
	@Estado AS NVARCHAR(MAX),
	@Fecha AS DATE
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].Reservas
               (Id, 
			    idCliente,
			    idRestaurante,
				CantidadPersonas,
				Estado,
				FechaReserva)
         VALUES
               (@Id, 
			    @idCliente,
			    @idRestaurante,
				@Cantidad,
				@Estado,
				@Fecha)
    SELECT @Id
	COMMIT TRANSACTION
END