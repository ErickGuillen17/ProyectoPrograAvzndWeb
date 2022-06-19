USE [master]
GO
/****** Object:  Database [Worknet]    Script Date: 19/6/2022 17:53:20 ******/
CREATE DATABASE [Worknet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Worknet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Worknet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Worknet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Worknet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Worknet] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Worknet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Worknet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Worknet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Worknet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Worknet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Worknet] SET ARITHABORT OFF 
GO
ALTER DATABASE [Worknet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Worknet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Worknet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Worknet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Worknet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Worknet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Worknet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Worknet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Worknet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Worknet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Worknet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Worknet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Worknet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Worknet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Worknet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Worknet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Worknet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Worknet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Worknet] SET  MULTI_USER 
GO
ALTER DATABASE [Worknet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Worknet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Worknet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Worknet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Worknet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Worknet] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Worknet] SET QUERY_STORE = OFF
GO
USE [Worknet]
GO
/****** Object:  Table [dbo].[BITACORA]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BITACORA](
	[FECHA_HORA] [datetime] NOT NULL,
	[DESCRIPCION_ERROR] [varchar](2500) NOT NULL,
	[CODIGO_ERROR] [bigint] NOT NULL,
	[ORIGEN] [varchar](100) NOT NULL,
	[CONSECUTIVO] [bigint] IDENTITY(1,1) NOT NULL,
	[CORREO_USUARIO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BITACORA] PRIMARY KEY CLUSTERED 
(
	[CONSECUTIVO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CANDIDATO]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CANDIDATO](
	[NOMBRE_CANDIDATO] [varchar](20) NOT NULL,
	[APELLIDO_CANDIDATO] [varchar](90) NOT NULL,
	[EXP_CANDIDATO] [int] NOT NULL,
	[GRADO_ESTUDIO] [varchar](100) NOT NULL,
	[TELEFONO_CANDIDATO] [int] NOT NULL,
	[AREA_INTERES] [bigint] NOT NULL,
	[CORREO_USUARIO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CANDIDATOS] PRIMARY KEY CLUSTERED 
(
	[CORREO_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[ID_CATEGORIA] [bigint] IDENTITY(1,1) NOT NULL,
	[CATEGORIA_DESCRIPCION] [varchar](50) NOT NULL,
 CONSTRAINT [XPKCATEGORIAS] PRIMARY KEY NONCLUSTERED 
(
	[ID_CATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEO]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEO](
	[ID_EMPLEO] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_CATEGORIA] [bigint] NOT NULL,
	[EXP_MINIMA] [int] NOT NULL,
	[GRADO_ESTUDIO] [varchar](50) NOT NULL,
	[COMPANIA] [varchar](50) NOT NULL,
	[EMPLEO_NOMBRE] [varchar](100) NOT NULL,
	[ESTADO_PUESTO] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](2000) NOT NULL,
	[REQUISITOS] [varchar](2000) NOT NULL,
	[CORREO_RECLUTADOR] [varchar](50) NOT NULL,
 CONSTRAINT [XPKEMPLEOS] PRIMARY KEY NONCLUSTERED 
(
	[ID_EMPLEO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RECLUTADOR]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RECLUTADOR](
	[CORREO_RECLUTADOR] [varchar](50) NOT NULL,
	[NOMBRE_RECLUTADOR] [varchar](50) NOT NULL,
	[APELLIDO_RECLUTADOR] [varchar](50) NOT NULL,
	[COMPANIA] [varchar](50) NOT NULL,
	[TELEFONO_RECLUTADOR] [int] NOT NULL,
 CONSTRAINT [PK_RECLUTADORESS] PRIMARY KEY CLUSTERED 
(
	[CORREO_RECLUTADOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[ID_ROL] [bigint] IDENTITY(1,1) NOT NULL,
	[NOMBRE_ROL] [varchar](50) NOT NULL,
 CONSTRAINT [XPKROLES] PRIMARY KEY NONCLUSTERED 
(
	[ID_ROL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOLICITUD]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOLICITUD](
	[ID_SOLICITUD] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_EMPLEO] [bigint] NOT NULL,
	[CORREO_CANDIDATO] [varchar](50) NOT NULL,
	[FECHA_SOLICITUD] [datetime] NOT NULL,
 CONSTRAINT [XPKSOLICITUDES] PRIMARY KEY CLUSTERED 
(
	[ID_SOLICITUD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[CORREO_USUARIO] [varchar](50) NOT NULL,
	[CONTRASENA] [varchar](50) NOT NULL,
	[ID_ROL] [bigint] NOT NULL,
 CONSTRAINT [XPKUSUARIOS] PRIMARY KEY CLUSTERED 
(
	[CORREO_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BITACORA]  WITH CHECK ADD  CONSTRAINT [FK_BITACORA_USUARIOS] FOREIGN KEY([CORREO_USUARIO])
REFERENCES [dbo].[USUARIO] ([CORREO_USUARIO])
GO
ALTER TABLE [dbo].[BITACORA] CHECK CONSTRAINT [FK_BITACORA_USUARIOS]
GO
ALTER TABLE [dbo].[CANDIDATO]  WITH CHECK ADD  CONSTRAINT [FK_CANDIDATOS_CATEGORIAS] FOREIGN KEY([AREA_INTERES])
REFERENCES [dbo].[CATEGORIA] ([ID_CATEGORIA])
GO
ALTER TABLE [dbo].[CANDIDATO] CHECK CONSTRAINT [FK_CANDIDATOS_CATEGORIAS]
GO
ALTER TABLE [dbo].[CANDIDATO]  WITH CHECK ADD  CONSTRAINT [R_8] FOREIGN KEY([CORREO_USUARIO])
REFERENCES [dbo].[USUARIO] ([CORREO_USUARIO])
GO
ALTER TABLE [dbo].[CANDIDATO] CHECK CONSTRAINT [R_8]
GO
ALTER TABLE [dbo].[EMPLEO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEOS_CATEGORIAS] FOREIGN KEY([ID_CATEGORIA])
REFERENCES [dbo].[CATEGORIA] ([ID_CATEGORIA])
GO
ALTER TABLE [dbo].[EMPLEO] CHECK CONSTRAINT [FK_EMPLEOS_CATEGORIAS]
GO
ALTER TABLE [dbo].[EMPLEO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEOS_RECLUTADORES] FOREIGN KEY([CORREO_RECLUTADOR])
REFERENCES [dbo].[RECLUTADOR] ([CORREO_RECLUTADOR])
GO
ALTER TABLE [dbo].[EMPLEO] CHECK CONSTRAINT [FK_EMPLEOS_RECLUTADORES]
GO
ALTER TABLE [dbo].[RECLUTADOR]  WITH CHECK ADD  CONSTRAINT [FK_RECLUTADORES_USUARIOS] FOREIGN KEY([CORREO_RECLUTADOR])
REFERENCES [dbo].[USUARIO] ([CORREO_USUARIO])
GO
ALTER TABLE [dbo].[RECLUTADOR] CHECK CONSTRAINT [FK_RECLUTADORES_USUARIOS]
GO
ALTER TABLE [dbo].[SOLICITUD]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUDES_CANDIDATOS] FOREIGN KEY([CORREO_CANDIDATO])
REFERENCES [dbo].[CANDIDATO] ([CORREO_USUARIO])
GO
ALTER TABLE [dbo].[SOLICITUD] CHECK CONSTRAINT [FK_SOLICITUDES_CANDIDATOS]
GO
ALTER TABLE [dbo].[SOLICITUD]  WITH CHECK ADD  CONSTRAINT [R_6] FOREIGN KEY([ID_EMPLEO])
REFERENCES [dbo].[EMPLEO] ([ID_EMPLEO])
GO
ALTER TABLE [dbo].[SOLICITUD] CHECK CONSTRAINT [R_6]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [R_4] FOREIGN KEY([ID_ROL])
REFERENCES [dbo].[ROL] ([ID_ROL])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [R_4]
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Candidato]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Actualizar_Candidato] @pNombre VARCHAR(50),@pApellido VARCHAR(50),
@pExp INT, @pGradoEstudio VARCHAR(50),@pTelefono INT, @pAreaInteres INT, @pCorreo VARCHAR(50)  
AS
UPDATE CANDIDATOS  
SET [NOMBRE_CANDIDATO] = @pNombre, [APELLIDO_CANDIDATO] = @pApellido, 
[EXP_CANDIDATO] = @pExp,[GRADO_ESTUDIO] = @pGradoEstudio, [TELEFONO_CANDIDATO] = @pTelefono, [AREA_INTERES] = @pAreaInteres
WHERE [CORREO_USUARIO] = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Empleo]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Actualizar_Empleo]
@pEmpleo VARCHAR(100), @pCompania VARCHAR(100), @pRequisitos VARCHAR(500), 
@pDescripcion VARCHAR(500), @pExperiencia INT, @pEstudios VARCHAR(500), @pEstado VARCHAR(200), 
@pCategoria INT, @pIdPuesto INT
AS
UPDATE EMPLEOS
SET [EMPLEO_NOMBRE] = @pEmpleo,
[COMPANIA] = @pCompania, [REQUISITOS] = @pRequisitos, 
[DESCRIPCION] = @pDescripcion, [EXP_MINIMA] = @pExperiencia, 
[GRADO_ESTUDIO] = @pEstudios, [ESTADO_PUESTO] = @pEstado, [ID_CATEGORIA] = @pCategoria
WHERE [ID_EMPLEO] = @pIdPuesto;
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Reclutador]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Actualizar_Reclutador] 
@pNombre VARCHAR(100), @pApellido VARCHAR(100), @pCompania VARCHAR(100), 
@pTelefono INT, @pCorreo VARCHAR(150)
AS
UPDATE RECLUTADORES
SET [NOMBRE_RECLUTADOR] = @pNombre, [APELLIDO_RECLUTADOR] = @pApellido, 
[COMPANIA] = @pCompania,[TELEFONO_RECLUTADOR]= @pTelefono
WHERE [CORREO_RECLUTADOR] = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Buscar_Usuario]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Buscar_Usuario] @pCorreo VARCHAR(50), @pContrasena VARCHAR(50)
AS
SELECT * FROM [dbo].[USUARIOS] U
WHERE u.[CORREO_USUARIO] = @pCorreo AND u.[CONTRASENA] = @pContrasena;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Candidato]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Candidato] @pCorreo VARCHAR(150)
AS
SELECT C.*, CT.categoria_descripcion FROM [dbo].[CANDIDATOS] C
INNER JOIN [dbo].[CATEGORIAS] CT on C.area_interes = CT.id_categoria
WHERE C.correo_usuario = @pCorreo  
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Categorias]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Categorias]
AS
SELECT C.id_Categoria, C.categoria_descripcion
FROM categorias C;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Empleo]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Empleo] @pIdEmpleo bigint
AS
SELECT E.*, C.categoria_descripcion FROM empleos E
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.id_empleo = @pIdEmpleo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Empleo_Aplicado]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Empleo_Aplicado]

@pCorreo AS VARCHAR(50),
@pIdEmpleo AS BIGINT
AS

BEGIN

Select * from SOLICITUDES S
where S.ID_EMPLEO = @pIdEmpleo AND S.CORREO_CANDIDATO = @pCorreo; 

END

GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Reclutador]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Reclutador] @pCorreo VARCHAR(150)
AS
SELECT * from [dbo].[RECLUTADORES] R 
Where R.correo_reclutador = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Solicitudes]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Solicitudes]
@pCorreo AS VARCHAR(50)
AS
BEGIN

SELECT E.*, C.categoria_descripcion, S.ID_SOLICITUD, S.FECHA_SOLICITUD, S.CORREO_CANDIDATO FROM (SOLICITUDES s
left JOIN empleos E on S.id_empleo  = E.id_empleo)
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.correo_reclutador = @pCorreo or S.CORREO_CANDIDATO = @pCorreo;

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Solicitudes_por_id]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create     PROCEDURE [dbo].[SP_Consultar_Solicitudes_por_id] @pid bigint
AS
SELECT E.*, C.categoria_descripcion, S.ID_SOLICITUD, S.FECHA_SOLICITUD, S.CORREO_CANDIDATO FROM (SOLICITUDES s
left JOIN empleos E on S.id_empleo  = E.id_empleo)
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE S.ID_SOLICITUD = @pid;

 
GO
/****** Object:  StoredProcedure [dbo].[SP_Empleo_Inteligente]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Empleo_Inteligente] @pAreaInteres INT, @pExp INT, 
@pGradoEstudio VARCHAR(50) AS
SELECT E.*, C.CATEGORIA_DESCRIPCION FROM empleos E
Inner join CATEGORIAS C on E.id_categoria = C.id_categoria
WHERE E.estado_puesto='Activo' 
AND E.id_Categoria= @pAreaInteres AND E.EXP_MINIMA<=@pExp AND E.grado_estudio=@pGradoEstudio;
GO
/****** Object:  StoredProcedure [dbo].[SP_Empleos_Publicados]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Empleos_Publicados] @pCorreo VARCHAR(150)
AS
SELECT E.*, C.categoria_descripcion FROM empleos E
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.CORREO_RECLUTADOR = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Filtrar_Categorias]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Filtrar_Categorias] @pCategoria INT
AS
SELECT E.*, C.categoria_descripcion FROM empleos E
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.id_Categoria= @pCategoria AND E.estado_puesto = 'Activo';
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Bitacora]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Bitacora] 

@pDescripcion varchar(2500),
@pOrigen varchar(100),
@pCorreo_Usuario varchar(50)
AS
BEGIN

	INSERT INTO BITACORA([FECHA_HORA],[DESCRIPCION_ERROR],[CODIGO_ERROR],[ORIGEN],[CORREO_USUARIO]) 
	VALUES(GETDATE(),@pDescripcion,'999',@pOrigen,@pCorreo_Usuario);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Candidato]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_Insertar_Candidato] @pCorreo VARCHAR(150), 
@pNombre VARCHAR(100), @pApellido VARCHAR(100), @pExp INT, @pGradoEstudio VARCHAR(20), @pTelefono INT, @pAreaInteres INT
AS
INSERT INTO[CANDIDATOS]([NOMBRE_CANDIDATO],[APELLIDO_CANDIDATO],[EXP_CANDIDATO],[GRADO_ESTUDIO],[TELEFONO_CANDIDATO],[AREA_INTERES],[CORREO_USUARIO]) 
VALUES(@pNombre,@pApellido,@pExp,@pGradoEstudio,@pTelefono,@pAreaInteres,@pCorreo);
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Empleo]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_Insertar_Empleo] @pNombreEmpleo VARCHAR(100), @pRequisitos VARCHAR(1000), 
@pDescripcionGeneral VARCHAR(1000), @pCompania VARCHAR(30), @pIdCategoria INT, 
@pCorreo VARCHAR(150), @pEstado VARCHAR(20), @pExperienciaMinima INT, @pGradoEstudio VARCHAR(50)
AS
INSERT INTO empleos(empleo_nombre,requisitos,descripcion,
compania,id_Categoria,CORREO_RECLUTADOR,estado_puesto,EXP_MINIMA,grado_estudio) 
VALUES(@pNombreEmpleo,@pRequisitos,@pDescripcionGeneral,
@pCompania,@pIdCategoria,@pCorreo,@pEstado,@pExperienciaMinima,@pGradoEstudio); 
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Reclutador]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_Insertar_Reclutador] @pCorreo VARCHAR(150), @pNombre VARCHAR(100),
@pApellido VARCHAR(100), @pCompania VARCHAR(50), @pTelefono INT
AS
INSERT INTO RECLUTADORES(NOMBRE_RECLUTADOR,APELLIDO_RECLUTADOR,COMPANIA,TELEFONO_RECLUTADOR,correo_reclutador) 
VALUES(@pNombre,@pApellido,@pCompania,@pTelefono,@pCorreo);
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Solicitudes]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Insertar_Solicitudes] @pCorreoCandidato VARCHAR(100), @pIdEmpleo INT
AS
INSERT INTO SOLICITUDES(correo_candidato, id_empleo, fecha_solicitud)
VALUES(@pCorreoCandidato,@pIdEmpleo, CURRENT_TIMESTAMP);
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Usuario]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Insertar_Usuario] @pCorreo VARCHAR(150), @pPassword VARCHAR(100), @pIdRol INT
AS
INSERT INTO USUARIOS([CORREO_USUARIO],[CONTRASENA],id_rol) VALUES(@pCorreo,@pPassword,@pIdRol);
GO
/****** Object:  StoredProcedure [dbo].[SP_Llenar_Candidatos]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Llenar_Candidatos] 
AS
SELECT C.*, CT.categoria_descripcion FROM [dbo].[CANDIDATOS] C
INNER JOIN categorias CT on C.area_interes = CT.id_categoria;
GO
/****** Object:  StoredProcedure [dbo].[SP_Llenar_Empleos]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Llenar_Empleos]
AS
SELECT E.*, C.categoria_descripcion FROM EMPLEOS E
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.estado_puesto = 'Activo';
GO
/****** Object:  StoredProcedure [dbo].[SP_Ver_Solicitudes]    Script Date: 19/6/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PROCEDURE [dbo].[SP_Ver_Solicitudes] 
AS
SELECT E.*, C.categoria_descripcion, S.ID_SOLICITUD, S.FECHA_SOLICITUD, S.CORREO_CANDIDATO FROM (SOLICITUDES s
left JOIN empleos E on S.id_empleo  = E.id_empleo)
INNER JOIN categorias C on E.id_categoria = C.id_categoria
GO
USE [master]
GO
ALTER DATABASE [Worknet] SET  READ_WRITE 
GO
