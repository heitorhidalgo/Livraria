CREATE TABLE Livro (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Título VARCHAR(100),
    Genero VARCHAR(100),
	AnoPublicacao INT,
	AutorId INT FOREIGN KEY (AutorId) REFERENCES Autor(Id)
);

USE [Livraria]
GO

/****** Object:  Table [dbo].[Autor]    Script Date: 26/04/2025 10:46:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Autor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Nacionalidade] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


