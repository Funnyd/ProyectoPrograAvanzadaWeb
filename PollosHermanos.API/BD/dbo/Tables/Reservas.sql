CREATE TABLE [dbo].[Reservas] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [idCliente]        UNIQUEIDENTIFIER NOT NULL,
    [idRestaurante]    UNIQUEIDENTIFIER NOT NULL,
    [CantidadPersonas] INT              NOT NULL,
    [Estado]           NVARCHAR (20)    NOT NULL,
    [FechaReserva]     DATE             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reservas_Clientes] FOREIGN KEY ([idCliente]) REFERENCES [dbo].[Clientes] ([idUsuario]),
    CONSTRAINT [FK_Reservas_Restaurantes] FOREIGN KEY ([idRestaurante]) REFERENCES [dbo].[Restaurantes] ([Id])
);

