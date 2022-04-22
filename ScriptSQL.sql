USE [master]
GO

/****** Object:  Database [Prueba7]    Script Date: 4/18/2022 11:40:51 AM ******/
CREATE DATABASE [Prueba7]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Prueba7', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Prueba7.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Prueba7_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Prueba7_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [Prueba7] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Prueba7].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Prueba7] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Prueba7] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Prueba7] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Prueba7] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Prueba7] SET ARITHABORT OFF 
GO

ALTER DATABASE [Prueba7] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Prueba7] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Prueba7] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Prueba7] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Prueba7] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Prueba7] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Prueba7] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Prueba7] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Prueba7] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Prueba7] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Prueba7] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Prueba7] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Prueba7] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Prueba7] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Prueba7] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Prueba7] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Prueba7] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Prueba7] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Prueba7] SET  MULTI_USER 
GO

ALTER DATABASE [Prueba7] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Prueba7] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Prueba7] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Prueba7] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Prueba7] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Prueba7] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Prueba7] SET  READ_WRITE 
GO


USE [Prueba7]
GO

/****** Object:  Table [dbo].[Authors]    Script Date: 4/18/2022 11:38:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Birthday] [datetime] NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Year] [int] NOT NULL,
	[NumberPages] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO

ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO