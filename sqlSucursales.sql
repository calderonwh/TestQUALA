CREATE DATABASE DbaQUALA
Go

Use DbaQUALA

CREATE TABLE SucursalesTest (
    IdSucursal INT IDENTITY(1,1) PRIMARY KEY,
    Codigo INT NOT NULL,
    Descripcion NVARCHAR(250) NOT NULL,
    Direccion NVARCHAR(250) NOT NULL,
    Identificacion NVARCHAR(50) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    IdMoneda INT NOT NULL,
    CONSTRAINT CHK_FechaCreacion CHECK (FechaCreacion >= GETDATE())
);


CREATE TABLE MonedasTest (
    IdMoneda INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Simbolo NVARCHAR(10) NOT NULL
);


INSERT INTO MonedasTest (Nombre, Simbolo) VALUES 
('Dólar', '$'),
('Euro', '€'),
('Peso', 'P');
