
   CREATE PROCEDURE CrearProducto
	@Id AS UNIQUEIDENTIFIER,
	@Nombre AS NVARCHAR(MAX),
	@Precio AS DECIMAL(10,2),
	@Descripcion AS NVARCHAR(MAX)
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].[Productos]
               ([Id]
               ,[Nombre],
			    [Precio],
				[Descripcion])
         VALUES
               (@Id
               ,@Nombre,
			    @Precio,
				@Descripcion)
    SELECT @Id
	COMMIT TRANSACTION
END