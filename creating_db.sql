USE [Space_Technology]
GO
/****** Object:  Table [dbo].[kategoria]    Script Date: 2023-02-13 16:44:02 ******/
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
/****** Object:  Table [dbo].[produkt]    Script Date: 2023-02-13 16:44:02 ******/
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
/****** Object:  Table [dbo].[produkt_kategoria]    Script Date: 2023-02-13 16:44:02 ******/
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
/****** Object:  Table [dbo].[zamowienie]    Script Date: 2023-02-13 16:44:02 ******/
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
/****** Object:  Table [dbo].[zamowienie_produkt]    Script Date: 2023-02-13 16:44:02 ******/
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
SET IDENTITY_INSERT [dbo].[kategoria] ON 

INSERT [dbo].[kategoria] ([id], [kategoria]) VALUES (1, N'Dyski SSD')
INSERT [dbo].[kategoria] ([id], [kategoria]) VALUES (2, N'Laptopy')
INSERT [dbo].[kategoria] ([id], [kategoria]) VALUES (3, N'Monitory')
SET IDENTITY_INSERT [dbo].[kategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[produkt] ON 

INSERT [dbo].[produkt] ([id], [nazwa], [model], [opis], [ilosc_dostepna], [cena]) VALUES (1, N'Samsung Portable SSD T7', N'MU-PC1T0H/WW', N'Samsung Portable SSD T7 500GB USB 3.2 Gen. 2 Szary', 50, CAST(299.00 AS Decimal(10, 2)))
INSERT [dbo].[produkt] ([id], [nazwa], [model], [opis], [ilosc_dostepna], [cena]) VALUES (4, N'Acer Nitro VG240YBMIIX czarny', N'UM.QV0EE.001', N'Nitro VG240YBMIIX to monitor dedykowany graczom. Dziêki wysokiemu kontrastowi w ciemnych scenach czernie bêd¹ g³êbsze. Minusem jest niskie pokrycie kolorów. Poza tym gamut jest przesuniêty wzglêdem orygina³u. Natomiast plusem s¹ opcje powi¹zane z grami, a samo OSD przejrzyste i ³atwe w obs³udze.', 10, CAST(589.00 AS Decimal(10, 2)))
INSERT [dbo].[produkt] ([id], [nazwa], [model], [opis], [ilosc_dostepna], [cena]) VALUES (5, N'Samsung Odyssey G3', N'F27G35TFWUX', N'Monitor LED 24" Samsung Odyssey LS24AG30ANUXEN
Zachwycaj¹cy design oraz niezwykle bogata funkcjonalnoœæ – to czyni z monitora Samsung Odyssey LS24AG30ANUXEN narzêdzie, dziêki któremu odkryjesz gaming na nowo. Solidna konstrukcja po³¹czona z panelem VA Full HD oferuje najlepsze doznania z gry w ka¿dym calu. Bogate kolory, najdrobniejsze szczegó³y i niezwykle szybki czas reakcji to cechy, dziêki którym odniesiesz sukces na wirtualnych polach bitwy.', 5, CAST(700.00 AS Decimal(10, 2)))
INSERT [dbo].[produkt] ([id], [nazwa], [model], [opis], [ilosc_dostepna], [cena]) VALUES (6, N'Dell Precision 7670 i9-12950HX/128GB/1TB/Win11P RTX A5500', N'XCTOP7670EMEA_VP_5', N'Laptop biznesowy Dell Precision 7670
Szukasz laptopa idealnego do biznesu? Dell Precision 7670 ma wszystko, czego Ci potrzeba. Kamera z czujnikiem na podczerwieñ zadba o Twoj¹ prywatnoœæ, a wysoka jasnoœæ ekranu pozwoli Ci pracowaæ z ka¿dego miejsca. Wydajne podzespo³y zadbaj¹ o szybk¹ i produktywn¹ pracê.', 0, CAST(44179.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[produkt] OFF
GO
SET IDENTITY_INSERT [dbo].[produkt_kategoria] ON 

INSERT [dbo].[produkt_kategoria] ([id], [id_produkt], [id_kategoria]) VALUES (1, 1, 1)
INSERT [dbo].[produkt_kategoria] ([id], [id_produkt], [id_kategoria]) VALUES (2, 4, 3)
INSERT [dbo].[produkt_kategoria] ([id], [id_produkt], [id_kategoria]) VALUES (3, 5, 3)
INSERT [dbo].[produkt_kategoria] ([id], [id_produkt], [id_kategoria]) VALUES (4, 6, 2)
SET IDENTITY_INSERT [dbo].[produkt_kategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[zamowienie] ON 

INSERT [dbo].[zamowienie] ([id], [numer_zamowienia], [data_zamowienia]) VALUES (1, N'001', CAST(N'2023-01-01T11:27:38.000' AS DateTime))
INSERT [dbo].[zamowienie] ([id], [numer_zamowienia], [data_zamowienia]) VALUES (2, N'002', CAST(N'2023-01-01T15:27:38.000' AS DateTime))
INSERT [dbo].[zamowienie] ([id], [numer_zamowienia], [data_zamowienia]) VALUES (3, N'003', CAST(N'2023-01-02T13:27:38.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[zamowienie] OFF
GO
SET IDENTITY_INSERT [dbo].[zamowienie_produkt] ON 

INSERT [dbo].[zamowienie_produkt] ([id], [id_produkt], [id_zamowienie], [ilosc], [cena]) VALUES (1, 1, 1, 1, CAST(199.00 AS Decimal(10, 2)))
INSERT [dbo].[zamowienie_produkt] ([id], [id_produkt], [id_zamowienie], [ilosc], [cena]) VALUES (2, 4, 1, 1, CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[zamowienie_produkt] ([id], [id_produkt], [id_zamowienie], [ilosc], [cena]) VALUES (3, 5, 1, 2, CAST(650.00 AS Decimal(10, 2)))
INSERT [dbo].[zamowienie_produkt] ([id], [id_produkt], [id_zamowienie], [ilosc], [cena]) VALUES (4, 1, 2, 3, CAST(199.00 AS Decimal(10, 2)))
INSERT [dbo].[zamowienie_produkt] ([id], [id_produkt], [id_zamowienie], [ilosc], [cena]) VALUES (5, 4, 2, 1, CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[zamowienie_produkt] ([id], [id_produkt], [id_zamowienie], [ilosc], [cena]) VALUES (6, 6, 3, 1, CAST(44179.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[zamowienie_produkt] OFF
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
