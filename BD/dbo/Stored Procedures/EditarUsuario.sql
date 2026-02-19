
	CREATE PROCEDURE EditarUsuario
	 @Id AS UNIQUEIDENTIFIER,
	@Correo AS NVARCHAR(MAX),
	@Password AS NVARCHAR(MAX),
	@idRol AS UNIQUEIDENTIFIER
	  AS
	  BEGIN

	  SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].Usuarios
          SET Correo = @Correo
			 ,Password = @Password
			 ,idRol = @idRol
        WHERE Id = @Id
        SELECT @Id
COMMIT TRANSACTION
END