
         CREATE PROCEDURE ObtenerEmpleadoPorId
		 @Id AS UNIQUEIDENTIFIER

	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Empleados.idUsuario, Empleados.Nombre, Restaurantes.Ubicacion AS Ubicacion, Usuarios.Correo AS Correo
	   FROM          Empleados 
					 INNER JOIN		  Usuarios ON Empleados.idUsuario = Usuarios.Id
					 INNER JOIN		  Restaurantes ON Empleados.idRestaurante = Restaurantes.Id 
					 WHERE Empleados.idUsuario = @Id ;

END