
   CREATE PROCEDURE EditarMenu
   	@idRestaurante AS UNIQUEIDENTIFIER,
	@idProducto AS UNIQUEIDENTIFIER,
   	@idRestauranteNuevo AS UNIQUEIDENTIFIER,
	@idProductoNuevo AS UNIQUEIDENTIFIER
	AS
	 BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].Menus
          SET idRestaurante = @idRestauranteNuevo
			 ,idProducto = @idProductoNuevo
        WHERE idRestaurante = @idRestaurante AND idProducto = @idProducto
        SELECT @idRestaurante
	COMMIT TRANSACTION
END