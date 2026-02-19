CREATE TABLE [dbo].[Menus] (
    [idRestaurante] UNIQUEIDENTIFIER NULL,
    [idProducto]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [FK_Menus_Productos] FOREIGN KEY ([idProducto]) REFERENCES [dbo].[Productos] ([Id]),
    CONSTRAINT [FK_Menus_Restaurantes] FOREIGN KEY ([idRestaurante]) REFERENCES [dbo].[Restaurantes] ([Id])
);

