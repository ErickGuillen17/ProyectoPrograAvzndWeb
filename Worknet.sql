USE [master]
GO
/****** Object:  Database [Worknet]    Script Date: 20/6/2022 23:22:06 ******/
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
/****** Object:  Table [dbo].[BITACORA]    Script Date: 20/6/2022 23:22:06 ******/
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
/****** Object:  Table [dbo].[CANDIDATO]    Script Date: 20/6/2022 23:22:06 ******/
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
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[ID_CATEGORIA] [bigint] IDENTITY(1,1) NOT NULL,
	[CATEGORIA_DESCRIPCION] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEO]    Script Date: 20/6/2022 23:22:06 ******/
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
	[CORREO_RECLUTADOR] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RECLUTADOR]    Script Date: 20/6/2022 23:22:06 ******/
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
/****** Object:  Table [dbo].[ROL]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[ID_ROL] [bigint] IDENTITY(1,1) NOT NULL,
	[NOMBRE_ROL] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOLICITUD]    Script Date: 20/6/2022 23:22:06 ******/
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
/****** Object:  Table [dbo].[USUARIO]    Script Date: 20/6/2022 23:22:06 ******/
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
SET IDENTITY_INSERT [dbo].[BITACORA] ON 

INSERT [dbo].[BITACORA] ([FECHA_HORA], [DESCRIPCION_ERROR], [CODIGO_ERROR], [ORIGEN], [CONSECUTIVO], [CORREO_USUARIO]) VALUES (CAST(N'2022-04-25T16:42:30.957' AS DateTime), N'error de prueba', 999, N'BD Worknet', 1, N'reclutador@gmail.com')
SET IDENTITY_INSERT [dbo].[BITACORA] OFF
GO
INSERT [dbo].[CANDIDATO] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Candidato', N'Proyecto', 8, N'Bachiller Universitario', 12345678, 1, N'candidato@gmail.com')
INSERT [dbo].[CANDIDATO] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Erick ', N'Guillen ', 1, N'Estudiante Universitario', 97843243, 4, N'eguillen80064@ufide.ac.cr')
INSERT [dbo].[CANDIDATO] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Federico', N'Cerdas', 7, N'Técnico Medio', 70315298, 10, N'fcerdas@mail.com')
INSERT [dbo].[CANDIDATO] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Fernando', N'Morales', 6, N'Licenciado', 86834542, 1, N'fmc.cr@hotmail.com')
INSERT [dbo].[CANDIDATO] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Dario', N'Monestel', 3, N'Bachiller Universitario', 67768234, 1, N'gmonestel90215@ufide.ac.cr')
INSERT [dbo].[CANDIDATO] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Reiner', N'Navarro', 4, N'Estudiante Universitario', 56364532, 4, N'rnavarro40928@ufide.ac.cr')
GO
SET IDENTITY_INSERT [dbo].[CATEGORIA] ON 

INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (1, N'Informatica')
INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (2, N'Administracion')
INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (3, N'Servicio al Cliente')
INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (4, N'Cocina')
INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (5, N'Salud')
INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (6, N'Ingenieria e Industria')
INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (7, N'Economia y Finanzas')
INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (8, N'Educacion')
INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (9, N'Turismo')
INSERT [dbo].[CATEGORIA] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (10, N'Otros')
SET IDENTITY_INSERT [dbo].[CATEGORIA] OFF
GO
SET IDENTITY_INSERT [dbo].[EMPLEO] ON 

INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (3, 4, 0, N'Noveno Año', N'McDonalds', N'Cocinero', N'Activo', N'Se requiere una persona con disponibildad de horarios. No experiencia previa es necesaria pero es preferible que tenga experiencia en puestos similares', N'Curso Manejo de Alimentos requerido', N'agchaverri@manpower.com.mx')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (15, 2, 6, N'Lienciado', N'Bac San Jose', N'Gerente de Sucursal Bancaria', N'Activo', N'Se requiere Gerente para surcursal fuera del GAM.  Las personas interesadas deberan tener experiancia previa en el mismo puesto y  tener la capacidad de trasladarse  fuera del GAM en caso de ser seleccionado/a', N'Graduado en Economia, Finanzas o Administracion de Empresas. Tener amplia experiencia manejando equipos de trabajado y  haber trabajado en puestos similares', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (17, 3, 0, N'Bachiller Colegial', N'Amazon', N'Agente de servicio al cliente', N'Activo', N'Agente de servicio al cliente para Amazon. Se requeire que la persona pueda garantizar un buena comunicacion oral y escrita para establecer relacion con los clientes y mantener un buen trabajo en equipo. No se necestita experiencia previa.  El puesto ofrece flexibilidad de horarios y posiblidad de trabajar desde la casa (WFH)', N'Manejo del Idioma Ingles. Conocimientos en Excel y conocimientos tecnicos basicos son preferibles.', N'marco.lopez@delaUalBrete.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (21, 5, 2, N'Bachiller Colegial', N'Hospital Clinica Biblica', N'Asistente de Terapia Fisica', N'Activo', N'Puesto disponible para estudiante universitario o graduado de terapia fisica para asistir a un grupo de terapia con enfoque en movilidad para adultos mayores.', N'Al menos un 60% de la carrera universitaria de Terapia Fisica completa. Experiencia trbajando con adultos mayoes es deseable', N'mrodriguez@do.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (26, 1, 9, N'Licenciado', N'CompuTrabajo', N'Senior Software Developer QRadar', N'Activo', N'As a Senior Software Developer, you’ll be part of a passionate team working on IBM’s flagship product QRadar. Our QRadar product is a leader in the Gartner Magic Quadrant for Security Intelligence and Event Management (SIEM).', N'English Fluent (verbal and written).
Proven hands-on experience of building & maintaining multi-threaded Java applications.
5+ years development experience with Java.
2+ years development experience with scripting languages like Python.
Experience of working in an Agile Development Environment.', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (27, 1, 5, N'Técnico Medio', N'CompuTrabajo', N'Técnico en Soporte 2', N'Activo', N'Se necesita Técnico en Soporte, con amplia disponibilidad de horario.
Residente preferiblemente de la zona del GAM.', N'Técnico en Soporte, conocimiento relacionado al cargo, experiencia en puestos similares.
Licencia B1', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (28, 1, 4, N'Bachiller Universitario', N'CompuTrabajo', N'Frontend Developer React', N'Activo', N'Se busca desarrollador frontend con amplia experiencia en UX ', N'Bachillerato en Ingeniería en Sistemas, experiencia en puestos similares', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (29, 1, 1, N'Bachiller Universitario', N'CompuTrabajo', N' Junior Backend Developer (Java)', N'Activo', N'Buscamos programador con conocimiento en Java, con actitud positiva, facilidad para trabajar en conjunto. Además de motivación de aprender sobre este lenguaje tan reconocido!', N'Bachillerato en Ingeniería en Sistemas o Ingeniería en Computación ', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (37, 10, 1, N'Noveno Año', N'Microsodr', N'Misceláneo', N'Activo', N'Realizar labores de limpieza y aseo, tales como: barrer, limpiar, pulir pisos, muebles, estantes, escaleras, puertas, paredes, ventanas, parqueo, equipos de oficina, recoger los desechos de los basureros del área o áreas asignadas entre otros.', N'Disponibilidad inmediata.
Responsabilidad
Residente del GAM', N'wedwed@correo.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (38, 7, 1, N'Técnico Medio', N'Demarc', N'Contador/a', N'Activo', N'Dar seguimiento y monitorear la ejecución del presupuesto.
Realizar los informes financieros para el donante.
Realizar lista de pagos quincenal tanto del personal como de los proveedores.
Hacer boletas de pago y presentarlas a la administración general.
', N'Amplio conocimiento en asuntos contables
Experiencia en puestos similares.
Facilidad de trasladarse.
', N'marco.lopez@delaUalBrete.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (39, 1, 1, N'Técnico Medio', N'Clínica Universal ', N'Secretaria', N'Activo', N'Establecer el primer contacto con las personas menores de edad y sus familias, a través de contacto telefónico o mediante la atención presencial.
Brindar asistencia secretarial (atender puerta, teléfono, público)
Recibir a la población y la orienta con relación a los servicios, a las personas integrantes del equipo y espacios físicos.', N'Aptitudes de secretariado.
Aptitudes para la planificación.
Aptitudes para transcribir audio.
Buen trato por teléfono.
Capacidad para priorizar tareas.
Capacidades organizativas.
Capaz de mantener información confidencial.', N'marco.lopez@delaUalBrete.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (40, 7, 2, N'Técnico Medio', N'GrupoContadores FJ', N'Auxiliar Contable', N'Activo', N'Se requiere auxiliar de genero indiferente, con amplia experiencia en puestos relacionados.
', N'Excel intermedio.
Manejo de varias empresas.
Experiencia en facturación.
Residir en alrededores de Pacayas (Cartago).', N'marco.lopez@delaUalBrete.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (41, 2, 2, N'Licenciado', N'VM Solutions', N'Asistente administrativa/o', N'Activo', N'Se busca asistente administrativo para laborar en Moravia San José

Vigilar y mantener el orden y mantenimiento del espacio físico.
Realizar los procesos de compra de acuerdo a lo estipulado en el Manual Operativo.
Llevar archivo físico del proyecto en cuanto a personal, gastos, compras, contabilidad e información.
Control de horarios, planillas, póliza de riesgos del trabajo del personal.
Realizar informe mensual de gastos.
Realizar control de inventario mensualmente, control de activos y su estado trimestralmente.


', N'Laborar tiempo completo
Experiencia en puestos relacionados
Licenciatura en Administración de Empresas', N'marco.lopez@delaUalBrete.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (42, 9, 3, N'Bachiller Universitario', N'Manuel Antonio Tours', N'Ejecutivo en ventas', N'Activo', N'Se requiere Ejecutivo en ventas con excelente comunicación y buen servicio al cliente.
Experiencia comprobada en ventas en el ámbito hotelero.
Residente en los alrededores de Manuel Antonio', N'Estudios en turismo o a fines
Licencia b1
Flexibilidad de horario
Dominio del idioma ingles (min 80%)', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (30, 1, 5, N'Técnico Medio', N'CompuTrabajo', N'Analista de Datos PBI', N'Activo', N'Buscamos analista de Datos con conocimiento amplio en Base de Datos y con experiencia en SQL Server, experiencia en Power BI.', N'Técnico en Analista de Datos o preferiblemente bachillerato en ingeniería en sistemas de Computación ', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (31, 5, 4, N'Licenciado', N'Clínica Santa Fe ', N'Medico Cirujano ', N'Activo', N'Se solicita medico cirujano estético para clínica privada ubicada en San Rafael de Heredia.', N'Licenciatura en medicina general con énfasis en cirugía estética  ', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (32, 2, 15, N'Licenciado', N'Walmart', N'Marketing Manager', N'Activo', N'Se busca gerente en mercadeo, especializado en supermercados. Con amplia experiencia en el cargo.
Para trabajar de inmediato en supermercado ubicado en Cartago centro', N'Licenciado en Marketing y Ventas.
Disponibilidad inmediata.
Experiencia en puestos similares
', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (34, 10, 2, N'Noveno Año', N'TUASA', N'Mecánico de Auto Bus', N'Activo', N'Se busca mecánico para trabajar en plantel Lumaca.', N'Licencia B2 y C2 indispensable.
Experiencia comprobable.
Disponibilidad de horario.
', N'wedwed@correo.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (43, 5, 1, N'Licenciado', N'Hospital Asís', N'Enfermero(a)', N'Activo', N'Análisis y resolución de casos relacionados con los efectos secundarios de la medicación.', N'Mínimo 1 año de experiencia laboral clínica comprobada. (no necesita experiencia en farmacovigilancia)
Ingles Intermedio/Avanzado ( se realizará evaluación).
Incorporado al colegio de Enfermeros.
Grado Académico Título de Licenciatura en Enfermería.
Disponibilidad para trabajar presencial en Santa Ana, San José.', N'mrodriguez@do.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (44, 5, 3, N'Licenciado', N'Hospital Calderón Guardia', N'Medico General de Urgencias', N'Activo', N'Médico acreditado para el ejercicio de la medicina; debidamente incorporado. Se encargará de la atención de pacientes, desempeño con alto nivel de calidad en el servicio a los pacientes', N'Excelente servicio al cliente
Persona proactiva
Disponibilidad de trabajar de lunes a sábado
Disponibilidad para laborar en jornada nocturna', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (33, 2, 3, N'Técnico Medio', N'Grupo 823', N'Agente de Ventas', N'Activo', N'Encargado/a de formalizar contratos y brindar información al cliente con respecto a los términos y condiciones del alquiler de los vehículos, ventas de coberturas y productos adicionales.

Atender a los clientes en counter, vía telefónica y/o mensajería para reservaciones, cotizaciones de tarifas, preguntas generales, asistencias; y brinde información y resolución para clientes, otras sucursales y otros proveedores.

Ofrecer asistencia adicional al cliente sobre direcciones, mapas, información del área local e información del servicio adecuada, brindando excelencia en la atención al cliente.', N'Licencia B1
Ingles Intermedio
Buena presentación
Excelente comunicación


', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (35, 10, 3, N'Noveno Año', N'Lumaca', N'Mecánico General', N'Activo', N'Necesitamos mecánico general con experiencia amplia y comprobable, para laborar en Alajuela', N'Licencia B1 o B2 indispensable.
Responsable y honesto.
Disponibilidad inmediata', N'wedwed@correo.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (36, 3, 1, N'Noveno Año', N'El Balcón del Marisco', N'Mesero', N'Activo', N'Se busca mesero, con facilidad de trasladarse dentro del GAM', N'Curso de manipulación de alimentos.
Disponibilidad de horario.
Respetuoso y responsable.', N'wedwed@correo.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (45, 1, 2, N'Bachiller Universitario', N'Ópticas Visión ', N'Supervisor de óptica ', N'Activo', N'Realizar el proceso de supervisión del proceso de control de activos y coordinación de los pedidos de inventarios de aros, de conformidad a las metas mensuales establecidas.
Controlar los pedidos de aros de conformidad a las garantías establecidas', N'Educación Mínima: Universidad
2 años de experiencia
Conocimientos: LibreOffice
Disponibilidad de laborar de Lunes a Sábado.', N'marco.lopez@delaUalBrete.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (46, 5, 2, N'Bachiller Colegial', N'Clínica San Bernardo', N'Secretaria Odontológica', N'Activo', N'Hacer apertura o cambios de las agendas
Dar soporte al área de consultas
Solicitar suministros
Llenado y firmas de agendas de odontología.
Pasar instrumentos al odontólogo.', N'Estudios en odontología.
Disponibilidad de horarios
Trabajo bajo presión.
 Educación Básica Secundaria
2 años de experiencia', N'mrodriguez@do.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (47, 1, 1, N'Bachiller Colegial', N'CompuTrabajo', N'Technical Solutions Consultant', N'Activo', N'Aplica los fundamentos básicos de los principios, teorías y conceptos de una función a tareas de alcance limitado. Utiliza los conceptos profesionales y los conocimientos teóricos adquiridos a través de la formación especializada, la educación o la experiencia previa. Desarrolla la experiencia y el conocimiento práctico de las aplicaciones en el entorno empresarial. Actúa como miembro del equipo proporcionando información, análisis y recomendaciones en apoyo de los esfuerzos del equipo. Ejerce un juicio independiente dentro de los parámetros definidos.', N'Secundaria completa
Experiencia en campos similares', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (48, 1, 5, N'Bachiller Universitario', N'CompuTrabajo', N'Software Engineer', N'Activo', N'IP and Competitive Analytics (IPCA) influences Intel roadmaps for future product and IP development and is looking for new team members to build performance analysis for client and server platforms. A successful candidate will be responsible for the execution, benchmarking, and debug for internal and competition platforms. They will also work on analyzing performance behavior, communicating issues related to workload performance, identifying bottlenecks in future products and influencing the design of future designs.

We are looking for a software engineer, to work collaboratively with a highly talented cross-functional team to drive efficiency in computing platform analysis, characterization, analytical modelling, and projection.

The ideal candidate thrives in an Agile Environment and has a passion for quality and continuous improvement in a constant flow of work and deliverables.', N'Strong data analysis, debugging, and problem-solving skills.
Proactive attitude.
Tolerance to ambiguity.
Attention to detail and ability to analyze data for accuracy/trends.
Experience in similar positions. ', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (49, 1, 5, N'Licenciado', N'CompuTrabajo', N'Senior Content Developer', N'Activo', N'The Senior Content Developer (SCD) is responsible for creating, editing, and tracking down the content within a CMS environment, which also implies interacting with majority of stakeholders in a project. As a CMS project owner, SCDs strive to deliver excellent results to benefit both the project and the team. The SCD should also be able to provide estimates for their tasks and assume ownership for these estimates.

The SCD works with web applications and a variety of front-end technologies including HTML5, CSS and JavaScript, and is very comfortable with content management systems.', N'Ideally intermediate-advanced English Proficiency (B1+ reading, writing, and conversation)
At least 3-4 years of experience working with content management systems (AEM, Sitecore, TeamSite)
Excellent understanding of content management systems and its components/templates.
Experience manipulating and administering website content.
Experience dealing with Cross-browser and Responsive development.
Familiar and basic experience on Front-End technologies (e.g. HTML, CSS, JavaScript).', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (50, 1, 5, N'Bachiller Universitario', N'CompuTrabajo', N'Senior Web Developer (React)', N'Activo', N'Accenture is a global professional services company with leading capabilities in digital, cloud and security. Combining unmatched experience and specialized skills across more than 40 industries, we offer Strategy and Consulting, Interactive, Technology and Operations services — all powered by the world’s largest network of Advanced Technology and Intelligent Operations centers. Our 624,000 people deliver on the promise of technology and human ingenuity every day, serving clients in more than 120 countries. We embrace the power of change to create value and shared success for our clients, people, shareholders, partners and communities. Visit us at www.accenture.com

The ideal candidate is a creative problem solver who will work in coordination with cross-functional teams to design, develop, and maintain our next generation websites and web tools. You must be comfortable working as part of a team while taking the initiative to take lead on new innovations and projects.', N'Revise, edit, proofread & optimize web content

Work with cross-functionally to enhance overall user experience of our platforms

age the execution of website decommissioning including, archiving, communications and harvesting processes as agreed with the client

Maintain the layout of intranet as per the defined intranet guidelines

Provide primary support for installation of application releases into production

Own various design tasks involved in the web development life cycle from start to finish

Utilize best practices in web screen design as well as learn about different middleware platforms to source and update data through web screens as specified in functional requirements

Develop and implement testing plans

Create awareness amongst different functions on importance of intranet for sharing the information

Research and reach out to various stakeholders to get updated content for sites

Desirable: Design & Build Enablement: Storyboards & Wireframes; Web &', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (51, 1, 8, N'Bachiller Universitario', N'CompuTrabajo', N'Senior Software Engineer', N'Activo', N'The Microsoft 365 team is looking for senior software engineers to help design and build one of the fastest growing cloud services in Microsoft. Do you want to design and develop new components that solve complex distributed systems and search optimization problems? Do you want to mentor junior engineers and drive a technical area across your team? Do you want to work on a product that ships new features every week? If the answer to these questions is yes, then Microsoft 365 team would like to hear from you! ?We develop software from the ground-up, running across thousands of servers. We build and operate the largest enterprise cloud productivity system in the world. Across products such as Exchange, Teams, and SharePoint, we power communication, sharing, search, intelligent assistance for customers, extensibility through Microsoft Graph, and more. Throughout we maintain very high reliability and availability, strong privacy and compliance for customers, and latency in milliseconds. We', N'BS or MS degree in Computer Science or Engineering OR equivalent years of work experience.
5-7 years of software design and development experience with backend services.
5+ years hands on experience in any Object-Oriented coding language such as C++, C#, Java or Python or equivalent experience with C.', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (52, 1, 8, N'Licenciado', N'CompuTrabajo', N'Senior Java Developer', N'Activo', N'This job is a member of the Information Technology Team, within the Information Technology Division. This position supports and transforms existing and new mission critical and highly-visible operational website(s) and applications – spanning multiple technology stacks – through all phases of SDLC, while working collaboratively across IT, business, and third party suppliers from around the globe in a 24x7, fast-paced, and Agile based environment.', N'Bachelor''s degree in Computer Science, Computer Engineering, Technology, Information Systems (CIS/MIS), Engineering or related technical discipline, or equivalent experience/training
5 years of experience delivering SDLC solutions using ITIL / Agile / XP, or similar methodologies
', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (53, 1, 5, N'Bachiller Universitario', N'CompuTrabajo', N'Lead Developer', N'Activo', N'Se buscar lead developer', N'Net
AWS

React


Requisitos


Inglés 80%

Beneficios

Teletrabajo 100%

Laborar por servicios profesionales sin necesidad de facturar', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEO] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (55, 4, 5, N'Noveno Año', N'CompuTrabajo', N'Empleo Exposicion 2', N'Activo', N'Prueba', N'Prueba', N'reclutador@gmail.com')
SET IDENTITY_INSERT [dbo].[EMPLEO] OFF
GO
INSERT [dbo].[RECLUTADOR] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'agchaverri@manpower.com.mx', N'Ana', N'Chaverri Rojas', N'Manpower', 434325325)
INSERT [dbo].[RECLUTADOR] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'jose.sanchez@buscojobs.cr', N'Jose', N'Sanchez Brenes', N'BuscoJobs', 352352352)
INSERT [dbo].[RECLUTADOR] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'marco.lopez@delaUalBrete.com', N'Marco', N'Lopez Zuniga', N'DelaUalBrete', 343242342)
INSERT [dbo].[RECLUTADOR] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'mrodriguez@do.com', N'Maria ', N'Rodriguez Chaves', N'TrabajoCR', 694876743)
INSERT [dbo].[RECLUTADOR] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'reclutador@gmail.com', N'Javier', N'Mendez Castillo', N'CompuTrabajo', 642432434)
INSERT [dbo].[RECLUTADOR] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'rjime@lumaca.cr', N'Ronald', N'Jiménez', N'Lumaca', 25401098)
INSERT [dbo].[RECLUTADOR] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'wedwed@correo.com', N'Candidato', N'Prueva', N'Microsodr', 43242342)
GO
SET IDENTITY_INSERT [dbo].[ROL] ON 

INSERT [dbo].[ROL] ([ID_ROL], [NOMBRE_ROL]) VALUES (1, N'Reclutador')
INSERT [dbo].[ROL] ([ID_ROL], [NOMBRE_ROL]) VALUES (2, N'Candidato')
SET IDENTITY_INSERT [dbo].[ROL] OFF
GO
SET IDENTITY_INSERT [dbo].[SOLICITUD] ON 

INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (6, 17, N'eguillen80064@ufide.ac.cr', CAST(N'2022-04-17T00:00:00.000' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (9, 21, N'rnavarro40928@ufide.ac.cr', CAST(N'2022-03-15T00:00:00.000' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (11, 17, N'fmc.cr@hotmail.com', CAST(N'2022-04-22T22:01:42.467' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (12, 3, N'fmc.cr@hotmail.com', CAST(N'2022-04-22T22:02:25.407' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (13, 21, N'fmc.cr@hotmail.com', CAST(N'2022-04-24T22:59:31.900' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (14, 26, N'fmc.cr@hotmail.com', CAST(N'2022-04-24T23:46:31.803' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (15, 3, N'gmonestel90215@ufide.ac.cr', CAST(N'2022-04-26T12:39:00.850' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (16, 38, N'fcerdas@mail.com', CAST(N'2022-04-26T12:42:13.190' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (17, 15, N'fcerdas@mail.com', CAST(N'2022-04-26T12:43:14.953' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (18, 45, N'gmonestel90215@ufide.ac.cr', CAST(N'2022-04-26T16:17:59.030' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (19, 55, N'candidato@gmail.com', CAST(N'2022-04-26T18:25:17.927' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (20, 30, N'candidato@gmail.com', CAST(N'2022-04-26T18:26:25.290' AS DateTime))
INSERT [dbo].[SOLICITUD] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (21, 28, N'candidato@gmail.com', CAST(N'2022-05-30T21:32:20.177' AS DateTime))
SET IDENTITY_INSERT [dbo].[SOLICITUD] OFF
GO
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'agchaverri@manpower.com.mx', N'r2r2r2r23r34', 1)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'candidato@gmail.com', N'1234', 2)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'eguillen80064@ufide.ac.cr', N'1234', 2)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'fcerdas@mail.com', N'0210', 2)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'fmc.cr@gmail.com', N'4321', 1)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'fmc.cr@hotmail.com', N'1234', 2)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'gmonestel90215@ufide.ac.cr', N'1234', 2)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'jose.sanchez@buscojobs.cr', N'vwvODanodx', 1)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'marco.lopez@delaUalBrete.com', N'cweHGXOSvwev', 1)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'mrodriguez@do.com', N'ixqoxnw23123', 1)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'reclutador@gmail.com', N'1234', 1)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'rjime@lumaca.cr', N'1234', 1)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'rnavarro40928@ufide.ac.cr', N'1234', 2)
INSERT [dbo].[USUARIO] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'wedwed@correo.com', N'1234', 1)
GO
/****** Object:  Index [XPKCATEGORIAS]    Script Date: 20/6/2022 23:22:06 ******/
ALTER TABLE [dbo].[CATEGORIA] ADD  CONSTRAINT [XPKCATEGORIAS] PRIMARY KEY NONCLUSTERED 
(
	[ID_CATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [XPKEMPLEOS]    Script Date: 20/6/2022 23:22:06 ******/
ALTER TABLE [dbo].[EMPLEO] ADD  CONSTRAINT [XPKEMPLEOS] PRIMARY KEY NONCLUSTERED 
(
	[ID_EMPLEO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [XPKROLES]    Script Date: 20/6/2022 23:22:06 ******/
ALTER TABLE [dbo].[ROL] ADD  CONSTRAINT [XPKROLES] PRIMARY KEY NONCLUSTERED 
(
	[ID_ROL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Candidato]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Actualizar_Candidato] @pNombre VARCHAR(50),@pApellido VARCHAR(50),
@pExp INT, @pGradoEstudio VARCHAR(50),@pTelefono INT, @pAreaInteres INT, @pCorreo VARCHAR(50)  
AS
UPDATE CANDIDATO 
SET [NOMBRE_CANDIDATO] = @pNombre, [APELLIDO_CANDIDATO] = @pApellido, 
[EXP_CANDIDATO] = @pExp,[GRADO_ESTUDIO] = @pGradoEstudio, [TELEFONO_CANDIDATO] = @pTelefono, [AREA_INTERES] = @pAreaInteres
WHERE [CORREO_USUARIO] = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Empleo]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Actualizar_Empleo]
@pEmpleo VARCHAR(100), @pCompania VARCHAR(100), @pRequisitos VARCHAR(500), 
@pDescripcion VARCHAR(500), @pExperiencia INT, @pEstudios VARCHAR(500), @pEstado VARCHAR(200), 
@pCategoria INT, @pIdPuesto INT
AS
UPDATE EMPLEO
SET [EMPLEO_NOMBRE] = @pEmpleo,
[COMPANIA] = @pCompania, [REQUISITOS] = @pRequisitos, 
[DESCRIPCION] = @pDescripcion, [EXP_MINIMA] = @pExperiencia, 
[GRADO_ESTUDIO] = @pEstudios, [ESTADO_PUESTO] = @pEstado, [ID_CATEGORIA] = @pCategoria
WHERE [ID_EMPLEO] = @pIdPuesto;
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Reclutador]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Actualizar_Reclutador] 
@pNombre VARCHAR(100), @pApellido VARCHAR(100), @pCompania VARCHAR(100), 
@pTelefono INT, @pCorreo VARCHAR(150)
AS
UPDATE RECLUTADOR
SET [NOMBRE_RECLUTADOR] = @pNombre, [APELLIDO_RECLUTADOR] = @pApellido, 
[COMPANIA] = @pCompania,[TELEFONO_RECLUTADOR]= @pTelefono
WHERE [CORREO_RECLUTADOR] = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Buscar_Usuario]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Buscar_Usuario] @pCorreo VARCHAR(50), @pContrasena VARCHAR(50)
AS
SELECT * FROM [dbo].[USUARIO] U
WHERE u.[CORREO_USUARIO] = @pCorreo AND u.[CONTRASENA] = @pContrasena;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Candidato]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Candidato] @pCorreo VARCHAR(150)
AS
SELECT C.*, CT.categoria_descripcion FROM [dbo].[CANDIDATO] C
INNER JOIN [dbo].[CATEGORIA] CT on C.area_interes = CT.id_categoria
WHERE C.correo_usuario = @pCorreo  
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Categorias]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Categorias]
AS
SELECT C.id_Categoria, C.categoria_descripcion
FROM categoria C;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Empleo]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Empleo] @pIdEmpleo bigint
AS
SELECT E.*, C.categoria_descripcion FROM empleo E
INNER JOIN categoria C on E.id_categoria = C.id_categoria
WHERE E.id_empleo = @pIdEmpleo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Empleo_Aplicado]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Empleo_Aplicado]

@pCorreo AS VARCHAR(50),
@pIdEmpleo AS BIGINT
AS

BEGIN

Select * from SOLICITUD S
where S.ID_EMPLEO = @pIdEmpleo AND S.CORREO_CANDIDATO = @pCorreo; 

END

GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Reclutador]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Reclutador] @pCorreo VARCHAR(150)
AS
SELECT * from [dbo].[RECLUTADOR] R 
Where R.correo_reclutador = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Solicitudes]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Solicitudes]
@pCorreo AS VARCHAR(50)
AS
BEGIN

SELECT E.*, C.categoria_descripcion, S.ID_SOLICITUD, S.FECHA_SOLICITUD, S.CORREO_CANDIDATO FROM (SOLICITUD s
left JOIN empleo E on S.id_empleo  = E.id_empleo)
INNER JOIN categoria C on E.id_categoria = C.id_categoria
WHERE E.correo_reclutador = @pCorreo or S.CORREO_CANDIDATO = @pCorreo;

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Solicitudes_por_id]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create     PROCEDURE [dbo].[SP_Consultar_Solicitudes_por_id] @pid bigint
AS
SELECT E.*, C.categoria_descripcion, S.ID_SOLICITUD, S.FECHA_SOLICITUD, S.CORREO_CANDIDATO FROM (SOLICITUD s
left JOIN empleo E on S.id_empleo  = E.id_empleo)
INNER JOIN categoria C on E.id_categoria = C.id_categoria
WHERE S.ID_SOLICITUD = @pid;

 
GO
/****** Object:  StoredProcedure [dbo].[SP_Empleo_Inteligente]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Empleo_Inteligente] @pAreaInteres INT, @pExp INT, 
@pGradoEstudio VARCHAR(50) AS
SELECT E.*, C.CATEGORIA_DESCRIPCION FROM empleo E
Inner join CATEGORIA C on E.id_categoria = C.id_categoria
WHERE E.estado_puesto='Activo' 
AND E.id_Categoria= @pAreaInteres AND E.EXP_MINIMA<=@pExp AND E.grado_estudio=@pGradoEstudio;
GO
/****** Object:  StoredProcedure [dbo].[SP_Empleos_Publicados]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Empleos_Publicados] @pCorreo VARCHAR(150)
AS
SELECT E.*, C.categoria_descripcion FROM empleo E
INNER JOIN categoria C on E.id_categoria = C.id_categoria
WHERE E.CORREO_RECLUTADOR = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Filtrar_Categorias]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Filtrar_Categorias] @pCategoria INT
AS
SELECT E.*, C.categoria_descripcion FROM empleo E
INNER JOIN categoria C on E.id_categoria = C.id_categoria
WHERE E.id_Categoria= @pCategoria AND E.estado_puesto = 'Activo';
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Bitacora]    Script Date: 20/6/2022 23:22:06 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Candidato]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_Insertar_Candidato] @pCorreo VARCHAR(150), 
@pNombre VARCHAR(100), @pApellido VARCHAR(100), @pExp INT, @pGradoEstudio VARCHAR(20), @pTelefono INT, @pAreaInteres INT
AS
INSERT INTO[CANDIDATO]([NOMBRE_CANDIDATO],[APELLIDO_CANDIDATO],[EXP_CANDIDATO],[GRADO_ESTUDIO],[TELEFONO_CANDIDATO],[AREA_INTERES],[CORREO_USUARIO]) 
VALUES(@pNombre,@pApellido,@pExp,@pGradoEstudio,@pTelefono,@pAreaInteres,@pCorreo);
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Empleo]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_Insertar_Empleo] @pNombreEmpleo VARCHAR(100), @pRequisitos VARCHAR(1000), 
@pDescripcionGeneral VARCHAR(1000), @pCompania VARCHAR(30), @pIdCategoria INT, 
@pCorreo VARCHAR(150), @pEstado VARCHAR(20), @pExperienciaMinima INT, @pGradoEstudio VARCHAR(50)
AS
INSERT INTO empleo(empleo_nombre,requisitos,descripcion,
compania,id_Categoria,CORREO_RECLUTADOR,estado_puesto,EXP_MINIMA,grado_estudio) 
VALUES(@pNombreEmpleo,@pRequisitos,@pDescripcionGeneral,
@pCompania,@pIdCategoria,@pCorreo,@pEstado,@pExperienciaMinima,@pGradoEstudio); 
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Reclutador]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_Insertar_Reclutador] @pCorreo VARCHAR(150), @pNombre VARCHAR(100),
@pApellido VARCHAR(100), @pCompania VARCHAR(50), @pTelefono INT
AS
INSERT INTO RECLUTADOR(NOMBRE_RECLUTADOR,APELLIDO_RECLUTADOR,COMPANIA,TELEFONO_RECLUTADOR,correo_reclutador) 
VALUES(@pNombre,@pApellido,@pCompania,@pTelefono,@pCorreo);
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Solicitudes]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Insertar_Solicitudes] @pCorreoCandidato VARCHAR(100), @pIdEmpleo INT
AS
INSERT INTO SOLICITUD(correo_candidato, id_empleo, fecha_solicitud)
VALUES(@pCorreoCandidato,@pIdEmpleo, CURRENT_TIMESTAMP);
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Usuario]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Insertar_Usuario] @pCorreo VARCHAR(150), @pPassword VARCHAR(100), @pIdRol INT
AS
INSERT INTO USUARIO([CORREO_USUARIO],[CONTRASENA],id_rol) VALUES(@pCorreo,@pPassword,@pIdRol);
GO
/****** Object:  StoredProcedure [dbo].[SP_Llenar_Candidatos]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Llenar_Candidatos] 
AS
SELECT C.*, CT.categoria_descripcion FROM [dbo].[CANDIDATO] C
INNER JOIN categoria CT on C.area_interes = CT.id_categoria;
GO
/****** Object:  StoredProcedure [dbo].[SP_Llenar_Empleos]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Llenar_Empleos]
AS
SELECT E.*, C.categoria_descripcion FROM EMPLEO E
INNER JOIN categoria C on E.id_categoria = C.id_categoria
WHERE E.estado_puesto = 'Activo';
GO
/****** Object:  StoredProcedure [dbo].[SP_Ver_Solicitudes]    Script Date: 20/6/2022 23:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PROCEDURE [dbo].[SP_Ver_Solicitudes] 
AS
SELECT E.*, C.categoria_descripcion, S.ID_SOLICITUD, S.FECHA_SOLICITUD, S.CORREO_CANDIDATO FROM (SOLICITUD s
left JOIN empleo E on S.id_empleo  = E.id_empleo)
INNER JOIN categoria C on E.id_categoria = C.id_categoria
GO
USE [master]
GO
ALTER DATABASE [Worknet] SET  READ_WRITE 
GO
