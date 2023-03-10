USE [master]
GO
/****** Object:  Database [Space_Technology]    Script Date: 22.02.2023 10:17:32 ******/
CREATE DATABASE [Space_Technology]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Space_Technology', FILENAME = N'C:\Users\palus\Desktop\work\Space_Technology\Space_Technology.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Space_Technology_log', FILENAME = N'C:\Users\palus\Desktop\work\Space_Technology\Space_Technology_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Space_Technology] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Space_Technology].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Space_Technology] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Space_Technology] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Space_Technology] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Space_Technology] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Space_Technology] SET ARITHABORT OFF 
GO
ALTER DATABASE [Space_Technology] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Space_Technology] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Space_Technology] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Space_Technology] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Space_Technology] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Space_Technology] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Space_Technology] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Space_Technology] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Space_Technology] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Space_Technology] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Space_Technology] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Space_Technology] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Space_Technology] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Space_Technology] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Space_Technology] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Space_Technology] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Space_Technology] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Space_Technology] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Space_Technology] SET  MULTI_USER 
GO
ALTER DATABASE [Space_Technology] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Space_Technology] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Space_Technology] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Space_Technology] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Space_Technology] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Space_Technology] SET QUERY_STORE = OFF
GO
USE [Space_Technology]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Space_Technology]
GO
/****** Object:  Table [dbo].[kategoria]    Script Date: 22.02.2023 10:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kategoria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kategoria] [nvarchar](250) NULL,
 CONSTRAINT [PK_kategoria] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[produkt]    Script Date: 22.02.2023 10:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produkt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [nvarchar](100) NULL,
	[model] [nvarchar](100) NULL,
	[opis] [nvarchar](500) NULL,
	[ilosc_dostepna] [int] NULL,
	[cena] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[produkt_kategoria]    Script Date: 22.02.2023 10:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produkt_kategoria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_produkt] [int] NULL,
	[id_kategoria] [int] NULL,
 CONSTRAINT [PK_produkt_kategoria] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zamowienie]    Script Date: 22.02.2023 10:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zamowienie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numer_zamowienia] [nvarchar](50) NULL,
	[data_zamowienia] [datetime] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zamowienie_produkt]    Script Date: 22.02.2023 10:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zamowienie_produkt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_produkt] [int] NULL,
	[id_zamowienie] [int] NULL,
	[ilosc] [int] NULL,
	[cena] [decimal](10, 2) NULL,
 CONSTRAINT [PK_zamowienie_produkty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[produkt_kategoria]  WITH CHECK ADD  CONSTRAINT [FK_produkt_kategoria_kategoria] FOREIGN KEY([id_kategoria])
REFERENCES [dbo].[kategoria] ([id])
GO
ALTER TABLE [dbo].[produkt_kategoria] CHECK CONSTRAINT [FK_produkt_kategoria_kategoria]
GO
ALTER TABLE [dbo].[produkt_kategoria]  WITH CHECK ADD  CONSTRAINT [FK_produkt_kategoria_produkt] FOREIGN KEY([id_produkt])
REFERENCES [dbo].[produkt] ([id])
GO
ALTER TABLE [dbo].[produkt_kategoria] CHECK CONSTRAINT [FK_produkt_kategoria_produkt]
GO
ALTER TABLE [dbo].[zamowienie_produkt]  WITH CHECK ADD  CONSTRAINT [FK_zamowienie_produkt_produkt] FOREIGN KEY([id_produkt])
REFERENCES [dbo].[produkt] ([id])
GO
ALTER TABLE [dbo].[zamowienie_produkt] CHECK CONSTRAINT [FK_zamowienie_produkt_produkt]
GO
ALTER TABLE [dbo].[zamowienie_produkt]  WITH CHECK ADD  CONSTRAINT [FK_zamowienie_produkt_zamowienie] FOREIGN KEY([id_zamowienie])
REFERENCES [dbo].[zamowienie] ([id])
GO
ALTER TABLE [dbo].[zamowienie_produkt] CHECK CONSTRAINT [FK_zamowienie_produkt_zamowienie]
GO
USE [master]
GO
ALTER DATABASE [Space_Technology] SET  READ_WRITE 
GO
