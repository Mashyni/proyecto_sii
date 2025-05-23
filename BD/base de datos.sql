USE [InvernaderoControlado]
GO
/****** Object:  Table [dbo].[NombrePlantas]    Script Date: 23/05/2025 20:43:10 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 23/05/2025 20:43:10 ******/
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
/****** Object:  Table [dbo].[TiposPlanta]    Script Date: 23/05/2025 20:43:10 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 23/05/2025 20:43:10 ******/
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
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RolID], [NombreRol]) VALUES (1, N'admin')
INSERT [dbo].[Roles] ([RolID], [NombreRol]) VALUES (2, N'usuario')
INSERT [dbo].[Roles] ([RolID], [NombreRol]) VALUES (3, N'invitado')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NombreUsuario], [Contraseña], [RolID]) VALUES (1, N'admin', N'admin', N'admin', N'admin', N'YWRtaW4=', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuarios__6B0F5AE09D2BD8AE]    Script Date: 23/05/2025 20:43:10 ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[NombrePlantas] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[NombrePlantas]  WITH CHECK ADD FOREIGN KEY([TipoID])
REFERENCES [dbo].[TiposPlanta] ([TipoID])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([RolID])
REFERENCES [dbo].[Roles] ([RolID])
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_usuario]    Script Date: 23/05/2025 20:43:10 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_editar_usuario]    Script Date: 23/05/2025 20:43:10 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_eliminar_usuario]    Script Date: 23/05/2025 20:43:10 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_insertar_usuario]    Script Date: 23/05/2025 20:43:10 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_mostrar_usuarios]    Script Date: 23/05/2025 20:43:10 ******/
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
/****** Object:  StoredProcedure [dbo].[validar_usuario]    Script Date: 23/05/2025 20:43:10 ******/
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
