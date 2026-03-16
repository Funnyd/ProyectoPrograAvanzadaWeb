
	CREATE PROCEDURE EliminarMenu
   	@idRestaurante AS UNIQUEIDENTIFIER,
	@idProducto AS UNIQUEIDENTIFIER
	  AS
	  BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
	DELETE
	FROM            Menus
	WHERE Menus.idRestaurante = @idRestaurante AND Menus.idProducto = @idProducto
	SELECT @idRestaurante
COMMIT TRANSACTION

END