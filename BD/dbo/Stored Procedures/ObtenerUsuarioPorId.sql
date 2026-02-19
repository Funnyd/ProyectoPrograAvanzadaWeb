
	CREATE PROCEDURE ObtenerUsuarioPorId
	 @Id AS UNIQUEIDENTIFIER
	 AS
	 BEGIN

	 SET NOCOUNT ON;
	   SELECT        Usuarios.Id, Usuarios.Correo, Usuarios.Password, Usuarios.idRol AS Rol
	   FROM          Usuarios INNER JOIN
							  Roles ON Usuarios.idRol = Roles.Id
	   WHERE Usuarios.Id = @Id 

END