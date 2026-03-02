CREATE PROCEDURE ObtenerPromociones
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        idProducto,
        PorcentajeDescuento,
        FechaVencimiento,
        PromocionValida
    FROM Promociones;
END