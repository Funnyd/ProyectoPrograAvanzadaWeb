
	CREATE PROCEDURE EliminarDetalle
   	@idPedido AS UNIQUEIDENTIFIER,
	@idProducto AS UNIQUEIDENTIFIER

	  AS
	  BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
	DELETE
	FROM            DetallesPedidos
	WHERE DetallesPedidos.idPedido = @idPedido AND DetallesPedidos.idProducto = @idProducto
	SELECT @idPedido
COMMIT TRANSACTION

END