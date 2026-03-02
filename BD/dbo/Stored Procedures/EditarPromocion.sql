CREATE PROCEDURE EditarPromocion
    @Id UNIQUEIDENTIFIER,
    @idProducto UNIQUEIDENTIFIER,
    @PorcentajeDescuento DECIMAL(5,2),
    @FechaVencimiento DATE,
    @PromocionValida BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Promociones
    SET idProducto = @idProducto,
        PorcentajeDescuento = @PorcentajeDescuento,
        FechaVencimiento = @FechaVencimiento,
        PromocionValida = @PromocionValida
    WHERE Id = @Id;

    SELECT @Id;
END