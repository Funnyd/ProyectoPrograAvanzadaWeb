CREATE PROCEDURE ObtenerPromociones
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Promociones.Id,
        Productos.Nombre AS Producto,
        Promociones.PorcentajeDescuento,
        Promociones.FechaVencimiento,
        Promociones.PromocionValida
    FROM          Promociones INNER JOIN
							  Productos ON Promociones.idProducto = Productos.Id
END