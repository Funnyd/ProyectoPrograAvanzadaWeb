
	CREATE PROCEDURE EditarRestaurante
	 @Id AS UNIQUEIDENTIFIER,
	 @Ubicacion AS NVARCHAR(MAX)
	  AS
	  BEGIN

	  SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].[Restaurantes]
          SET [Ubicacion] = @Ubicacion
        WHERE Id = @Id
        SELECT @Id
COMMIT TRANSACTION
END