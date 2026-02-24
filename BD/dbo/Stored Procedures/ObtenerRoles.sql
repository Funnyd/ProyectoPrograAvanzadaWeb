
/* =========================================================
   ROLES
   ========================================================= */

         CREATE PROCEDURE ObtenerRoles
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Id, Rol
	   FROM          Roles

END