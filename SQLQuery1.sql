IF DB_ID('GastosDB') IS NULL
    CREATE DATABASE GastosDB;
GO

USE GastosDB;
GO

IF OBJECT_ID('dbo.Gastos', 'U') IS NULL
BEGIN
    CREATE TABLE Gastos (
        Id          INT IDENTITY(1,1) PRIMARY KEY,
        Descripcion NVARCHAR(100) NOT NULL,
        Monto       DECIMAL(10,2) NOT NULL,
        Categoria   NVARCHAR(50)  NOT NULL
    );
END
GO

DELETE FROM Gastos;
GO

INSERT INTO Gastos (Descripcion, Monto, Categoria) VALUES
    (N'Almuerzo ejecutivo', 120.00, N'Comida'),
    (N'Gasolina',           200.00, N'Transporte'),
    (N'Internet residencial', 50.50, N'Servicios');
GO