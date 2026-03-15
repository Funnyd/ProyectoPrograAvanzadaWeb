
	CREATE PROCEDURE ObtenerUsuarioPorId
	 @Id AS UNIQUEIDENTIFIER
	 AS
	 BEGIN

	 SET NOCOUNT ON;
	   SELECT        Usuarios.Id, Usuarios.Correo, Usuarios.Password, Roles.Rol AS Rol
	   FROM          Usuarios INNER JOIN
							  Roles ON Usuarios.idRol = Roles.Id
	   WHERE Usuarios.Id = @Id 

END