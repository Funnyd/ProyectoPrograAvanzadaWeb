CREATE PROCEDURE [dbo].[ObtenerUsuario]

@Nombre NVARCHAR(MAX),
@Correo NVARCHAR(MAX)

AS
BEGIN

SET NOCOUNT ON;

SELECT  
        U.Id,
        U.Correo,
        U.Password,
        U.idRol,
        C.Nombre
FROM Usuarios U
INNER JOIN Clientes C 
    ON U.Id = C.idUsuario
WHERE 
    C.Nombre = @Nombre
AND U.Correo = @Correo

END