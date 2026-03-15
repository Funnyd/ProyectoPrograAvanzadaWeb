
   CREATE PROCEDURE CrearMenu
   	@idRestaurante AS UNIQUEIDENTIFIER,
	@idProducto AS UNIQUEIDENTIFIER
   
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].Menus
               (idRestaurante,
			    idProducto)
         VALUES
               (@idRestaurante,
			    @idProducto)
    SELECT @idRestaurante
	COMMIT TRANSACTION
END