
         CREATE PROCEDURE ObtenerMenus
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Restaurantes.Ubicacion AS Restaurante, Productos.Nombre AS Producto
	   FROM          Menus INNER JOIN Restaurantes ON Menus.idRestaurante = Restaurantes.Id
						   INNER JOIN Productos ON Menus.idProducto = Productos.Id

END