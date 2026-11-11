USE InventoryManagement;
GO

CREATE OR ALTER PROCEDURE sp_CreateProduct
(
    @CategoriaId INT,
    @Nombre VARCHAR(150),
    @Descripcion VARCHAR(500),
    @Precio DECIMAL(18,2)
)
AS
BEGIN

    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        INSERT INTO Productos
        (
            CategoriaId,
            Nombre,
            Descripcion,
            Precio
        )
        VALUES
        (
            @CategoriaId,
            @Nombre,
            @Descripcion,
            @Precio
        );

        DECLARE @ProductId INT = SCOPE_IDENTITY();

        COMMIT TRANSACTION;

        SELECT @ProductId AS ProductId;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END
GO

CREATE OR ALTER PROCEDURE sp_UpdateProduct
(
    @ProductoId INT,
    @CategoriaId INT,
    @Nombre VARCHAR(150),
    @Descripcion VARCHAR(500),
    @Precio DECIMAL(18,2)
)
AS
BEGIN

    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        UPDATE Productos
        SET
            CategoriaId = @CategoriaId,
            Nombre = @Nombre,
            Descripcion = @Descripcion,
            Precio = @Precio
        WHERE ProductoId = @ProductoId;

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 51001, 'Product not found.', 1;
        END

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END
GO

CREATE OR ALTER PROCEDURE sp_DeleteProduct
(
    @ProductoId INT
)
AS
BEGIN

    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        UPDATE Productos
        SET
            Activo = 0
        WHERE ProductoId = @ProductoId;

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 51002, 'Product not found.', 1;
        END

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END
GO

CREATE OR ALTER PROCEDURE sp_CreateCategory
(
    @Nombre VARCHAR(100),
    @Descripcion VARCHAR(500)
)
AS
BEGIN

    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        INSERT INTO Categorias
        (
            Nombre,
            Descripcion
        )
        VALUES
        (
            @Nombre,
            @Descripcion
        );

        DECLARE @CategoryId INT = SCOPE_IDENTITY();

        COMMIT TRANSACTION;

        SELECT @CategoryId AS CategoryId;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END
GO

CREATE OR ALTER PROCEDURE sp_UpdateCategory
(
@CategoriaId INT,
@Nombre VARCHAR(100),
@Descripcion VARCHAR(500)
)
AS
BEGIN
 
SET NOCOUNT ON;
SET XACT_ABORT ON;
 
BEGIN TRY
 
BEGIN TRANSACTION;
 
UPDATE Categorias
SET
Nombre = @Nombre,
Descripcion = @Descripcion
WHERE CategoriaId = @CategoriaId;
 
IF @@ROWCOUNT = 0
BEGIN
THROW 51003, 'Category not found.', 1;
END
 
COMMIT TRANSACTION;
 
END TRY
BEGIN CATCH
 
IF @@TRANCOUNT > 0
ROLLBACK TRANSACTION;
 
THROW;
 
END CATCH
 
END
GO

CREATE OR ALTER PROCEDURE sp_DeleteCategory
(
    @CategoriaId INT
)
AS
BEGIN

    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        UPDATE Categorias
        SET
            Activo = 0
        WHERE CategoriaId = @CategoriaId;

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 51004, 'Category not found.', 1;
        END

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END
GO

CREATE OR ALTER PROCEDURE sp_InsertMovInv
(
    @ProductoId INT,
    @TipoMovimiento CHAR(1),
    @Cantidad INT,
    @Observaciones VARCHAR(500)
)
AS
BEGIN

    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        IF @Cantidad <= 0
        BEGIN
            THROW 51005, 'Quantity must be greater than zero.', 1;
        END

        IF @TipoMovimiento NOT IN ('E', 'S')
        BEGIN
            THROW 51006, 'Invalid movement type.', 1;
        END

        IF NOT EXISTS
        (
            SELECT 1
            FROM Productos
            WHERE ProductoId = @ProductoId
                AND Activo = 1
        )
        BEGIN
            THROW 51007, 'Product not found.', 1;
        END

        IF @TipoMovimiento = 'S'
        BEGIN

            IF EXISTS
            (
                SELECT 1
                FROM Productos
                WHERE ProductoId = @ProductoId
                    AND StockActual < @Cantidad
            )
            BEGIN
                THROW 51008, 'Insufficient stock.', 1;
            END

        END

        INSERT INTO MovimientosInventario
        (
            ProductoId,
            TipoMovimiento,
            Cantidad,
            Observaciones
        )
        VALUES
        (
            @ProductoId,
            @TipoMovimiento,
            @Cantidad,
            @Observaciones
        );

        UPDATE Productos
        SET
            StockActual =
                CASE
                    WHEN @TipoMovimiento = 'E'
                        THEN StockActual + @Cantidad
                    ELSE StockActual - @Cantidad
                END
        WHERE ProductoId = @ProductoId;

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END
GO