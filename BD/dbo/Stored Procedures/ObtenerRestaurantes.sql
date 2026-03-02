CREATE PROCEDURE ObtenerRestaurantes
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Id, Ubicacion
	   FROM          Restaurantes

END