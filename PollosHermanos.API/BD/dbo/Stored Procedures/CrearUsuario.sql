
   CREATE PROCEDURE CrearUsuario
	@Id AS UNIQUEIDENTIFIER,
	@Correo AS NVARCHAR(MAX),
	@Password AS NVARCHAR(MAX),
	@idRol AS UNIQUEIDENTIFIER
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].Usuarios
               (Id
               ,Correo,
			    Password,
				idRol)
         VALUES
               (@Id
               ,@Correo,
			    @Password,
				@idRol)
    SELECT @Id
	COMMIT TRANSACTION
END