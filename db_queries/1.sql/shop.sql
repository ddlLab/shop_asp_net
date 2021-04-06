--продавец может быть клиентом и наоборот*
--DROP DATABASE IF EXISTS shop
--GO
CREATE DATABASE shop;
GO
USE shop
GO
DROP TABLE IF EXISTS BuyersHistory
DROP TABLE IF EXISTS Admins
DROP TABLE IF EXISTS Orders
DROP TABLE IF EXISTS Clients
DROP TABLE IF EXISTS Products 
DROP TABLE IF EXISTS Salers 
GO
CREATE TABLE Salers
(
	saler_id			BIGINT IDENTITY(1,1),
	saler_nickname		VARCHAR(50)		NOT NULL,
	saler_email			VARCHAR(100)	NOT NULL,
	saler_password		VARCHAR(100)	NOT NULL,
	saler_phone			VARCHAR(50)		NOT NULL,
	saler_photo			VARCHAR(100)	NOT NULL DEFAULT(''),
	saler_desc			VARCHAR(2048)	NOT NULL DEFAULT(''),
	saler_paycard		VARCHAR(50)		NOT NULL,
	balance				INT				NOT NULL DEFAULT(0),
	is_blocked			BIT				NOT NULL DEFAULT(0),

	CONSTRAINT pk_Salers_saler_id				PRIMARY KEY (saler_id),
	CONSTRAINT uq_Salers_saler_email			UNIQUE (saler_email),
	CONSTRAINT uq_Salers_saler_nickname			UNIQUE (saler_nickname),
	CONSTRAINT uq_Salers_saler_phone			UNIQUE (saler_phone),
	CONSTRAINT uq_Salers_saler_paycard			UNIQUE (saler_paycard)
)
GO

CREATE TABLE Products
(
	product_id			BIGINT IDENTITY(1,1),
	product_name		VARCHAR(100)	NOT NULL DEFAULT(''),
	saler_id			BIGINT			NOT NULL,
	product_desc		VARCHAR(2048)   NOT NULL DEFAULT(''),
	product_photos		VARCHAR(2048)	NOT NULL DEFAULT(''),
	product_price		INT				NOT NULL

	CONSTRAINT pk_Products_product_id	PRIMARY KEY (product_id),
	CONSTRAINT fk_Products_saler_id		FOREIGN KEY (saler_id) REFERENCES Salers(saler_id)
)
GO

CREATE TABLE Clients
(
	client_id			BIGINT IDENTITY(1,1),
	client_email		VARCHAR(100)	NOT NULL,
	client_password		VARCHAR(100)	NOT NULL,
	client_nickname		VARCHAR(50)		NOT NULL,
	client_phone		VARCHAR(50)		NOT NULL,
	client_photo		VARCHAR(100)	NOT NULL DEFAULT(''),
	client_desc			VARCHAR(2048)	NOT NULL DEFAULT(''),
	client_paycard		VARCHAR(50)		NOT NULL,
	balance				INT				NOT NULL DEFAULT(0),
	is_blocked			BIT				NOT NULL DEFAULT(0),

	CONSTRAINT pk_Clients_client_id				PRIMARY KEY (client_id),
	CONSTRAINT uq_Clients_client_nickname		UNIQUE (client_nickname),
	CONSTRAINT uq_Clients_client_email			UNIQUE (client_email),
	CONSTRAINT uq_Clients_client_phone			UNIQUE (client_phone),
	CONSTRAINT uq_Clients_client_paycard		UNIQUE (client_paycard)

)
GO

CREATE TABLE Orders
(
	order_id			BIGINT IDENTITY(1,1),
	client_id			BIGINT			NOT NULL,
	product_id			BIGINT			NOT NULL,
	saler_id			BIGINT			NOT NULL,
	order_desc			VARCHAR(2048)   NOT NULL DEFAULT(''),
	order_photos		VARCHAR(2048)	NOT NULL DEFAULT(''),
	order_price			INT				NOT NULL,
	is_complete			BIT				NOT NULL DEFAULT(0),

	CONSTRAINT pk_Orders_order_id				PRIMARY KEY (order_id),
	CONSTRAINT fk_Orders_client_id				FOREIGN KEY (client_id) REFERENCES Clients(client_id),
	CONSTRAINT fk_Orders_product_id			FOREIGN KEY (product_id) REFERENCES Products(product_id)
)
GO

CREATE TABLE Admins
(
	admin_id			BIGINT IDENTITY(1,1),
	admin_email			VARCHAR(100)	NOT NULL,
	admin_password		VARCHAR(100)	NOT NULL,
	admin_nickname		VARCHAR(50)		NOT NULL,
	is_superadmin		BIT				NOT NULL DEFAULT 0,

	CONSTRAINT pk_Admins_admin_id			PRIMARY KEY (admin_id),
	CONSTRAINT uq_Admins_admin_nickname		UNIQUE (admin_nickname),
	CONSTRAINT uq_Admins_admin_email		UNIQUE (admin_email)
)
GO

CREATE TABLE BuyersHistory
(
	order_id			BIGINT IDENTITY(1,1),
	client_id			BIGINT			NOT NULL,
	product_id			BIGINT			NOT NULL,
	saler_id			BIGINT			NOT NULL,

	CONSTRAINT fk_BuyersHistory_order_id		FOREIGN KEY (order_id)		REFERENCES Orders(order_id),
	CONSTRAINT fk_BuyersHistory_client_id		FOREIGN KEY (client_id)		REFERENCES Clients(client_id),
	CONSTRAINT fk_BuyersHistory_product_id		FOREIGN KEY (product_id)	REFERENCES Products(product_id),
	CONSTRAINT fk_BuyersHistory_saler_id		FOREIGN KEY (saler_id)		REFERENCES Salers(saler_id)
)
