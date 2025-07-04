USE [InvernaderoControlado]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdPlanta] [int] NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](10, 2) NOT NULL,
	[Subtotal] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NombrePlantas]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NombrePlantas](
	[PlantaID] [int] IDENTITY(1,1) NOT NULL,
	[NombrePlanta] [nvarchar](100) NOT NULL,
	[TipoID] [int] NULL,
	[CantidadStock] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[Estado] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlantaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plantas]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plantas](
	[IdPlanta] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IdCategoria] [int] NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPlanta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RolID] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposPlanta]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposPlanta](
	[TipoID] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipo] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[ApellidoPaterno] [varchar](100) NOT NULL,
	[ApellidoMaterno] [varchar](100) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Contraseña] [varchar](100) NOT NULL,
	[RolID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[FechaVenta] [datetime] NULL,
	[Total] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RolID], [NombreRol]) VALUES (1, N'Administrador')
INSERT [dbo].[Roles] ([RolID], [NombreRol]) VALUES (2, N'Supervisor')
INSERT [dbo].[Roles] ([RolID], [NombreRol]) VALUES (3, N'Trabajador')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NombreUsuario], [Contraseña], [RolID]) VALUES (1, N'admin', N'admin', N'admin', N'admin', N'YWRtaW4=', 1)
INSERT [dbo].[Usuarios] ([idUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NombreUsuario], [Contraseña], [RolID]) VALUES (2, N'marco', N'hua', N'aru', N'marco', N'bWFyY28=', 2)
INSERT [dbo].[Usuarios] ([idUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NombreUsuario], [Contraseña], [RolID]) VALUES (1005, N'carlos', N'car', N'car', N'carlos', N'Y2FybG9z', 3)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuarios__6B0F5AE09D2BD8AE]    Script Date: 25/05/2025 16:15:39 ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[NombrePlantas] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Plantas] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Ventas] ADD  DEFAULT (getdate()) FOR [FechaVenta]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdPlanta])
REFERENCES [dbo].[Plantas] ([IdPlanta])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Ventas] ([IdVenta])
GO
ALTER TABLE [dbo].[NombrePlantas]  WITH CHECK ADD FOREIGN KEY([TipoID])
REFERENCES [dbo].[TiposPlanta] ([TipoID])
GO
ALTER TABLE [dbo].[Plantas]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([RolID])
REFERENCES [dbo].[Roles] ([RolID])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCategoria]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar Categoria
CREATE PROCEDURE [dbo].[sp_ActualizarCategoria]
    @IdCategoria INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(100)
AS
BEGIN
    UPDATE Categorias SET
        Nombre = @Nombre,
        Descripcion = @Descripcion
    WHERE IdCategoria = @IdCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCliente]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar Cliente
CREATE PROCEDURE [dbo].[sp_ActualizarCliente]
    @IdCliente INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Direccion VARCHAR(100),
    @Telefono VARCHAR(15),
    @Email VARCHAR(50)
AS
BEGIN
    UPDATE Clientes SET
        Nombre = @Nombre,
        Apellido = @Apellido,
        Direccion = @Direccion,
        Telefono = @Telefono,
        Email = @Email
    WHERE IdCliente = @IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarPlanta]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar Planta
CREATE PROCEDURE [dbo].[sp_ActualizarPlanta]
    @IdPlanta INT,
    @Nombre VARCHAR(50),
    @IdCategoria INT,
    @Precio DECIMAL(10,2),
    @Stock INT,
    @Descripcion VARCHAR(200)
AS
BEGIN
    UPDATE Plantas SET
        Nombre = @Nombre,
        IdCategoria = @IdCategoria,
        Precio = @Precio,
        Stock = @Stock,
        Descripcion = @Descripcion
    WHERE IdPlanta = @IdPlanta
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarStock]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar Stock
CREATE PROCEDURE [dbo].[sp_ActualizarStock]
    @IdPlanta INT,
    @Cantidad INT
