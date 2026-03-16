
   CREATE PROCEDURE EditarReserva
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
       UPDATE [dbo].Reservas
          SET idCliente = @idCliente
			 ,idRestaurante = @idRestaurante
			 ,CantidadPersonas = @Cantidad
			 ,Estado = @Estado
			 ,FechaReserva = @Fecha
        WHERE Id = @Id
        SELECT @Id
	COMMIT TRANSACTION
END