CREATE TABLE [dbo].[DetallesPedidos] (
    [idPedido]       UNIQUEIDENTIFIER NOT NULL,
    [idProducto]     UNIQUEIDENTIFIER NOT NULL,
    [Cantidad]       INT NOT NULL,
    [PrecioUnitario] DECIMAL (10, 2)  NOT NULL,
    CONSTRAINT [FK_Detalles_Productos] FOREIGN KEY ([idPedido]) REFERENCES [dbo].[Pedidos] ([Id]),
    CONSTRAINT [FK_Detalles_Restaurantes] FOREIGN KEY ([idProducto]) REFERENCES [dbo].[Productos] ([Id])
);

