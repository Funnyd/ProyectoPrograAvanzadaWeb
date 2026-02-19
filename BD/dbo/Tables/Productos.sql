CREATE TABLE [dbo].[Productos] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Nombre]      NVARCHAR (80)    NOT NULL,
    [Precio]      DECIMAL (10, 2)  NOT NULL,
    [Descripcion] NVARCHAR (80)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

