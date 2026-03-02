CREATE PROCEDURE CrearPromocion
    @Id UNIQUEIDENTIFIER,
    @idProducto UNIQUEIDENTIFIER,
    @PorcentajeDescuento DECIMAL(5,2),
    @FechaVencimiento DATE,
    @PromocionValida BIT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Promociones (Id, idProducto, PorcentajeDescuento, FechaVencimiento, PromocionValida)
    VALUES (@Id, @idProducto, @PorcentajeDescuento, @FechaVencimiento, @PromocionValida);

    SELECT @Id;
END