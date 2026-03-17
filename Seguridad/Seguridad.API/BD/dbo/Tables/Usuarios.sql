CREATE TABLE [dbo].[Usuarios] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Correo]   NVARCHAR (80)    NOT NULL,
    [Password] NVARCHAR (80)    NOT NULL,
    [idRol]    UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY ([idRol]) REFERENCES [dbo].[Roles] ([Id]),
    UNIQUE NONCLUSTERED ([Correo] ASC)
);

