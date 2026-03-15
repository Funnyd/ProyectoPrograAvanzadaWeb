CREATE TABLE [dbo].[Clientes] (
    [idUsuario]  UNIQUEIDENTIFIER NOT NULL,
    [Nombre]     NVARCHAR (80)    NOT NULL,
    [Direccion]  NVARCHAR (80)    NULL,
    [MetodoPago] NVARCHAR (20)    NULL,
    PRIMARY KEY CLUSTERED ([idUsuario] ASC),
    CONSTRAINT [FK_Clientes_Usuarios] FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

