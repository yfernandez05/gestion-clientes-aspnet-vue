create database CRUD;
GO

use CRUD;
GO

create table Cliente(
id int IDENTITY(1,1) primary key,
nombre varchar(50) NOT NULL,
apellidos varchar(50) NULL,
edad char(2) NULL,
correo varchar(50) NULL,
telefono char(9) NULL,
estado char(1) NOT NULL DEFAULT 'A',
created_at datetime2 NOT NULL DEFAULT GETDATE(),
);
GO

SELECT * FROM Cliente where estado = 'A';
GO

INSERT INTO [dbo].[Cliente]
           ([nombre]
           ,[apellidos]
           ,[edad]
           ,[correo]
           ,[telefono])
     VALUES
           ('YHONATAN'
           ,'FERNADEZ CARDENAS'
           ,'23'
           ,'YHONATAN@GMAIL.COM'
           ,'987987987')
GO


/*SP*/
IF OBJECT_ID('dbo.ShowClienteID', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.ShowClienteID;
END;
GO
CREATE PROCEDURE ShowClienteID
    @id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Cliente WHERE id = @id;
END;
GO

execute ShowClienteID @id= 1;
go


IF OBJECT_ID('dbo.SaveCliente', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.SaveCliente;
END;
GO
CREATE PROCEDURE SaveCliente
    @nombre NVARCHAR(50),
    @apellidos NVARCHAR(100),
    @edad INT,
    @correo NVARCHAR(100),
    @telefono NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Cliente (nombre, apellidos, edad, correo, telefono)
    VALUES (@nombre, @apellidos, @edad, @correo, @telefono);
END;


/*execute SaveCliente 
@nombre = 'Juan', 
@apellidos = 'Mendoza flore',
@edad = '20',
@correo = 'mendoza@gmail.com',
@telefono = '987987987';*/


IF OBJECT_ID('dbo.UpdateCliente', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.UpdateCliente;
END;
GO
CREATE PROCEDURE UpdateCliente
	@id INT,
    @nombre NVARCHAR(50),
    @apellidos NVARCHAR(100),
    @edad CHAR(2),
    @correo NVARCHAR(100),
    @telefono NVARCHAR(20),
	@estado CHAR(1)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Cliente SET nombre = @nombre, apellidos = @apellidos, edad= @edad, correo = @correo, telefono = @telefono WHERE id = @id;
END;

/*execute UpdateCliente 
@nombre = 'modifcado', 
@apellidos = 'editado', 
@edad = '20',
@correo = 'correoeditado@gmail.com',
@telefono = '987987987',
@estado = 'A',
@id = 3;*/



IF OBJECT_ID('dbo.DeleteCliente', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.DeleteCliente;
END;
GO
CREATE PROCEDURE DeleteCliente
	@id INT,
	@estado CHAR(1)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Cliente SET estado = @estado WHERE id = @id;
END;


SELECT * FROM Cliente;

/*aditional*/

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Cliente';


ALTER TABLE Cliente
ALTER COLUMN estado char(1) NOT NULL;

ALTER TABLE Cliente
ADD CONSTRAINT DF_Cliente_estado DEFAULT 'A' FOR estado;

SELECT * FROM Cliente WHERE estado = 'A' AND (edad LIKE '20' and nombre LIKE '%Juan%');
SELECT * FROM Cliente WHERE estado = 'A' AND (estado LIKE '%E%')
SELECT * FROM Cliente AND (estado LIKE '%E%')