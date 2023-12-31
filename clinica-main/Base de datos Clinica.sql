USE [master]
GO
/****** Object:  Database [Clinica_TpIntegrador]    Script Date: 19/12/2022 12:19:17 ******/
CREATE DATABASE [Clinica_TpIntegrador]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Clinica_TpIntegrador', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Clinica_TpIntegrador.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Clinica_TpIntegrador_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Clinica_TpIntegrador_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Clinica_TpIntegrador] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Clinica_TpIntegrador].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Clinica_TpIntegrador] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET ARITHABORT OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET  MULTI_USER 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Clinica_TpIntegrador] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Clinica_TpIntegrador] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Clinica_TpIntegrador] SET QUERY_STORE = OFF
GO
USE [Clinica_TpIntegrador]
GO
/****** Object:  Table [dbo].[Dias]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dias](
	[Id_Dias] [int] NOT NULL,
	[Dia_Dias] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Dias] PRIMARY KEY CLUSTERED 
(
	[Id_Dias] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiasXHoras]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiasXHoras](
	[Id_Dias_DiasXHoras] [int] NOT NULL,
	[Dia_DiasXHoras] [varchar](10) NOT NULL,
	[Id_Horas_DiasXHoras] [int] NOT NULL,
	[Horas_DiasXHoras] [varchar](25) NOT NULL,
 CONSTRAINT [PK_DiasXHoras] PRIMARY KEY CLUSTERED 
(
	[Id_Dias_DiasXHoras] ASC,
	[Id_Horas_DiasXHoras] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidades]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidades](
	[Cod_Especialidad] [char](4) NOT NULL,
	[Descripción_Especialidad] [varchar](20) NOT NULL,
	[Estado_Especialidad] [bit] NOT NULL,
 CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED 
(
	[Cod_Especialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialistas]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialistas](
	[DNI_Especialistas] [char](8) NOT NULL,
	[Cod_Especialidad_Especialistas] [char](4) NOT NULL,
	[Nombre_Especialistas] [varchar](25) NOT NULL,
	[Apellido_Especialistas] [varchar](25) NOT NULL,
	[Telefono_Especialistas] [varchar](15) NOT NULL,
	[Email_Especialistas] [varchar](20) NULL,
	[Estado_Especialistas] [bit] NOT NULL,
 CONSTRAINT [PK_Especialistas] PRIMARY KEY CLUSTERED 
(
	[DNI_Especialistas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EspecialistaXDiaXHora]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EspecialistaXDiaXHora](
	[Id_Dias_EXDXH] [int] NOT NULL,
	[Id_Horas_EXDXH] [int] NOT NULL,
	[DNI_Especialistas_EXDXH] [char](8) NOT NULL,
	[Cod_Especialidad_EXDXH] [char](4) NOT NULL,
	[Cantidad_Turnos_EXDXH] [int] NOT NULL,
	[Estado_EXDXH] [bit] NOT NULL,
 CONSTRAINT [PK_EspecialistaXDiaXHora] PRIMARY KEY CLUSTERED 
(
	[Id_Dias_EXDXH] ASC,
	[Id_Horas_EXDXH] ASC,
	[DNI_Especialistas_EXDXH] ASC,
	[Cod_Especialidad_EXDXH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horas]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horas](
	[Id_Horas] [int] NOT NULL,
	[Horas_Horas] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Horas] PRIMARY KEY CLUSTERED 
(
	[Id_Horas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Obras_Sociales]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Obras_Sociales](
	[Cod_Obra_Social_OS] [char](4) NOT NULL,
	[Nombre_Obra_Social_OS] [varchar](20) NOT NULL,
	[Estado_OS] [bit] NOT NULL,
 CONSTRAINT [PK_Cod_Obra_Social_OS] PRIMARY KEY CLUSTERED 
(
	[Cod_Obra_Social_OS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[DNI_Pacientes] [char](8) NOT NULL,
	[Cod_Obra_Social_Pacientes] [char](4) NOT NULL,
	[Nombre_Pacientes] [varchar](25) NOT NULL,
	[Apellido_Pacientes] [varchar](25) NOT NULL,
	[Numero_Asociado_Pacientes] [varchar](10) NOT NULL,
	[Fecha_Nacimiento_Paciente] [varchar](10) NULL,
	[Telefono_Pacientes] [varchar](15) NULL,
	[Email_Pacientes] [varchar](20) NULL,
	[Estado_Pacientes] [bit] NOT NULL,
 CONSTRAINT [PK_DNI_Pacientes] PRIMARY KEY CLUSTERED 
(
	[DNI_Pacientes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[Cod_Turnos] [int] IDENTITY(1,1) NOT NULL,
	[Dni_Especialista_Turnos] [char](8) NOT NULL,
	[Cod_Especialidad_Turnos] [char](4) NOT NULL,
	[Dni_Paciente_Turnos] [char](8) NOT NULL,
	[Asistencia_Turnos] [int] NULL,
	[Motivo_Consulta_Turnos] [varchar](50) NOT NULL,
	[Fecha_Turnos] [varchar](10) NOT NULL,
	[Id_Dia_Turnos] [int] NOT NULL,
	[Id_Hora_Turnos] [int] NOT NULL,
	[Horario_Turnos] [varchar](25) NOT NULL,
	[Dia_Turnos] [varchar](10) NOT NULL,
	[Estado_Turnos] [bit] NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Cod_Turnos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Usuario_Usuarios] [varchar](30) NOT NULL,
	[Email_Usuarios] [varchar](30) NOT NULL,
	[Contraseña_Usuarios] [varchar](30) NOT NULL,
	[Tipo_Usuarios] [char](1) NOT NULL,
	[Estado_Usuarios] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Usuario_Usuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Especialidades] ADD  DEFAULT ((1)) FOR [Estado_Especialidad]
GO
ALTER TABLE [dbo].[Especialistas] ADD  DEFAULT ((1)) FOR [Estado_Especialistas]
GO
ALTER TABLE [dbo].[EspecialistaXDiaXHora] ADD  DEFAULT ((0)) FOR [Cantidad_Turnos_EXDXH]
GO
ALTER TABLE [dbo].[EspecialistaXDiaXHora] ADD  DEFAULT ((1)) FOR [Estado_EXDXH]
GO
ALTER TABLE [dbo].[Obras_Sociales] ADD  DEFAULT ((1)) FOR [Estado_OS]
GO
ALTER TABLE [dbo].[Pacientes] ADD  DEFAULT ((1)) FOR [Estado_Pacientes]
GO
ALTER TABLE [dbo].[Turnos] ADD  DEFAULT ((1)) FOR [Estado_Turnos]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [Estado_Usuarios]
GO
ALTER TABLE [dbo].[DiasXHoras]  WITH CHECK ADD  CONSTRAINT [FK_DiasXHoras_Dias] FOREIGN KEY([Id_Dias_DiasXHoras])
REFERENCES [dbo].[Dias] ([Id_Dias])
GO
ALTER TABLE [dbo].[DiasXHoras] CHECK CONSTRAINT [FK_DiasXHoras_Dias]
GO
ALTER TABLE [dbo].[DiasXHoras]  WITH CHECK ADD  CONSTRAINT [FK_DiasXHoras_Horas] FOREIGN KEY([Id_Horas_DiasXHoras])
REFERENCES [dbo].[Horas] ([Id_Horas])
GO
ALTER TABLE [dbo].[DiasXHoras] CHECK CONSTRAINT [FK_DiasXHoras_Horas]
GO
ALTER TABLE [dbo].[Especialistas]  WITH CHECK ADD  CONSTRAINT [FK_Especialistas_Especialidades] FOREIGN KEY([Cod_Especialidad_Especialistas])
REFERENCES [dbo].[Especialidades] ([Cod_Especialidad])
GO
ALTER TABLE [dbo].[Especialistas] CHECK CONSTRAINT [FK_Especialistas_Especialidades]
GO
ALTER TABLE [dbo].[EspecialistaXDiaXHora]  WITH CHECK ADD  CONSTRAINT [FK_EspecialistaXDiaXHora_DiasXHoras] FOREIGN KEY([Id_Dias_EXDXH], [Id_Horas_EXDXH])
REFERENCES [dbo].[DiasXHoras] ([Id_Dias_DiasXHoras], [Id_Horas_DiasXHoras])
GO
ALTER TABLE [dbo].[EspecialistaXDiaXHora] CHECK CONSTRAINT [FK_EspecialistaXDiaXHora_DiasXHoras]
GO
ALTER TABLE [dbo].[EspecialistaXDiaXHora]  WITH CHECK ADD  CONSTRAINT [FK_EspecialistaXDiaXHora_Especialistas] FOREIGN KEY([DNI_Especialistas_EXDXH])
REFERENCES [dbo].[Especialistas] ([DNI_Especialistas])
GO
ALTER TABLE [dbo].[EspecialistaXDiaXHora] CHECK CONSTRAINT [FK_EspecialistaXDiaXHora_Especialistas]
GO
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Obra_Social_Pacientes] FOREIGN KEY([Cod_Obra_Social_Pacientes])
REFERENCES [dbo].[Obras_Sociales] ([Cod_Obra_Social_OS])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Cod_Obra_Social_Pacientes]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_EspecialistaXDiaXHora] FOREIGN KEY([Id_Dia_Turnos], [Id_Hora_Turnos], [Dni_Especialista_Turnos], [Cod_Especialidad_Turnos])
REFERENCES [dbo].[EspecialistaXDiaXHora] ([Id_Dias_EXDXH], [Id_Horas_EXDXH], [DNI_Especialistas_EXDXH], [Cod_Especialidad_EXDXH])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_EspecialistaXDiaXHora]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Pacientes] FOREIGN KEY([Dni_Paciente_Turnos])
REFERENCES [dbo].[Pacientes] ([DNI_Pacientes])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Pacientes]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarTurno]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ActualizarTurno]
(
@Cod_Turnos int,
@Asistencia_Turnos int,
@Motivo_Consulta_Turnos varchar(50)
)
AS
UPDATE Turnos SET Asistencia_Turnos=@Asistencia_Turnos,Motivo_Consulta_Turnos=@Motivo_Consulta_Turnos WHERE Cod_Turnos=@Cod_Turnos
RETURN
GO
/****** Object:  StoredProcedure [dbo].[SP_AltaEspecialista]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP ALTA ESPECIALISTAS
CREATE PROCEDURE [dbo].[SP_AltaEspecialista]
@DNI char(8)
AS
UPDATE Especialistas SET Estado_Especialistas=1 where DNI_Especialistas = @DNI
GO
/****** Object:  StoredProcedure [dbo].[SP_AltaPaciente]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP ALTA PACIENTES
CREATE PROCEDURE [dbo].[SP_AltaPaciente]
@DNI char(8)
AS
UPDATE Pacientes SET Estado_Pacientes=1 where DNI_Pacientes = @DNI
GO
/****** Object:  StoredProcedure [dbo].[SP_RetornoEspecialista]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP FECHA DE RETORNO TRAS BAJA TEMPORAL ESPECIALISTAS
CREATE PROCEDURE [dbo].[SP_RetornoEspecialista]
@DNI char(8), @COD_ESP char (4), @DIAS int, @FECHA_INI DATE
AS
SELECT DATEADD(day,@DIAS,@FECHA_INI) AS Retorno
GO
/****** Object:  StoredProcedure [dbo].[SP_VerificarUsuario]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*PROCEDIMIENTO PARA VERIFICAR USUARIOS AL INICIAR SESION*/
CREATE procedure [dbo].[SP_VerificarUsuario]
(
@usuario varchar(30),
@contraseña varchar(30)
)
as
if((select Usuarios.Contraseña_Usuarios from Usuarios where @usuario = Usuario_Usuarios ) = @contraseña)
	return '1'
