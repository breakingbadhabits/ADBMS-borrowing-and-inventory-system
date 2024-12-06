USE inventory_system;

CREATE TABLE roles (
	role_id INT PRIMARY KEY IDENTITY(1,1),
	role_name varchar(25)
);

CREATE TABLE users (
	user_id INT PRIMARY KEY IDENTITY(1,1),
	role_id INT NOT NULL,
	user_uli INT UNIQUE NOT NULL,
	user_username varchar(50) UNIQUE NOT NULL,
	user_password varchar(50) NOT NULL,
	user_name varchar(50) NOT NULL,
	user_contact_number varchar(11),
	user_address varchar(200),
	user_birthday DATE,
	CONSTRAINT FK_user_role_id_role_id FOREIGN KEY (role_id)
        REFERENCES roles(role_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE stocks (
	stock_id INT PRIMARY KEY IDENTITY(1,1),
	stock_name varchar(50) NOT NULL,
	stock_total_quantity INT,
	stock_available INT NOT NULL,
	stock_under_maintenance INT NOT NULL,
	stock_borrowed INT NOT NULL,
	stock_archived INT NOT NULL
);

CREATE TABLE items (
	item_id INT PRIMARY KEY IDENTITY(1,1),
	item_stock_id INT NOT NULL,
	item_name varchar(50) NOT NULL,
	item_brand varchar(50),
	item_serial_number varchar(50),
	item_condition varchar(50),
	item_is_borrowed BIT,
	item_is_archived BIT,
	item_is_maintenance BIT,
	item_type VARCHAR(50) NOT NULL,
	CONSTRAINT FK_item_stock_id_stock_id FOREIGN KEY (item_stock_id)
        REFERENCES stocks(stock_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE maintenance (
	maintenance_id INT PRIMARY KEY IDENTITY(1,1),
	maintenance_item_id INT NOT NULL,
	maintenance_start_date DATE NOT NULL,
	maintenance_complete_date DATE,
	maintenance_description VARCHAR(100),
	CONSTRAINT FK_maintenance_item_id_item_id FOREIGN KEY (maintenance_item_id)
        REFERENCES items(item_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE transactions (
	transaction_id INT PRIMARY KEY IDENTITY(1,1),
	transaction_user_id INT NOT NULL,
	transaction_item_id INT NOT NULL,
	transaction_borrow_date DATE NOT NULL,
	transaction_return_date DATE,
	transaction_due_date DATE,
	transaction_return_condition VARCHAR(200),
	CONSTRAINT FK_transaction_user_id_user_id FOREIGN KEY (transaction_user_id)
        REFERENCES users(user_id)
	ON DELETE CASCADE
    ON UPDATE CASCADE,
	CONSTRAINT FK_transaction_item_id_item_id FOREIGN KEY (transaction_item_id)
        REFERENCES items(item_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

