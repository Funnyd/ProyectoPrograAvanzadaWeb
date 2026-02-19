CREATE TABLE [dbo].[Promociones] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [idProducto]          UNIQUEIDENTIFIER NOT NULL,
    [PorcentajeDescuento] UNIQUEIDENTIFIER NOT NULL,
    [FechaVencimiento]    DATE             NOT NULL,
    [PromocionValida]     BIT              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Promociones_Productos] FOREIGN KEY ([idProducto]) REFERENCES [dbo].[Productos] ([Id])
);

