CREATE PROCEDURE CrearUsuarioCliente
    @Id AS UNIQUEIDENTIFIER,
    @Correo AS NVARCHAR(MAX),
    @Password AS NVARCHAR(MAX),
    @idRol AS UNIQUEIDENTIFIER,
    @Nombre AS NVARCHAR(MAX),
    @Direccion AS NVARCHAR(MAX),
    @MetodoPago AS NVARCHAR(MAX)
AS
BEGIN

SET NOCOUNT ON;
    BEGIN TRY

    INSERT INTO [dbo].Usuarios
           (Id,
            Correo,
            Password,
            idRol)
     VALUES
           (@Id,
            @Correo,
            @Password,
            @idRol)

    INSERT INTO [dbo].Clientes
           (idUsuario,
            Nombre,
            Direccion,
            MetodoPago)
     VALUES
           (@Id,
            @Nombre,
            @Direccion,
            @MetodoPago)

    COMMIT TRANSACTION

    SELECT @Id AS IdUsuario

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    THROW
END CATCH

END