USE InventoryManagement;
GO

CREATE TABLE Categorias
(
CategoriaId INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(100) NOT NULL,
Descripcion VARCHAR(500) NULL,
Activo BIT NOT NULL DEFAULT 1,
);
GO
 
CREATE TABLE Productos
(
ProductoId INT IDENTITY(1,1) PRIMARY KEY,
CategoriaId INT NOT NULL,
Nombre VARCHAR(150) NOT NULL,
Descripcion VARCHAR(500) NULL,
Precio DECIMAL(18,2) NOT NULL,
StockActual INT NOT NULL DEFAULT 0,
Activo BIT NOT NULL DEFAULT 1,

 
CONSTRAINT FK_Productos_Categorias
FOREIGN KEY (CategoriaId)
REFERENCES Categorias(CategoriaId)
);
GO
 
CREATE TABLE MovimientosInventario
(
MovimientoId INT IDENTITY(1,1) PRIMARY KEY,
ProductoId INT NOT NULL,
TipoMovimiento CHAR(1) NOT NULL,
Cantidad INT NOT NULL,
Observaciones VARCHAR(500) NULL,

 
CONSTRAINT FK_MovimientosInventario_Productos
FOREIGN KEY (ProductoId)
REFERENCES Productos(ProductoId)
);
GO


CREATE TABLE Users
(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(100) NOT NULL,
    Email VARCHAR(200) NOT NULL,
    PasswordHash VARCHAR(500) NOT NULL,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT UQ_Users_Email UNIQUE (Email),
    CONSTRAINT UQ_Users_UserName UNIQUE (UserName)
);
GO

CREATE TABLE RefreshTokens
(
    RefreshTokenId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Token VARCHAR(1000) NOT NULL,
    ExpiresAt DATETIME2 NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    RevokedAt DATETIME2 NULL,
    IsRevoked BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_RefreshTokens_Users
    FOREIGN KEY (UserId)
    REFERENCES Users(UserId)
);
GO