USE OnlineRetailStore;

INSERT INTO Customers
	(FullName, PhoneNumber, Email, ShippingAddress, RegistrationDate)
VALUES
	(N'Youssef Mohamed', N'01012345678', N'youssef@gmail.com', N'Zagazig, Sharqia', GETDATE());


INSERT INTO Suppliers
    (Name, Country, Email, Address, ContactNumber)
VALUES
    (N'ABC Electronics', N'Egypt', N'abd@gmail.com', N'Cairo', N'01011111111'),
    (N'Tech World', N'Egypt', N'techworld@gmail.com', N'Giza', N'01022222222'),
    (N'Global Supplies', N'China', N'global@gmail.com', N'Shanghai', N'01033333333');


INSERT INTO Categories
    (Name, Description, MainCategory)
VALUES
    (N'Electronics', N'Electronic devices and accessories', NULL),
    (N'Computers', N'Computers and computer accessories', 1);


INSERT INTO Products
    (Name, UnitPrice)
VALUES
    (N'Wireless Mouse', 350.00);


CREATE TABLE ArchivedStock
(
    TranId           INT,
    ProductId        INT,
    QuantityChange   INT,
    TranDate         DATETIME2(0)

);


INSERT INTO ArchivedStock
    (TranId, ProductId, QuantityChange, TranDate)
SELECT
    TranId,
    ProductId,
    QuantityChange,
    TranDate
FROM StockTransactions
WHERE TranDate < '2023-01-01';


UPDATE Products
SET UnitPrice = UnitPrice * 1.10
WHERE UnitPrice < 100


UPDATE Orders
SET Status =
    CASE 
        WHEN TotalAmount > 5000 THEN N'Premium'
            ELSE N'Standard'
    END;

SELECT  * FROM Customers

SELECT  * FROM Suppliers

SELECT  * FROM Categories

SELECT  * FROM Products

SELECT  * FROM ArchivedStock


