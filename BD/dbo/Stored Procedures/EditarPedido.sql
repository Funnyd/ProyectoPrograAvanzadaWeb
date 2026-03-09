
   CREATE PROCEDURE EditarPedido
   	@Id AS UNIQUEIDENTIFIER,
	@idCliente AS UNIQUEIDENTIFIER,
   	@idRestaurante AS UNIQUEIDENTIFIER,
	@Total AS DECIMAL(10,2),
	@Estado AS NVARCHAR(MAX),
	@Fecha AS DATE
	 AS
	 BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].Pedidos
          SET idCliente = @idCliente
			 ,idRestaurante = @idRestaurante
			 ,Total = @Total
			 ,Estado = @Estado
			 ,FechaPedido = @Fecha
        WHERE Id = @Id
        SELECT @Id
	COMMIT TRANSACTION
END