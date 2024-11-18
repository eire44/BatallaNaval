USE [DatabaseTest]
GO

/****** Object:  Table [dbo].[Barcos]    Script Date: 18/11/2024 19:57:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Barcos](
	[Barco_Id] [int] NOT NULL,
	[Barco_Tipo] [varchar](50) NULL,
	[Barco_Vida] [int] NOT NULL,
	[Barco_Jugador] [nchar](10) NULL,
 CONSTRAINT [PK_Barcos] PRIMARY KEY CLUSTERED 
(
	[Barco_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

