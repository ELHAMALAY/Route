	CREATE DATABASE OnlineRetailStore;

	USE OnlineRetailStore

	CREATE TABLE Categories
	(
		CategoryID		INT   IDENTITY(1,1)   NOT NULL,
		Name			NVARCHAR(100)		  NOT NULL,
		Description		NVARCHAR(500)		  NOT NULL,
		MainCategory	INT					  NULL,

		CONSTRAINT PK_Categories			PRIMARY KEY (CategoryID),
		CONSTRAINT UQ_Categories_Name		UNIQUE		(Name),
		CONSTRAINT FK_Categories_MainCat	FOREIGN KEY (MainCategory)
			REFERENCES Categories (CategoryID)
			ON DELETE NO ACTION ON UPDATE NO ACTION,
		CONSTRAINT CK_Categories_NotSelf    CHECK		(MainCategory <> CategoryId)
	);


	CREATE TABLE Suppliers
	(
		SupplierId     INT   IDENTITY(1,1)   NOT NULL,
		Name           NVARCHAR(120)	     NOT NULL,
		Country        NVARCHAR(60)		     NULL,
		Email          NVARCHAR(120)	     NULL,
		Address        NVARCHAR(250)	     NULL,
		ContactNumber  NVARCHAR(20)		     NULL,	

		CONSTRAINT PK_Suppliers          PRIMARY KEY (SupplierId),
		CONSTRAINT UQ_Suppliers_Email    UNIQUE      (Email),
		CONSTRAINT CK_Suppliers_Email    CHECK       (Email IS NULL OR Email LIKE '%_@_%._%')
	);


	CREATE TABLE Products
	(
		ProductId      INT   IDENTITY(1,1)   NOT NULL,
		Name           NVARCHAR(150)	     NOT NULL,
		Description    NVARCHAR(1000)	     NULL,
		UnitPrice      DECIMAL(10,2)	     NOT NULL,
		StockQuantity  INT				     NOT NULL CONSTRAINT DF_Products_Stock DEFAULT (0),
		AddedDate      DATE				     NOT NULL CONSTRAINT DF_Products_Added DEFAULT (CAST(GETDATE() AS DATE)),
		CategoryId     INT				     NOT NULL,

		CONSTRAINT PK_Products              PRIMARY KEY (ProductId),
		CONSTRAINT FK_Products_Categories   FOREIGN KEY (CategoryId)
			REFERENCES Categories (CategoryId)
			ON DELETE NO ACTION ON UPDATE NO ACTION,
		CONSTRAINT CK_Products_UnitPrice    CHECK       (UnitPrice >= 0),
		CONSTRAINT CK_Products_Stock        CHECK       (StockQuantity >= 0)
	);


	CREATE TABLE Products_Suppliers
	(
		SupplierId  INT   NOT NULL,
		ProductId   INT   NOT NULL,
 
		CONSTRAINT PK_Products_Suppliers            PRIMARY KEY   (SupplierId, ProductId),
		CONSTRAINT FK_ProdSupp_Suppliers            FOREIGN KEY   (SupplierId)
			REFERENCES Suppliers (SupplierId) ON DELETE CASCADE,
		CONSTRAINT FK_ProdSupp_Products             FOREIGN KEY   (ProductId)
			REFERENCES Products (ProductId)  ON DELETE CASCADE
	);


	CREATE TABLE StockTransactions
	(
		TranId          INT           IDENTITY(1,1) NOT NULL,
		TranDate        DATETIME2(0)   NOT NULL CONSTRAINT DF_Stock_TranDate DEFAULT (SYSDATETIME()),
		QuantityChange  INT            NOT NULL,
		Type            NVARCHAR(20)   NOT NULL,
		Reference       NVARCHAR(50)   NULL,
		ProductId       INT            NOT NULL,
 
		CONSTRAINT PK_StockTransactions         PRIMARY KEY (TranId),
		CONSTRAINT FK_StockTrans_Products       FOREIGN KEY (ProductId)
			REFERENCES Products (ProductId) ON DELETE CASCADE,
		CONSTRAINT CK_StockTrans_Qty            CHECK (QuantityChange <> 0),
		CONSTRAINT CK_StockTrans_Type           CHECK (Type IN
			(N'Purchase', N'Sale', N'Return', N'Adjustment', N'Damaged'))
	);


	CREATE TABLE Customers
	(
		CustomerId        INT            IDENTITY(1,1) NOT NULL,
		FullName          NVARCHAR(120)  NOT NULL,
		PhoneNumber       NVARCHAR(20)   NULL,
		Email             NVARCHAR(120)  NOT NULL,
		ShippingAddress   NVARCHAR(250)  NULL,
		RegistrationDate  DATE           NOT NULL CONSTRAINT DF_Customers_RegDate DEFAULT (CAST(GETDATE() AS DATE)),
 
		CONSTRAINT PK_Customers         PRIMARY KEY (CustomerId),
		CONSTRAINT UQ_Customers_Email   UNIQUE (Email),
		CONSTRAINT CK_Customers_Email   CHECK (Email LIKE '%_@_%._%')
	);


	CREATE TABLE Orders
	(
		OrderId      INT            IDENTITY(1,1) NOT NULL,
		OrderDate    DATETIME2(0)   NOT NULL CONSTRAINT DF_Orders_Date   DEFAULT (SYSDATETIME()),
		Status       NVARCHAR(20)   NOT NULL CONSTRAINT DF_Orders_Status DEFAULT (N'Pending'),
		TotalAmount  DECIMAL(12,2)  NOT NULL CONSTRAINT DF_Orders_Total  DEFAULT (0),
		CustomerId   INT            NOT NULL,
 
		CONSTRAINT PK_Orders             PRIMARY KEY (OrderId),
		CONSTRAINT FK_Orders_Customers   FOREIGN KEY (CustomerId)
			REFERENCES Customers (CustomerId) ON DELETE CASCADE,
		CONSTRAINT CK_Orders_Total       CHECK (TotalAmount >= 0),
		CONSTRAINT CK_Orders_Status      CHECK (Status IN
			(N'Pending', N'Paid', N'Shipped', N'Delivered', N'Cancelled', N'Returned'))
	);


	CREATE TABLE OrderItems
	(
		OrderItemId  INT            IDENTITY(1,1) NOT NULL,
		Quantity     INT            NOT NULL,
		UnitPrice    DECIMAL(10,2)  NOT NULL,
		ProductId    INT            NOT NULL,
		OrderId      INT            NOT NULL,
		LineTotal    AS (Quantity * UnitPrice) PERSISTED,
 
		CONSTRAINT PK_OrderItems            PRIMARY KEY (OrderItemId),
		CONSTRAINT UQ_OrderItems_OrderProd  UNIQUE (OrderId, ProductId),
		CONSTRAINT FK_OrderItems_Orders     FOREIGN KEY (OrderId)
			REFERENCES Orders (OrderId)     ON DELETE CASCADE,
		CONSTRAINT FK_OrderItems_Products   FOREIGN KEY (ProductId)
			REFERENCES Products (ProductId) ON DELETE NO ACTION,   -- keep sales history
		CONSTRAINT CK_OrderItems_Qty        CHECK (Quantity > 0),
		CONSTRAINT CK_OrderItems_Price      CHECK (UnitPrice >= 0)
	);


	CREATE TABLE Payments
	(
		PaymentId    INT            IDENTITY(1,1) NOT NULL,
		PaymentDate  DATETIME2(0)   NOT NULL CONSTRAINT DF_Payments_Date DEFAULT (SYSDATETIME()),
		Amount       DECIMAL(12,2)  NOT NULL,
		Status       NVARCHAR(20)   NOT NULL CONSTRAINT DF_Payments_Status DEFAULT (N'Pending'),
		Method       NVARCHAR(20)   NOT NULL,
 
		CONSTRAINT PK_Payments        PRIMARY KEY (PaymentId),
		CONSTRAINT CK_Payments_Amount CHECK (Amount > 0),
		CONSTRAINT CK_Payments_Status CHECK (Status IN
			(N'Pending', N'Completed', N'Failed', N'Refunded')),
		CONSTRAINT CK_Payments_Method CHECK (Method IN
			(N'CreditCard', N'DebitCard', N'PayPal', N'BankTransfer', N'CashOnDelivery'))
	);


	CREATE TABLE Orders_Payments
	(
		OrderId    INT NOT NULL,
		PaymentId  INT NOT NULL,
 
		CONSTRAINT PK_Orders_Payments       PRIMARY KEY (OrderId, PaymentId),
		CONSTRAINT FK_OrdPay_Orders         FOREIGN KEY (OrderId)
			REFERENCES Orders (OrderId)     ON DELETE CASCADE,
		CONSTRAINT FK_OrdPay_Payments       FOREIGN KEY (PaymentId)
			REFERENCES Payments (PaymentId) ON DELETE CASCADE
	);


	CREATE TABLE Shipments
	(
		ShipmentId      INT           IDENTITY(1,1) NOT NULL,
		ShipmentDate    DATE          NULL,
		Status          NVARCHAR(20)  NOT NULL CONSTRAINT DF_Shipments_Status DEFAULT (N'Preparing'),
		DeliveryDate    DATE          NULL,
		CarrierName     NVARCHAR(80)  NULL,
		TrackingNumber  NVARCHAR(60)  NULL,
		OrderId         INT           NOT NULL,
 
		CONSTRAINT PK_Shipments            PRIMARY KEY (ShipmentId),
		CONSTRAINT UQ_Shipments_Tracking   UNIQUE (TrackingNumber),
		CONSTRAINT FK_Shipments_Orders     FOREIGN KEY (OrderId)
			REFERENCES Orders (OrderId) ON DELETE CASCADE,
		CONSTRAINT CK_Shipments_Status     CHECK (Status IN
			(N'Preparing', N'InTransit', N'Delivered', N'Failed', N'Returned')),
		CONSTRAINT CK_Shipments_Dates      CHECK (DeliveryDate IS NULL
											   OR ShipmentDate IS NULL
											   OR DeliveryDate >= ShipmentDate)
	);


	CREATE TABLE Reviews
	(
		ReviewId    INT           IDENTITY(1,1)   NOT NULL,
		Rating      TINYINT                       NOT NULL,
		Date        DATE                          NOT NULL CONSTRAINT DF_Reviews_Date DEFAULT (CAST(GETDATE() AS DATE)),
		Comment     NVARCHAR(1000)                NULL,
		ProductId   INT                           NOT NULL,
		CustomerId  INT                           NOT NULL,
 
		CONSTRAINT PK_Reviews              PRIMARY KEY (ReviewId),
		CONSTRAINT UQ_Reviews_ProdCust     UNIQUE (ProductId, CustomerId),  -- one review per customer per product
		CONSTRAINT FK_Reviews_Products     FOREIGN KEY (ProductId)
			REFERENCES Products (ProductId)   ON DELETE CASCADE,
		CONSTRAINT FK_Reviews_Customers    FOREIGN KEY (CustomerId)
			REFERENCES Customers (CustomerId) ON DELETE CASCADE,
		CONSTRAINT CK_Reviews_Rating       CHECK (Rating BETWEEN 1 AND 5)
	);