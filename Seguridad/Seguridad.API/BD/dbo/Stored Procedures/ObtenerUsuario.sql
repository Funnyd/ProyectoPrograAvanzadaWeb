CREATE PROCEDURE [dbo].[ObtenerUsuario]

@Correo NVARCHAR(MAX)

AS
BEGIN

SET NOCOUNT ON;

SELECT  
        U.Id,
        U.Correo,
        U.Password,
        U.idRol,
        C.Nombre,
		E.Nombre 
FROM Usuarios U
LEFT JOIN Clientes C 
    ON U.Id = C.idUsuario
LEFT JOIN Empleados E 
    ON U.Id = E.idUsuario
WHERE U.Correo = @Correo

END