
         CREATE PROCEDURE ObtenerPedidoPorId
		 @Id AS UNIQUEIDENTIFIER

	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Pedidos.Id, Pedidos.Total, Pedidos.Estado,Pedidos.FechaPedido, Clientes.Nombre AS Cliente, Restaurantes.Ubicacion AS Restaurante
	   FROM          Pedidos INNER JOIN Clientes ON Pedidos.idCliente = Clientes.idUsuario
							 INNER JOIN Restaurantes ON Pedidos.idRestaurante = Restaurantes.Id 
	   WHERE		 Pedidos.Id = @Id 
END