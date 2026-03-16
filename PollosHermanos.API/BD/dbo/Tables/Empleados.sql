CREATE TABLE [dbo].[Empleados] (
    [idUsuario]     UNIQUEIDENTIFIER NOT NULL,
    [Nombre]        NVARCHAR (80)    NOT NULL,
    [idRestaurante] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([idUsuario] ASC),
    CONSTRAINT [FK_Empleados_Restaurantes] FOREIGN KEY ([idRestaurante]) REFERENCES [dbo].[Restaurantes] ([Id]),
    CONSTRAINT [FK_Empleados_Usuarios] FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

