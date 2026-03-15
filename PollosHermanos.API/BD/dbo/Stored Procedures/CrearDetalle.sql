
   CREATE PROCEDURE CrearDetalle
   	@idPedido AS UNIQUEIDENTIFIER,
	@idProducto AS UNIQUEIDENTIFIER,
	@Cantidad AS INT,
	@PrecioUnitario AS DECIMAL(10,2)
   
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].DetallesPedidos
               (idPedido,
			    idProducto,
				Cantidad,
				PrecioUnitario)
         VALUES
               (@idPedido,
			    @idProducto,
				@Cantidad,
				@PrecioUnitario)
    SELECT @idPedido
	COMMIT TRANSACTION
END