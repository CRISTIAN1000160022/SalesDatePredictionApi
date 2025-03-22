CREATE VIEW [Sales].[GetSalesDatePrediction]
AS

	--Common Table Expression Cte
	WITH OrderDifferences AS (
    SELECT
        c.companyname AS CustomerName,
        o.orderdate AS LastOrderDate,
        DATEDIFF(DAY, LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate), o.orderdate) AS DaysBetweenOrders -- Obtiene la diferencia en días entre la orden actual y la anterior usando LAG()
    FROM [Sales].[Orders] o
    INNER JOIN [Sales].[Customers] c ON o.custid = c.custid
	)
	SELECT
		CustomerName,
		MAX(LastOrderDate) AS LastOrderDate, -- Obtiene la última fecha de orden registrada por el cliente
		DATEADD(DAY, AVG(DaysBetweenOrders), MAX(LastOrderDate)) AS NextPredictedOrder --Calcula la fecha de la próxima orden sumando el promedio de días al último pedido
	FROM OrderDifferences
	WHERE DaysBetweenOrders IS NOT NULL -- Filtra clientes con más de una orden (para evitar valores nulos en el cálculo)
	GROUP BY CustomerName;
GO
-- Procedimiento almacenado para obtener las órdenes de un cliente específico
CREATE PROCEDURE [Sales].[GetClientOrders] --EXEC Sales.GetClientOrders @CustomerId = 1;
    @CustomerId INT
AS
BEGIN
    -- Maneja posibles errores
    SET NOCOUNT ON;

    -- Verifica que el CustomerId no sea nulo ni inválido
    IF @CustomerId IS NULL OR @CustomerId <= 0
    BEGIN
        PRINT 'El CustomerId proporcionado no es válido.';
        RETURN;
    END;

    -- Consulta las órdenes del cliente
    SELECT 
        orderid,         -- ID de la orden
        requireddate,    -- Fecha requerida para el pedido
        shippeddate,     -- Fecha de envío del pedido
        shipname,        -- Nombre del destinatario
        shipaddress,     -- Dirección de envío
        shipcity         -- Ciudad de envío
    FROM Sales.Orders
    WHERE custid = @CustomerId;
END;
GO
--  Vista para obtener la lista de empleados con su ID y nombre completo
CREATE VIEW [HR].[GetEmployees] AS
SELECT 
    empid AS Empid,  -- ID del empleado
    CONCAT(firstname, ' ', lastname) AS FullName  -- Nombre completo concatenado
FROM HR.Employees;
GO

CREATE VIEW [Sales].[GetShippers] AS
SELECT 
    shipperid AS Shipperid,  -- ID de la transportadora
    companyname AS Companyname  -- Nombre completo concatenado
FROM Sales.Shippers ;
GO


CREATE VIEW [Production].[GetProducts] AS
SELECT 
    productid AS Productid,  -- ID del producto
    productname AS Productname  -- Nombre producto
FROM Production.Products;
GO

CREATE PROCEDURE [Sales].[AddNewOrder]
(
    @Empid INT,
    @Shipid INT,
    @Shipname NVARCHAR(40),
    @Shipaddress NVARCHAR(60),
    @Shipcity NVARCHAR(15),
    @Orderdate DATETIME,
    @Requireddate DATETIME,
    @Shippeddate DATETIME,
    @Freight DECIMAL(18,2),
    @Shipcountry NVARCHAR(15),
    @Productid INT,
    @Unitprice DECIMAL(18,2),
    @Qty INT,
    @Discount FLOAT
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewOrderId INT;

    -- Insertar la orden en Orders
    INSERT INTO Sales.Orders (empid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry)
    VALUES (@Empid, @Shipid, @Shipname, @Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry);

    -- Obtener el ID de la orden recién creada
    SET @NewOrderId = SCOPE_IDENTITY();

    -- Insertar los detalles en OrderDetails
    INSERT INTO Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
    VALUES (@NewOrderId, @Productid, @Unitprice, @Qty, @Discount);
END;
GO


