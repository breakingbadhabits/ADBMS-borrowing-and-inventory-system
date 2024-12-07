USE inventory_system;

-- Insert sample roles
INSERT INTO roles (role_name) VALUES
('Admin'),
('Tool Keeper'),
('Student');

-- Insert sample users
INSERT INTO users (role_id, user_uli, user_username, user_password, user_name, user_contact_number, user_address, user_birthday) VALUES
(1, 123456789, 'Admin', 'LetMeIn@2024', 'Angelo Joaquin', '09123456789', '123 Admin St, Comteq', '1999-01-01'),
(3, 987654321, 'princet', 'password', 'Prince Talua', '09123456780', '456 Tool Keeper Rd, Comteq', '1999-01-01'),
(3, 135792468, 'jroque', 'jim_password', 'Jimmiel Roque', '09123456781', '789 Student Ln, Comteq', '1999-12-27');