AS
BEGIN
    UPDATE Plantas SET
        Stock = Stock - @Cantidad
    WHERE IdPlanta = @IdPlanta
END
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_usuario]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_buscar_usuario]
    @Campo VARCHAR(100),
    @TextoBuscar VARCHAR(100)
AS
BEGIN
    DECLARE @Consulta NVARCHAR(MAX)
    SET @Consulta = '
        SELECT u.idUsuario, u.Nombre, u.ApellidoPaterno, u.ApellidoMaterno,
               u.NombreUsuario, u.Contraseña, r.NombreRol
        FROM Usuarios u
        INNER JOIN Roles r ON u.RolID = r.RolID
        WHERE u.' + QUOTENAME(@Campo) + ' LIKE @TextoBuscar'
    
    EXEC sp_executesql @Consulta, N'@TextoBuscar VARCHAR(100)', @TextoBuscar
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarCategoria]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Buscar Categoria por ID
CREATE PROCEDURE [dbo].[sp_BuscarCategoria]
    @IdCategoria INT
AS
BEGIN
    SELECT IdCategoria, Nombre, Descripcion FROM Categorias
    WHERE IdCategoria = @IdCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarCliente]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Buscar Cliente por ID
CREATE PROCEDURE [dbo].[sp_BuscarCliente]
    @IdCliente INT
AS
BEGIN
    SELECT IdCliente, Nombre, Apellido, Direccion, Telefono, Email FROM Clientes
    WHERE IdCliente = @IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarPlanta]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Buscar Planta por ID
CREATE PROCEDURE [dbo].[sp_BuscarPlanta]
    @IdPlanta INT
AS
BEGIN
    SELECT p.IdPlanta, p.Nombre, p.IdCategoria, c.Nombre AS Categoria, p.Precio, p.Stock, p.Descripcion
    FROM Plantas p
    INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
    WHERE p.IdPlanta = @IdPlanta
