
         CREATE PROCEDURE ObtenerPedidos
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Pedidos.Id, Pedidos.Total, Pedidos.Estado,Pedidos.FechaPedido, Clientes.Nombre AS Cliente, Restaurantes.Ubicacion AS Restaurante
	   FROM          Pedidos INNER JOIN Clientes ON Pedidos.idCliente = Clientes.idUsuario
							 INNER JOIN Restaurantes ON Pedidos.idRestaurante = Restaurantes.Id 

END