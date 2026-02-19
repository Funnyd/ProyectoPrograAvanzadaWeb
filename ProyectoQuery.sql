IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PollosHermanos')
BEGIN
    CREATE DATABASE PollosHermanos;
END
GO

USE PollosHermanos;
GO

/* =========================================================
   TABLAS
   ========================================================= */

CREATE TABLE Restaurantes (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Ubicacion NVARCHAR(80) NOT NULL,
);
GO

CREATE TABLE Productos (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nombre NVARCHAR(80) NOT NULL,
	Precio DECIMAL(10,2) NOT NULL,
	Descripcion NVARCHAR(80),
);
GO

CREATE TABLE Menus (
    idRestaurante UNIQUEIDENTIFIER,
    idProducto UNIQUEIDENTIFIER,
	CONSTRAINT FK_Menus_Restaurantes
        FOREIGN KEY (idRestaurante) REFERENCES Restaurantes(Id),
	CONSTRAINT FK_Menus_Productos
        FOREIGN KEY (idProducto) REFERENCES Productos(Id)
);
GO

CREATE TABLE Promociones (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    idProducto UNIQUEIDENTIFIER NOT NULL,
	PorcentajeDescuento UNIQUEIDENTIFIER NOT NULL,
	FechaVencimiento DATE NOT NULL,
	PromocionValida BIT,
	CONSTRAINT FK_Promociones_Productos
        FOREIGN KEY (idProducto) REFERENCES Productos(Id),
);
GO

CREATE TABLE Roles (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Rol NVARCHAR(50) NOT NULL UNIQUE,
);
GO

CREATE TABLE Usuarios (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Correo NVARCHAR(80) NOT NULL UNIQUE,
    Password NVARCHAR(80) NOT NULL,
	idRol UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Usuarios_Roles
        FOREIGN KEY (idRol) REFERENCES Roles(Id)
);
GO

CREATE TABLE Empleados (
    idUsuario UNIQUEIDENTIFIER PRIMARY KEY,
    Nombre NVARCHAR(80) NOT NULL,
    idRestaurante UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Empleados_Usuarios
        FOREIGN KEY (idUsuario) REFERENCES Usuarios(Id),
	CONSTRAINT FK_Empleados_Restaurantes
        FOREIGN KEY (idRestaurante) REFERENCES Restaurantes(Id)
);
GO


CREATE TABLE Clientes (
    idUsuario UNIQUEIDENTIFIER PRIMARY KEY,
    Nombre NVARCHAR(80) NOT NULL,
    Direccion NVARCHAR(80),
	MetodoPago NVARCHAR(20),
	CONSTRAINT FK_Clientes_Usuarios
        FOREIGN KEY (idUsuario) REFERENCES Usuarios(Id)
);
GO

CREATE TABLE Reservas (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    idCliente UNIQUEIDENTIFIER NOT NULL,
    idRestaurante UNIQUEIDENTIFIER NOT NULL,
	CantidadPersonas INT NOT NULL,
	Estado NVARCHAR(20) NOT NULL,
	FechaReserva DATE NOT NULL,
	CONSTRAINT FK_Reservas_Clientes
        FOREIGN KEY (idCliente) REFERENCES Clientes(idUsuario),
	CONSTRAINT FK_Reservas_Restaurantes
        FOREIGN KEY (idRestaurante) REFERENCES Restaurantes(Id)
);
GO

CREATE TABLE Pedidos (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    idCliente UNIQUEIDENTIFIER NOT NULL,
    idRestaurante UNIQUEIDENTIFIER NOT NULL,
	Total DECIMAL(10,2) NOT NULL,
	Estado NVARCHAR(20) NOT NULL,
	FechaPedido DATE NOT NULL,
	CONSTRAINT FK_Pedidos_Clientes
        FOREIGN KEY (idCliente) REFERENCES Clientes(idUsuario),
	CONSTRAINT FK_Pedidos_Restaurantes
        FOREIGN KEY (idRestaurante) REFERENCES Restaurantes(Id)
);
GO

CREATE TABLE DetallesPedidos (
    idPedido UNIQUEIDENTIFIER NOT NULL,
    idProducto UNIQUEIDENTIFIER NOT NULL,
	Cantidad UNIQUEIDENTIFIER NOT NULL,
	PrecioUnitario DECIMAL(10,2) NOT NULL,
	CONSTRAINT FK_Detalles_Productos
        FOREIGN KEY (idPedido) REFERENCES Pedidos(Id),
	CONSTRAINT FK_Detalles_Restaurantes
        FOREIGN KEY (idProducto) REFERENCES Productos(Id)
);
GO

/* =========================================================
   PROCEDIMIENTOS
   ========================================================= */

   SET ANSI_NULLS ON
	GO
   SET QUOTED_IDENTIFIER ON
	GO

/* =========================================================
   RESTAURANTES
   ========================================================= */
   CREATE PROCEDURE ObtenerRestaurantes
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Id, Ubicacion
	   FROM          Restaurantes

END
GO

	CREATE PROCEDURE ObtenerRestaurantePorId
	 @Id AS UNIQUEIDENTIFIER
	 AS
	 BEGIN

	 SET NOCOUNT ON;
	   SELECT        Id, Ubicacion
	   FROM          Restaurantes
	   WHERE		 Id = @Id 

