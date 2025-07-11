USE [master]
GO
/****** Object:  Database [Lojinha]    Script Date: 02/11/2023 14:21:38 ******/
CREATE DATABASE [Lojinha]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Lojinha', FILENAME = N'T:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Lojinha.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Lojinha_log', FILENAME = N'T:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Lojinha_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Lojinha] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Lojinha].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Lojinha] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lojinha] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lojinha] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lojinha] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lojinha] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lojinha] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Lojinha] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lojinha] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lojinha] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lojinha] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lojinha] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lojinha] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lojinha] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lojinha] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lojinha] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Lojinha] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lojinha] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lojinha] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lojinha] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lojinha] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lojinha] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lojinha] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lojinha] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Lojinha] SET  MULTI_USER 
GO
ALTER DATABASE [Lojinha] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lojinha] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lojinha] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lojinha] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Lojinha] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Lojinha] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Lojinha] SET QUERY_STORE = OFF
GO
USE [Lojinha]
GO
/****** Object:  User [adminLojinha]    Script Date: 02/11/2023 14:21:38 ******/
CREATE USER [adminLojinha] FOR LOGIN [adminLojinha] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 02/11/2023 14:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[ControlId] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 02/11/2023 14:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Genre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 02/11/2023 14:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Category] [int] NOT NULL,
	[productGender] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/11/2023 14:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Description], [Status], [ControlId]) VALUES (1, N'T-Shirts', N'Camisetas manga curta', 1, 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Status], [ControlId]) VALUES (2, N'Capsw', N'Bones e Bombetas', 0, 9)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Status], [ControlId]) VALUES (3, N'Body', N'underwear', 1, 32)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Status], [ControlId]) VALUES (4, N'Calça', N'Calça', 0, 0)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Status], [ControlId]) VALUES (7, N'asdfasdf', N'asdfasd', 0, 0)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Status], [ControlId]) VALUES (8, N'etgwrg', N'sdfhfghfsgh', 0, 0)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Status], [ControlId]) VALUES (9, N'sadfsdfasd', N'dhsdfhsfghgf', 0, 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Name], [Description], [Genre]) VALUES (1, N'Underwear', N'roupa intima', N'female')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Description], [Category], [productGender]) VALUES (2, N'HomemAranha', N'Camiseta', 1, 0)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Category], [productGender]) VALUES (4, N'Captain America', N'T-Shirta', 2, 0)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Category], [productGender]) VALUES (15, N'John Wick', N'soco ingles', 1, 0)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Category], [productGender]) VALUES (24, N'SuperMan', N'Camiseta do superhomem unissex tamanho unico', 1, 0)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Category], [productGender]) VALUES (25, N'Thor', N'Boné Marvel Thor', 2, 0)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Category], [productGender]) VALUES (32, N'Wonder Woman', N'Body', 3, 0)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231018122518_Initial', N'7.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231018204514_Updating', N'7.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231018205107_AddCategoryTable', N'7.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231018210422_ChangeCategoryTable', N'7.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231018211745_AddDepartmentModel', N'7.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231018214158_ChangeProductModelAddGenderEnum', N'7.0.12')
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((0)) FOR [ControlId]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [productGender]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_ip_address]    Script Date: 02/11/2023 14:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_get_ip_address] (@ip varchar(40) out)
as
begin
Declare @ipLine varchar(200)
Declare @pos int
set nocount on
          set @ip = NULL
          Create table #temp (ipLine varchar(200))
          Insert #temp exec master..xp_cmdshell 'ipconfig'
          select @ipLine = ipLine
          from #temp
          where upper (ipLine) like '%IP ADDRESS%'
          if (isnull (@ipLine,'***') != '***')
          begin 
                set @pos = CharIndex (':',@ipLine,1);
                set @ip = rtrim(ltrim(substring (@ipLine , 
               @pos + 1 ,
                len (@ipLine) - @pos)))
           end 
drop table #temp
set nocount off
end 
GO
USE [master]
GO
ALTER DATABASE [Lojinha] SET  READ_WRITE 
GO
