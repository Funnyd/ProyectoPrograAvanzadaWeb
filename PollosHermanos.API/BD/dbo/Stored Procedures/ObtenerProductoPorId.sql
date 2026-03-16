
	CREATE PROCEDURE ObtenerProductoPorId
	 @Id AS UNIQUEIDENTIFIER
	 AS
	 BEGIN

	 SET NOCOUNT ON;
	   SELECT        Id, Nombre, Precio, Descripcion
	   FROM          Productos
	   WHERE		 Id = @Id 

END