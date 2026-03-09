
         CREATE PROCEDURE ObtenerReservas
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Reservas.Id, Reservas.CantidadPersonas, Reservas.Estado,Reservas.FechaReserva, Clientes.Nombre AS Cliente, Restaurantes.Ubicacion AS Restaurante
	   FROM          Reservas INNER JOIN Clientes ON Reservas.idCliente = Clientes.idUsuario
							 INNER JOIN Restaurantes ON Reservas.idRestaurante = Restaurantes.Id 

END