END
GO

   CREATE PROCEDURE CrearRestaurante
	@Id AS UNIQUEIDENTIFIER,
	@Ubicacion AS NVARCHAR(MAX)
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].[Restaurantes]
               ([Id]
               ,[Ubicacion])
         VALUES
               (@Id
			   ,@Ubicacion)
    SELECT @Id
	COMMIT TRANSACTION
END
GO

	CREATE PROCEDURE EditarRestaurante
	 @Id AS UNIQUEIDENTIFIER,
	 @Ubicacion AS NVARCHAR(MAX)
	  AS
	  BEGIN

	  SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].[Restaurantes]
          SET [Ubicacion] = @Ubicacion
        WHERE Id = @Id
        SELECT @Id
COMMIT TRANSACTION
END
GO

	CREATE PROCEDURE EliminarRestaurante
	 @Id AS UNIQUEIDENTIFIER
	  AS
	  BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
	DELETE
	FROM            Restaurantes
	WHERE Restaurantes.Id = @Id 
	SELECT @Id
COMMIT TRANSACTION

END
GO

/* =========================================================
   PRODUCTOS
   ========================================================= */

      CREATE PROCEDURE ObtenerProductos
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Id, Nombre, Precio, Descripcion
	   FROM          Productos

END
GO

	CREATE PROCEDURE ObtenerProductoPorId
	 @Id AS UNIQUEIDENTIFIER
	 AS
	 BEGIN

	 SET NOCOUNT ON;
	   SELECT        Id, Nombre, Precio, Descripcion
	   FROM          Productos
	   WHERE		 Id = @Id 

END
GO

   CREATE PROCEDURE CrearProducto
	@Id AS UNIQUEIDENTIFIER,
	@Nombre AS NVARCHAR(MAX),
	@Precio AS DECIMAL(10,2),
	@Descripcion AS NVARCHAR(MAX)
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].[Productos]
               ([Id]
               ,[Nombre],
			    [Precio],
				[Descripcion])
         VALUES
               (@Id
               ,@Nombre,
			    @Precio,
				@Descripcion)
    SELECT @Id
	COMMIT TRANSACTION
END
GO

	CREATE PROCEDURE EditarProducto
	 @Id AS UNIQUEIDENTIFIER,
	@Nombre AS NVARCHAR(MAX),
	@Precio AS DECIMAL(10,2),
	@Descripcion AS NVARCHAR(MAX)
	  AS
	  BEGIN

	  SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].[Productos]
          SET [Nombre] = @Nombre
			 ,[Precio] = @Precio
			 ,[Descripcion] = @Descripcion
        WHERE Id = @Id
        SELECT @Id
COMMIT TRANSACTION
END
GO

	CREATE PROCEDURE EliminarProducto
	 @Id AS UNIQUEIDENTIFIER
	  AS
	  BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
	DELETE
	FROM            Productos
	WHERE Productos.Id = @Id 
	SELECT @Id
COMMIT TRANSACTION

END
GO

/* =========================================================
   USUARIOS
   ========================================================= */

         CREATE PROCEDURE ObtenerUsuarios
	AS
	BEGIN

	SET NOCOUNT ON;
	   SELECT        Usuarios.Id, Usuarios.Correo, Usuarios.Password, Usuarios.idRol AS Rol
	   FROM          Usuarios INNER JOIN
							  Roles ON Usuarios.idRol = Roles.Id

END
GO

	CREATE PROCEDURE ObtenerUsuarioPorId
	 @Id AS UNIQUEIDENTIFIER
	 AS
	 BEGIN

	 SET NOCOUNT ON;
	   SELECT        Usuarios.Id, Usuarios.Correo, Usuarios.Password, Usuarios.idRol AS Rol
	   FROM          Usuarios INNER JOIN
							  Roles ON Usuarios.idRol = Roles.Id
	   WHERE Usuarios.Id = @Id 

END
GO

   CREATE PROCEDURE CrearUsuario
	@Id AS UNIQUEIDENTIFIER,
	@Correo AS NVARCHAR(MAX),
	@Password AS NVARCHAR(MAX),
	@idRol AS UNIQUEIDENTIFIER
	 AS
	 BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
    INSERT INTO [dbo].Usuarios
               (Id
               ,Correo,
			    Password,
				idRol)
         VALUES
               (@Id
               ,@Correo,
			    @Password,
				@idRol)
    SELECT @Id
	COMMIT TRANSACTION
END
GO

	CREATE PROCEDURE EditarUsuario
	 @Id AS UNIQUEIDENTIFIER,
	@Correo AS NVARCHAR(MAX),
	@Password AS NVARCHAR(MAX),
	@idRol AS UNIQUEIDENTIFIER
	  AS
	  BEGIN

	  SET NOCOUNT ON;
	   BEGIN TRANSACTION
       UPDATE [dbo].Usuarios
          SET Correo = @Correo
			 ,Password = @Password
			 ,idRol = @idRol
        WHERE Id = @Id
        SELECT @Id
COMMIT TRANSACTION
END
GO

	CREATE PROCEDURE EliminarUsuario
	 @Id AS UNIQUEIDENTIFIER
	  AS
	  BEGIN

	SET NOCOUNT ON;
	   BEGIN TRANSACTION
	DELETE
	FROM            Usuarios
	WHERE Usuarios.Id = @Id 
	SELECT @Id
COMMIT TRANSACTION

END
GO