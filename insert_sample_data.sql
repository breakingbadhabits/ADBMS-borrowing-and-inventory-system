USE inventory_system;

-- Insert sample roles
INSERT INTO roles (role_name) VALUES
('Admin'),
('Tool Keeper'),
('Student');

-- Insert sample users
INSERT INTO users (role_id, user_uli, user_username, user_password, user_name, user_contact_number, user_address, user_birthday) VALUES
(1, 123456789, 'ajoaquin', 'admin_password', 'Angelo Joaquin', '09123456789', '123 Admin St, Comteq', '1999-01-01'),
(2, 987654321, 'aavecilla', 'art_password', 'Arthur Avecilla', '09123456780', '456 Tool Keeper Rd, Comteq', '1999-01-01'),
(3, 135792468, 'jroque', 'jim_password', 'Jimmiel Roque', '09123456781', '789 Student Ln, Comteq', '1999-12-27');

-- Insert sample stocks
INSERT INTO stocks (stock_name, stock_total_quantity, stock_available, stock_under_maintenance, stock_borrowed, stock_archived) VALUES
('Router', 2, 2, 0, 0, 0),
('Crimping Tool', 1, 1, 0, 0, 0),
('RJ45', NULL, 1, 0, 0, 0);

-- Insert sample items
INSERT INTO items (item_stock_id, item_name, item_brand, item_serial_number, item_condition, item_is_borrowed, item_is_archived, item_is_maintenance, item_type) VALUES
(1, 'TP-Link Dual Band Router', 'TP-Link', 'RT0002', 'New', 0, 0, 0, 'equipment'),
(1, 'Cisco Router', 'Cisco', 'RT0001', 'New', 0, 0, 0, 'equipment'),
(2, 'ACE Hardware Crimping Tool', 'ACE Hardware', 'CT0001', 'Used', 0, 0, 0, 'tool'),
(3, 'CAT5 RJ45', 'No Brand', NULL, NULL, 0, 0, 0, 'consumable');

-- Insert sample maintenance records
INSERT INTO maintenance (maintenance_item_id, maintenance_start_date, maintenance_complete_date, maintenance_description) VALUES
(1, '2024-01-01', '2024-02-01', 'Fixed power input'),
(2, '2024-01-01', '2024-02-01', 'Replaced antenna');

-- Insert sample transactions
INSERT INTO transactions (transaction_user_id, transaction_item_id, transaction_borrow_date, transaction_return_date, transaction_due_date, transaction_return_condition) VALUES
(3, 2, '2024-11-20', '2024-11-25', '2024-11-25', 'Good'),
(3, 1, '2024-11-21', '2024-11-23', '2024-11-23', 'Good');

