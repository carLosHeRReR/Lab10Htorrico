PROCEDIMIENTOS ALMACENADOS
--------------------------

USE [FacturaDB]
GO
/****** Object:  StoredProcedure [dbo].[ListarClientes]    Script Date: 22/10/2023 15:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[ListarClientes] AS BEGIN
SELECT customer_id, 
        name, 
        address, 
        phone, 
        active
    FROM customers
	WHERE active = 1;
	END

--------------------------------------------------------------------------------------

USE [FacturaDB]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCliente]    Script Date: 22/10/2023 15:37:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertarCliente]
    @name NVARCHAR(255),
    @address NVARCHAR(255),
    @phone NVARCHAR(50),
    @active BIT
AS
BEGIN
    INSERT INTO customers (name, address, phone, active)
    VALUES  (@name, @address, @phone, @active);
END

----------------------------------------------------------------------------------------

USE [FacturaDB]
GO
/****** Object:  StoredProcedure [dbo].[ModificarCliente]    Script Date: 22/10/2023 15:37:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ModificarCliente]
    @customer_id INT,
    @name NVARCHAR(255) = NULL, 
    @address NVARCHAR(255) = NULL,
    @phone NVARCHAR(50) = NULL,
    @active BIT = NULL
AS
BEGIN
    UPDATE customers
    SET 
        name = ISNULL(@name, name),
        address = ISNULL(@address, address),
        phone = ISNULL(@phone, phone),
        active = ISNULL(@active, active)
    WHERE customer_id = @customer_id;
END

----------------------------------------------------------------------------------------

USE [FacturaDB]
GO
/****** Object:  StoredProcedure [dbo].[EliminarClienteLogicamente]    Script Date: 22/10/2023 15:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[EliminarClienteLogicamente]
    @customer_id INT
AS
BEGIN
    UPDATE customers
    SET 
        active = 0
    WHERE customer_id = @customer_id;
END