END
GO
/****** Object:  StoredProcedure [dbo].[sp_editar_usuario]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_editar_usuario]
    @idUsuario INT,
    @Nombre VARCHAR(100),
    @ApellidoPaterno VARCHAR(100),
    @ApellidoMaterno VARCHAR(100),
    @NombreUsuario VARCHAR(50),
    @Contraseña VARCHAR(100),
    @RolID INT
AS
BEGIN
    UPDATE Usuarios
    SET Nombre = @Nombre,
        ApellidoPaterno = @ApellidoPaterno,
        ApellidoMaterno = @ApellidoMaterno,
        NombreUsuario = @NombreUsuario,
        Contraseña = @Contraseña,
        RolID = @RolID
    WHERE idUsuario = @idUsuario
END

GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_usuario]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_eliminar_usuario]
    @idUsuario INT
AS
BEGIN
    DELETE FROM Usuarios WHERE idUsuario = @idUsuario
END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar Categoria
CREATE PROCEDURE [dbo].[sp_EliminarCategoria]
    @IdCategoria INT
AS
BEGIN
    DELETE FROM Categorias WHERE IdCategoria = @IdCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCliente]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar Cliente
CREATE PROCEDURE [dbo].[sp_EliminarCliente]
    @IdCliente INT
AS
BEGIN
    DELETE FROM Clientes WHERE IdCliente = @IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPlanta]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar Planta
CREATE PROCEDURE [dbo].[sp_EliminarPlanta]
    @IdPlanta INT
AS
BEGIN
    DELETE FROM Plantas WHERE IdPlanta = @IdPlanta
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_usuario]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertar_usuario]
    @Nombre VARCHAR(100),
    @ApellidoPaterno VARCHAR(100),
    @ApellidoMaterno VARCHAR(100),
    @NombreUsuario VARCHAR(50),
    @Contraseña VARCHAR(100),
    @RolID INT
AS
BEGIN
    INSERT INTO Usuarios (Nombre, ApellidoPaterno, ApellidoMaterno, NombreUsuario, Contraseña, RolID)
    VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @NombreUsuario, @Contraseña, @RolID)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCategoria]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Insertar Categoria
CREATE PROCEDURE [dbo].[sp_InsertarCategoria]
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO Categorias (Nombre, Descripcion)
    VALUES (@Nombre, @Descripcion)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCliente]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insertar Cliente
CREATE PROCEDURE [dbo].[sp_InsertarCliente]
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Direccion VARCHAR(100),
    @Telefono VARCHAR(15),
    @Email VARCHAR(50)
AS
BEGIN
    INSERT INTO Clientes (Nombre, Apellido, Direccion, Telefono, Email)
    VALUES (@Nombre, @Apellido, @Direccion, @Telefono, @Email)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarPlanta]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insertar Planta
CREATE PROCEDURE [dbo].[sp_InsertarPlanta]
    @Nombre VARCHAR(50),
    @IdCategoria INT,
    @Precio DECIMAL(10,2),
    @Stock INT,
    @Descripcion VARCHAR(200)
AS
BEGIN
    INSERT INTO Plantas (Nombre, IdCategoria, Precio, Stock, Descripcion)
    VALUES (@Nombre, @IdCategoria, @Precio, @Stock, @Descripcion)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarVenta]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarVenta]
    @IdCliente INT,
    @Total DECIMAL(10,2),
    @Detalles XML,
    @IdVenta INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Validar parámetros
        IF @IdCliente IS NULL OR NOT EXISTS (SELECT 1 FROM Clientes WHERE IdCliente = @IdCliente)
        BEGIN
            RAISERROR('Cliente no válido', 16, 1);
            RETURN;
        END
        
        -- Insertar la venta
        INSERT INTO Ventas (IdCliente, Total, FechaVenta)
        VALUES (@IdCliente, @Total, GETDATE());
        
        SET @IdVenta = SCOPE_IDENTITY();
        
        -- Insertar detalles con validación
        INSERT INTO DetalleVenta (IdVenta, IdPlanta, Cantidad, PrecioUnitario, Subtotal)
        SELECT 
            @IdVenta,
            CASE WHEN T.Item.value('@IdPlanta', 'NVARCHAR(10)') NOT LIKE '%[^0-9]%' 
                 THEN T.Item.value('@IdPlanta', 'INT') 
                 ELSE NULL END,
            CASE WHEN T.Item.value('@Cantidad', 'NVARCHAR(10)') NOT LIKE '%[^0-9]%' 
                 THEN T.Item.value('@Cantidad', 'INT') 
                 ELSE NULL END,
            CASE WHEN ISNUMERIC(T.Item.value('@PrecioUnitario', 'NVARCHAR(20)')) = 1 
                 THEN CAST(T.Item.value('@PrecioUnitario', 'NVARCHAR(20)') AS DECIMAL(10,2))
                 ELSE NULL END,
            CASE WHEN ISNUMERIC(T.Item.value('@Subtotal', 'NVARCHAR(20)')) = 1 
                 THEN CAST(T.Item.value('@Subtotal', 'NVARCHAR(20)') AS DECIMAL(10,2))
                 ELSE NULL END
        FROM @Detalles.nodes('/Detalles/Detalle') AS T(Item)
        WHERE T.Item.value('@IdPlanta', 'NVARCHAR(10)') NOT LIKE '%[^0-9]%'
          AND T.Item.value('@Cantidad', 'NVARCHAR(10)') NOT LIKE '%[^0-9]%'
          AND ISNUMERIC(T.Item.value('@PrecioUnitario', 'NVARCHAR(20)')) = 1
          AND ISNUMERIC(T.Item.value('@Subtotal', 'NVARCHAR(20)')) = 1;
        
        -- Verificar que se insertaron todos los detalles
        IF @@ROWCOUNT <> (SELECT @Detalles.value('count(/Detalles/Detalle)', 'INT'))
        BEGIN
            RAISERROR('Algunos detalles no pudieron ser procesados', 16, 1);
            ROLLBACK;
            RETURN;
        END
        
        -- Actualizar stock con validación
        UPDATE p
        SET p.Stock = p.Stock - d.Cantidad
        FROM Plantas p
        INNER JOIN (
            SELECT 
                CASE WHEN T.Item.value('@IdPlanta', 'NVARCHAR(10)') NOT LIKE '%[^0-9]%' 
                     THEN T.Item.value('@IdPlanta', 'INT') 
                     ELSE NULL END AS IdPlanta,
                CASE WHEN T.Item.value('@Cantidad', 'NVARCHAR(10)') NOT LIKE '%[^0-9]%' 
                     THEN T.Item.value('@Cantidad', 'INT') 
                     ELSE NULL END AS Cantidad
            FROM @Detalles.nodes('/Detalles/Detalle') AS T(Item)
            WHERE T.Item.value('@IdPlanta', 'NVARCHAR(10)') NOT LIKE '%[^0-9]%'
              AND T.Item.value('@Cantidad', 'NVARCHAR(10)') NOT LIKE '%[^0-9]%'
        ) d ON p.IdPlanta = d.IdPlanta
        WHERE d.IdPlanta IS NOT NULL AND d.Cantidad IS NOT NULL;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        -- Registrar el error
        INSERT INTO ErrorLog (ErrorMessage, ErrorSeverity, ErrorState, ErrorProcedure, ErrorLine, ErrorTime)
        VALUES (@ErrorMessage, @ErrorSeverity, @ErrorState, ERROR_PROCEDURE(), ERROR_LINE(), GETDATE());
        
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
        
        SET @IdVenta = 0;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarCategorias]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Listar Categorias
CREATE PROCEDURE [dbo].[sp_ListarCategorias]
AS
BEGIN
    SELECT IdCategoria, Nombre, Descripcion FROM Categorias
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarClientes]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Listar Clientes
CREATE PROCEDURE [dbo].[sp_ListarClientes]
AS
BEGIN
    SELECT IdCliente, Nombre, Apellido, Direccion, Telefono, Email FROM Clientes
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarPlantas]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Listar Plantas
CREATE PROCEDURE [dbo].[sp_ListarPlantas]
AS
BEGIN
    SELECT p.IdPlanta, p.Nombre, c.IdCategoria, c.Nombre AS Categoria, p.Precio, p.Stock, p.Descripcion
    FROM Plantas p
    INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarVentas]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Listar Ventas
CREATE PROCEDURE [dbo].[sp_ListarVentas]
AS
BEGIN
    SELECT v.IdVenta, c.Nombre + ' ' + c.Apellido AS Cliente, v.FechaVenta, v.Total
    FROM Ventas v
    INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
    ORDER BY v.FechaVenta DESC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_mostrar_usuarios]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_mostrar_usuarios]
AS
BEGIN
    SELECT 
        u.idUsuario,
        u.Nombre,
        u.ApellidoPaterno,
        u.ApellidoMaterno,
        u.NombreUsuario,
        u.Contraseña,
        r.NombreRol
    FROM Usuarios u
    INNER JOIN Roles r ON u.RolID = r.RolID
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDetalleVenta]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Obtener Detalle de Venta
CREATE PROCEDURE [dbo].[sp_ObtenerDetalleVenta]
    @IdVenta INT
AS
BEGIN
    SELECT 
        p.Nombre AS Planta,
        dv.Cantidad,
        dv.PrecioUnitario,
        dv.Subtotal
    FROM DetalleVenta dv
    INNER JOIN Plantas p ON dv.IdPlanta = p.IdPlanta
    WHERE dv.IdVenta = @IdVenta
END
GO
/****** Object:  StoredProcedure [dbo].[validar_usuario]    Script Date: 25/05/2025 16:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[validar_usuario]
    @nombre VARCHAR(50),
    @password_usuario VARCHAR(100),
    @cod_rol INT
AS
BEGIN
    SELECT *
    FROM Usuarios
    WHERE NombreUsuario = @nombre
      AND Contraseña = @password_usuario
      AND RolID = @cod_rol
END

GO
