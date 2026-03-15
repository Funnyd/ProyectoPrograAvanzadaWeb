
   CREATE PROCEDURE CrearRestaurante
	@Id AS UNIQUEIDENTIFIER,
	@Ubicacion AS NVARCHAR(MAX)
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].[Restaurantes]
               ([Id]
               ,[Ubicacion])
         VALUES
               (@Id
			   ,@Ubicacion)
    SELECT @Id
	COMMIT TRANSACTION
END