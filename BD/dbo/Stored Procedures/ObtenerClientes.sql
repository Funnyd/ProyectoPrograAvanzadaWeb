
         CREATE PROCEDURE ObtenerClientes
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Clientes.idUsuario, Clientes.Nombre, Clientes.Direccion,Clientes.MetodoPago, Usuarios.Correo AS Correo
	   FROM          Clientes INNER JOIN
							  Usuarios ON Clientes.idUsuario = Usuarios.Id

END