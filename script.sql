USE [master]
GO
/****** Object:  Database [dbGMAP]    Script Date: 09.11.2020 22:48:04 ******/
CREATE DATABASE [dbGMAP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbGMAP', FILENAME = N'D:\Моя папка\TestGMAP\dbGMAP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbGMAP_log', FILENAME = N'D:\Моя папка\TestGMAP\dbGMAP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbGMAP] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbGMAP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbGMAP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbGMAP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbGMAP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbGMAP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbGMAP] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbGMAP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbGMAP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbGMAP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbGMAP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbGMAP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbGMAP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbGMAP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbGMAP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbGMAP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbGMAP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbGMAP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbGMAP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbGMAP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbGMAP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbGMAP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbGMAP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbGMAP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbGMAP] SET RECOVERY FULL 
GO
ALTER DATABASE [dbGMAP] SET  MULTI_USER 
GO
ALTER DATABASE [dbGMAP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbGMAP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbGMAP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbGMAP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbGMAP] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbGMAP', N'ON'
GO
ALTER DATABASE [dbGMAP] SET QUERY_STORE = OFF
GO
USE [dbGMAP]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [dbGMAP]
GO
/****** Object:  Table [dbo].[T_MarkerType]    Script Date: 09.11.2020 22:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_MarkerType](
	[id_markerType] [int] IDENTITY(1,1) NOT NULL,
	[color] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_T_MarkerType] PRIMARY KEY CLUSTERED 
(
	[id_markerType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Position]    Script Date: 09.11.2020 22:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Position](
	[id_position] [int] IDENTITY(1,1) NOT NULL,
	[id_techUnit] [int] NOT NULL,
	[id_markerType] [int] NOT NULL,
	[latitude] [float] NOT NULL,
	[longtitude] [float] NOT NULL,
 CONSTRAINT [PK_T_Position] PRIMARY KEY CLUSTERED 
(
	[id_position] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TechUnit]    Script Date: 09.11.2020 22:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TechUnit](
	[id_techUnit] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_T_TechUnit] PRIMARY KEY CLUSTERED 
(
	[id_techUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_MarkerType] ON 

INSERT [dbo].[T_MarkerType] ([id_markerType], [color]) VALUES (1, N'Red')
INSERT [dbo].[T_MarkerType] ([id_markerType], [color]) VALUES (2, N'Blue')
INSERT [dbo].[T_MarkerType] ([id_markerType], [color]) VALUES (3, N'Green')
INSERT [dbo].[T_MarkerType] ([id_markerType], [color]) VALUES (4, N'Yellow')
SET IDENTITY_INSERT [dbo].[T_MarkerType] OFF
SET IDENTITY_INSERT [dbo].[T_Position] ON 

INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (1, 2, 2, 54.982933044433594, 82.913131713867188)
INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (2, 1, 3, 54.990516662597656, 82.895538330078125)
INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (3, 3, 1, 55.005977630615234, 82.91107177734375)
INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (4, 4, 4, 55.009422302246094, 82.941452026367188)
INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (5, 6, 3, 55.021923065185547, 82.956390380859375)
INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (6, 6, 2, 55.028415679931641, 82.932876586914062)
INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (7, 6, 1, 55.046516418457031, 82.929267883300781)
INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (8, 6, 3, 55.0018424987793, 82.876907348632812)
INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (9, 6, 2, 55.013751983642578, 82.8860092163086)
INSERT [dbo].[T_Position] ([id_position], [id_techUnit], [id_markerType], [latitude], [longtitude]) VALUES (10, 5, 2, 55.03675, 82.883327)
SET IDENTITY_INSERT [dbo].[T_Position] OFF
SET IDENTITY_INSERT [dbo].[T_TechUnit] ON 

INSERT [dbo].[T_TechUnit] ([id_techUnit], [name]) VALUES (1, N'GoogleUnit')
INSERT [dbo].[T_TechUnit] ([id_techUnit], [name]) VALUES (2, N'AppleUnit')
INSERT [dbo].[T_TechUnit] ([id_techUnit], [name]) VALUES (3, N'AndroidUnit')
INSERT [dbo].[T_TechUnit] ([id_techUnit], [name]) VALUES (4, N'MicrosoftUnit')
INSERT [dbo].[T_TechUnit] ([id_techUnit], [name]) VALUES (5, N'AdobeUnit')
INSERT [dbo].[T_TechUnit] ([id_techUnit], [name]) VALUES (6, N'RandomUnit')
SET IDENTITY_INSERT [dbo].[T_TechUnit] OFF
/****** Object:  Index [IX_FK_T_Position_T_MarkerType]    Script Date: 09.11.2020 22:48:05 ******/
CREATE NONCLUSTERED INDEX [IX_FK_T_Position_T_MarkerType] ON [dbo].[T_Position]
(
	[id_markerType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_T_Position_T_TechUnit]    Script Date: 09.11.2020 22:48:05 ******/
CREATE NONCLUSTERED INDEX [IX_FK_T_Position_T_TechUnit] ON [dbo].[T_Position]
(
	[id_techUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_Position]  WITH CHECK ADD  CONSTRAINT [FK_T_Position_T_MarkerType] FOREIGN KEY([id_markerType])
REFERENCES [dbo].[T_MarkerType] ([id_markerType])
GO
ALTER TABLE [dbo].[T_Position] CHECK CONSTRAINT [FK_T_Position_T_MarkerType]
GO
ALTER TABLE [dbo].[T_Position]  WITH CHECK ADD  CONSTRAINT [FK_T_Position_T_TechUnit] FOREIGN KEY([id_techUnit])
REFERENCES [dbo].[T_TechUnit] ([id_techUnit])
GO
ALTER TABLE [dbo].[T_Position] CHECK CONSTRAINT [FK_T_Position_T_TechUnit]
GO
USE [master]
GO
ALTER DATABASE [dbGMAP] SET  READ_WRITE 
GO
