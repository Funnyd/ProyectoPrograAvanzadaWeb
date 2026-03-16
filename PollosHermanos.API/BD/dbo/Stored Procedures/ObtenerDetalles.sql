
         CREATE PROCEDURE ObtenerDetalles
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Pedidos.Id AS idPedido, Productos.Nombre AS Producto, DetallesPedidos.Cantidad, DetallesPedidos.PrecioUnitario
	   FROM          DetallesPedidos INNER JOIN Pedidos ON DetallesPedidos.idPedido = Pedidos.Id
									 INNER JOIN Productos ON DetallesPedidos.idProducto = Productos.Id

END