else 
	return '0'
GO
/****** Object:  StoredProcedure [dbo].[spEditarEspecialista]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*PROCEDIMIENTO PARA EDITAR TELEFONO Y EMAIL DE LOS ESPECIALISTAS*/
CREATE PROCEDURE [dbo].[spEditarEspecialista]
(
@DNI CHAR(8),
@EMAIL varchar (20),
@TELEFONO varchar(15)
)
AS
UPDATE Especialistas SET Telefono_Especialistas=@TELEFONO, Email_Especialistas=@EMAIL WHERE DNI_Especialistas = @DNI 
RETURN
GO
/****** Object:  StoredProcedure [dbo].[spEliminarEspecialista]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*ELIMINAR ESPECIALISTA*/
CREATE PROCEDURE [dbo].[spEliminarEspecialista]
(
@DNI CHAR(8)
)
AS
UPDATE Especialistas SET Estado_Especialistas=0 WHERE DNI_Especialistas = @DNI 
RETURN
GO
/****** Object:  StoredProcedure [dbo].[spEliminarHorario]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*PROCEDIMIENTO PARA ELIMINAR HORARIOS*/
CREATE PROCEDURE [dbo].[spEliminarHorario]
(
@DNI CHAR(8),
@DIA INT,
@HORA INT
)
AS
UPDATE EspecialistaXDiaXHora SET Estado_EXDXH=0 WHERE DNI_Especialistas_EXDXH = @DNI AND Id_Dias_EXDXH=@DIA AND Id_Horas_EXDXH=@HORA 
RETURN
GO
/****** Object:  StoredProcedure [dbo].[spEliminarTurno]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*PROCEDIMIENTO PARA ELIMINAR TURNO*/
CREATE PROCEDURE [dbo].[spEliminarTurno]
(
@COD int
)
AS
DELETE FROM Turnos WHERE Cod_Turnos = @COD
RETURN
GO
/****** Object:  StoredProcedure [dbo].[spInsertarEspecialista]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*PROCEDIMIENTO PARA CREAR UN ESPECIALISTA*/
CREATE PROCEDURE [dbo].[spInsertarEspecialista]
(
@DNI CHAR(8),
@CODIGO_ESP CHAR(4),
@NOMBRE VARCHAR(25),
@APELLIDO VARCHAR(25),
@TELEFONO VARCHAR(15),
@EMAIL VARCHAR(20)
)
AS
INSERT INTO Especialistas
(
DNI_Especialistas,
Cod_Especialidad_Especialistas,
Nombre_Especialistas,
Apellido_Especialistas,
Telefono_Especialistas,
Email_Especialistas
)
VALUES
(
@DNI,
@CODIGO_ESP,
@NOMBRE,
@APELLIDO,
@TELEFONO,
@EMAIL
)RETURN
GO
/****** Object:  StoredProcedure [dbo].[spInsertarHorario]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*PROCEDIMIENTO PARA AGREGAR HORARIO*/
CREATE PROCEDURE [dbo].[spInsertarHorario]
(
@DNI CHAR(8),
@ESP CHAR(4),
@DIA INT,
@HORA INT
)
AS
INSERT INTO EspecialistaXDiaXHora
(
DNI_Especialistas_EXDXH,
Cod_Especialidad_EXDXH,
Id_Dias_EXDXH,
Id_Horas_EXDXH
)
VALUES
(
@DNI,
@ESP,
@DIA,
@HORA
)RETURN
GO
/****** Object:  StoredProcedure [dbo].[spInsertarPaciente]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*PROCEDIMIENTO PARA CREAR UN PACIENTE*/
CREATE PROCEDURE [dbo].[spInsertarPaciente]
(
@DNI CHAR(8),
@CODIGO_OS CHAR(4),
@NOMBRE VARCHAR(25),
@APELLIDO VARCHAR(25),
@NROASOC VARCHAR(10),
@FECHANAC VARCHAR(10),
@TELEFONO VARCHAR(15),
@EMAIL VARCHAR(20)
)
AS
INSERT INTO Pacientes
(
DNI_Pacientes,
Cod_Obra_Social_Pacientes,
Nombre_Pacientes,
Apellido_Pacientes,
Numero_Asociado_Pacientes,
Fecha_Nacimiento_Paciente,
Telefono_Pacientes,
Email_Pacientes
)
VALUES
(
@DNI,
@CODIGO_OS,
@NOMBRE,
@APELLIDO,
@NROASOC,
@FECHANAC,
@TELEFONO,
@EMAIL
)RETURN
GO
/****** Object:  StoredProcedure [dbo].[spInsertarTurno]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*PROCEDIMIENTO PARA AGREGAR TURNO*/
CREATE PROCEDURE [dbo].[spInsertarTurno]
(
@Dni_Especialista_Turnos CHAR(8),
@Cod_Especialidad_Turnos CHAR(4),
@Dni_Paciente_Turnos CHAR(8),
@Asistencia_Turnos INT,
@Motivo_Consulta_Turnos VARCHAR(50),
@Fecha_Turnos VARCHAR(10),
@Id_Dia_Turnos INT,
@Id_Hora_Turnos INT,
@Horario_Turnos VARCHAR(25),
@Dia_Turnos VARCHAR(10)
)
AS
INSERT INTO Turnos
(
Dni_Especialista_Turnos,
Cod_Especialidad_Turnos,
Dni_Paciente_Turnos,
Asistencia_Turnos,
Motivo_Consulta_Turnos,
Fecha_Turnos,
Id_Dia_Turnos,
Id_Hora_Turnos,
Horario_Turnos,
Dia_Turnos
)
VALUES
(
@Dni_Especialista_Turnos,
@Cod_Especialidad_Turnos,
@Dni_Paciente_Turnos,
@Asistencia_Turnos,
@Motivo_Consulta_Turnos,
@Fecha_Turnos,
@Id_Dia_Turnos,
@Id_Hora_Turnos,
@Horario_Turnos,
@Dia_Turnos
)RETURN
GO
/****** Object:  StoredProcedure [dbo].[spInsertarUsuario]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* PROCEDIMIENTO PARA CREAR USUARIOS */
CREATE PROCEDURE [dbo].[spInsertarUsuario]
(
@USUARIO VARCHAR(30),
@EMAIL VARCHAR(30),
@CONTRASENIA VARCHAR(30),
@TIPO CHAR(1)
)
AS
INSERT INTO Usuarios
(
Usuario_Usuarios,
Email_Usuarios,
Contraseña_Usuarios,
Tipo_Usuarios
)
VALUES
(
@USUARIO,
@EMAIL,
@CONTRASENIA,
@TIPO
)RETURN
GO
/****** Object:  StoredProcedure [dbo].[spRestaurarHorario]    Script Date: 19/12/2022 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*PROCEDIMIENTO PARA RESTAURAR HORARIO EXISTENTE*/
CREATE PROCEDURE [dbo].[spRestaurarHorario]
(
@DNI CHAR(8),
@DIA INT,
@HORA INT
)
AS
UPDATE EspecialistaXDiaXHora SET Estado_EXDXH=1 WHERE DNI_Especialistas_EXDXH = @DNI AND Id_Dias_EXDXH=@DIA AND Id_Horas_EXDXH=@HORA 
RETURN
GO
USE [master]
GO
ALTER DATABASE [Clinica_TpIntegrador] SET  READ_WRITE 
GO
