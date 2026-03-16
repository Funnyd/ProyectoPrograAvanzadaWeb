
   CREATE PROCEDURE CrearPedido
   	@Id AS UNIQUEIDENTIFIER,
	@idCliente AS UNIQUEIDENTIFIER,
   	@idRestaurante AS UNIQUEIDENTIFIER,
	@Total AS DECIMAL(10,2),
	@Estado AS NVARCHAR(MAX),
	@Fecha AS DATE
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].Pedidos
               (Id, 
			    idCliente,
			    idRestaurante,
				Total,
				Estado,
				FechaPedido)
         VALUES
               (@Id, 
			    @idCliente,
			    @idRestaurante,
				@Total,
				@Estado,
				@Fecha)
    SELECT @Id
	COMMIT TRANSACTION
END