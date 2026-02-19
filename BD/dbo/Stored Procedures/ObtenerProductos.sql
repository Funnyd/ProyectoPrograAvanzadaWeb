
/* =========================================================
   PRODUCTOS
   ========================================================= */

      CREATE PROCEDURE ObtenerProductos
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Id, Nombre, Precio, Descripcion
	   FROM          Productos

END