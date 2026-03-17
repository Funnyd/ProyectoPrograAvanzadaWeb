CREATE PROCEDURE [dbo].[ObtenerRolxUsuario]

@Correo NVARCHAR(MAX)

AS
BEGIN

SET NOCOUNT ON;

SELECT 
        Roles.Id,
        Roles.Rol
FROM Roles
INNER JOIN Usuarios 
    ON Roles.Id = Usuarios.idRol
WHERE Usuarios.Correo = @Correo

END