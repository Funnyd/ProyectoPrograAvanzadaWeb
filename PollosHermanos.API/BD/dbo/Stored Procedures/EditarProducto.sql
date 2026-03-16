
	CREATE PROCEDURE EditarProducto
	 @Id AS UNIQUEIDENTIFIER,
	@Nombre AS NVARCHAR(MAX),
	@Precio AS DECIMAL(10,2),
	@Descripcion AS NVARCHAR(MAX)
	  AS
	  BEGIN

	  SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].[Productos]
          SET [Nombre] = @Nombre
			 ,[Precio] = @Precio
			 ,[Descripcion] = @Descripcion
        WHERE Id = @Id
        SELECT @Id
COMMIT TRANSACTION
END