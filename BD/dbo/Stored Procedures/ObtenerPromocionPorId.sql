CREATE PROCEDURE ObtenerPromocionPorId
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        idProducto,
        PorcentajeDescuento,
        FechaVencimiento,
        PromocionValida
    FROM Promociones
    WHERE Id = @Id;
END