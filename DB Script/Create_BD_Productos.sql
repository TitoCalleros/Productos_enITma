-- *****************************************************************************
-- Creación de la base de datos BD_RRHH con la tabla: Exa_CatalogoProducto
-- Autor: Tito Manuel Calleros Torres
-- Fecha de creación 18/10/2025

USE master;
GO

-- Verificar si existe la BD
IF EXISTS(SELECT name FROM sys.databases WHERE name = N'BD_PRODUCTOS')
BEGIN
	ALTER DATABASE BD_PRODUCTOS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE BD_PRODUCTOS;
END
GO

-- Crear la BD. Se define el Collation Modern_Spanish_CI_AS por si la BD tiene una Collation diferente por default.
CREATE DATABASE BD_PRODUCTOS
	COLLATE Modern_Spanish_CI_AS;
GO

-- Indicar que se usará la BD recién creada
USE BD_PRODUCTOS;
GO

-- Crear esquema Ventas
CREATE SCHEMA [Ventas];
GO

-- Verificar si existe la tabla Exa_CatalogoProducto
IF OBJECT_ID('Exa_CatalogoProducto', 'U') IS NOT NULL
	DROP TABLE [Exa_CatalogoProducto];
GO

-- Crear la tabla Exa_CatalogoProducto
CREATE TABLE [Ventas].[Exa_CatalogoProducto] 
(
	[idProducto] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,		
	[descripcion] VARCHAR(256) NOT NULL,
	[idUsuario] INT NOT NULL,
	[FechaCreacion] DATETIME
);
GO

-- Crear índice para consultas por idProducto
CREATE NONCLUSTERED INDEX IX_Exa_CatalogoProducto_idProducto
	ON Ventas.Exa_CatalogoProducto(idProducto);
GO

-- Crear Stored Procedure sp_InsCatalogoProd
CREATE PROCEDURE [Ventas].[sp_InsertarCatalogoProducto]
    @descripcion VARCHAR(256),
    @idUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el idUsuario sea 1
    IF @idUsuario <> 1
    BEGIN
        RAISERROR('Solo se permite insertar registros con idUsuario = 1.', 16, 1);
        RETURN;
    END;

    -- Insertar registro
    INSERT INTO [Ventas].[Exa_CatalogoProducto] ([descripcion], [idUsuario], [FechaCreacion])
    VALUES (@descripcion, @idUsuario, GETDATE());

    -- Devolver el ID recién generado
    SELECT SCOPE_IDENTITY() AS idProductoNuevo;
END;
GO

-- Crear Stored Procedure para obtener todos los registros
CREATE PROCEDURE [Ventas].[sp_GetAllCatalogoProd]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [idProducto],
        [descripcion],
        [idUsuario]        
    FROM [Ventas].[Exa_CatalogoProducto]
    ORDER BY [idProducto];
END;
GO

-- Crear Stored Procedure para Obtener registros paginados
CREATE PROCEDURE [Ventas].[sp_ObtenerCatalogoProductosPaginado]
    @Page INT = 1,
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [idProducto],
        [descripcion],
        [idUsuario]
    FROM [Ventas].[Exa_CatalogoProducto]
    ORDER BY [idProducto]
    OFFSET (@Page - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    SELECT COUNT([idProducto]) AS TotalRegistros
    FROM [Ventas].[Exa_CatalogoProducto];
END;
GO