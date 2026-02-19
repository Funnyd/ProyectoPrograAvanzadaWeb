
	CREATE PROCEDURE ObtenerRestaurantePorId
	 @Id AS UNIQUEIDENTIFIER
	 AS
	 BEGIN

	 SET NOCOUNT ON;
	   SELECT        Id, Ubicacion
	   FROM          Restaurantes
	   WHERE		 Id = @Id 

END