IF NOT EXISTS(SELECT 1 FROM sys.databases WHERE name='ApuestaTo')
    CREATE DATABASE ApuestaTo;
GO

USE ApuestaTo;
GO

CREATE TABLE [dbo].[Deportes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Nombre] VARCHAR(50) NOT NULL,
);
GO

CREATE TABLE [dbo].[TiposApuesta] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Descripcion] VARCHAR(50) NOT NULL,
    [Multiplicador] INT NOT NULL,
    [Riesgo] VARCHAR(15) NOT NULL,
    [DeporteId] INT NOT NULL,
    [NotasExtra] TEXT NULL,

    CONSTRAINT FK_TiposApuestas_Deportes FOREIGN KEY(DeporteId)
    REFERENCES [dbo].[Deportes](Id),
);
GO

CREATE TABLE [dbo].[TiposEvento] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [DeporteId] INT NOT NULL,
    [Competicion] VARCHAR(50) NOT NULL,
    [FechaInicio] DATE NOT NULL,
    [FechaFin] DATE NOT NULL,
    [Descripcion] TEXT NULL,

    CONSTRAINT FK_TiposEvento_Deportes FOREIGN KEY(DeporteId)
    REFERENCES [dbo].[Deportes](Id),
);
GO




