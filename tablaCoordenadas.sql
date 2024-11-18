USE [DatabaseTest]
GO

/****** Object:  Table [dbo].[Coordenadas]    Script Date: 18/11/2024 18:21:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coordenadas](
	[Coor_Id] [int] NOT NULL,
	[Barco_Id] [int] NOT NULL,
	[Coor_X] [int] NULL,
	[Coor_Y] [int] NULL,
	[Coor_Jugador] [int] NULL,
 CONSTRAINT [PK_Coordenadas] PRIMARY KEY CLUSTERED 
(
	[Coor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Coordenadas]  WITH CHECK ADD  CONSTRAINT [FK_Coordenadas_Barcos] FOREIGN KEY([Barco_Id])
REFERENCES [dbo].[Barcos] ([Barco_Id])
GO

ALTER TABLE [dbo].[Coordenadas] CHECK CONSTRAINT [FK_Coordenadas_Barcos]
GO

