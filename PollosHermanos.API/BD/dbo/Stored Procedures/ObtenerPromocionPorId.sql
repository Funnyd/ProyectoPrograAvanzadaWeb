CREATE PROCEDURE ObtenerPromocionPorId
    @Id UNIQUEIDENTIFIER
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
    WHERE Promociones.Id = @Id;
END