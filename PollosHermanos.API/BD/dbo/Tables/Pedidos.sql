CREATE TABLE [dbo].[Pedidos] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [idCliente]     UNIQUEIDENTIFIER NOT NULL,
    [idRestaurante] UNIQUEIDENTIFIER NOT NULL,
    [Total]         DECIMAL (10, 2)  NOT NULL,
    [Estado]        NVARCHAR (20)    NOT NULL,
    [FechaPedido]   DATE             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY ([idCliente]) REFERENCES [dbo].[Clientes] ([idUsuario]),
    CONSTRAINT [FK_Pedidos_Restaurantes] FOREIGN KEY ([idRestaurante]) REFERENCES [dbo].[Restaurantes] ([Id])
);

