
   CREATE PROCEDURE EditarDetalle
   	@idPedido AS UNIQUEIDENTIFIER,
	@idProducto AS UNIQUEIDENTIFIER,
   	@idPedidoNuevo AS UNIQUEIDENTIFIER,
	@idProductoNuevo AS UNIQUEIDENTIFIER,
	@Cantidad AS INT,
	@PrecioUnitario AS DECIMAL(10,2)
	 AS
	 BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].DetallesPedidos
          SET idPedido = @idPedidoNuevo
			 ,idProducto = @idProductoNuevo
			 ,Cantidad = @Cantidad
			 ,PrecioUnitario = @PrecioUnitario
        WHERE idPedido = @idPedido AND idProducto = @idProducto
        SELECT @idPedido
	COMMIT TRANSACTION
END