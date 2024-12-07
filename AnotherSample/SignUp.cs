using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnotherSample
{
    public partial class SignUpF2 : Form
    {
        public SignUpF2()
        {
            InitializeComponent();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void EyeOpenButton_Click(object sender, EventArgs e)
        {
            if (PasswordBox.PasswordChar == '*')
            {
                EyeCloseButton.BringToFront();
                PasswordBox.PasswordChar = '\0';
            }
        }

        private void EyeCloseButton_Click(object sender, EventArgs e)
        {
            if (PasswordBox.PasswordChar == '\0')
            {
                EyeOpenButton.BringToFront();
                PasswordBox.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            LoginF1 f1 = new LoginF1();
            f1.ShowDialog();
            f1 = null;
            this.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            // Check if any required field is empty
            if (string.IsNullOrWhiteSpace(UliBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Text) ||
                string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(ContactNumberBox.Text) ||
                string.IsNullOrWhiteSpace(AddressBox.Text) ||
                RoleComboBox.SelectedIndex == -1) // Ensure a role is selected
            {
                MessageBox.Show("Please fill out all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate contact number
            if (!IsValidContactNumber(ContactNumberBox.Text))
            {
                MessageBox.Show("Contact number must be exactly 11 digits.", "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password strength validation
            if (!IsPasswordStrong(PasswordBox.Text))
            {
                MessageBox.Show(
                    "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Ensure a valid role is selected
            int roleId;
            switch (RoleComboBox.Text)
            {
                case "Admin":
                    roleId = 1;
                    break;
                case "Tool Keeper":
                    roleId = 2;
                    break;
                case "Student":
                    roleId = 3;
                    break;
                default:
                    MessageBox.Show("Please select a valid role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // Database connection string and query
            string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";
            string insertQuery = "INSERT INTO users " +
                                 "(role_id, user_uli, user_username, user_password, user_name, user_contact_number, user_address, user_birthday) " +
                                 "VALUES (@RoleId, @UserUli, @Username, @Password, @Name, @ContactNumber, @Address, @Birthday)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@RoleId", roleId);
                        command.Parameters.AddWithValue("@UserUli", UliBox.Text);
                        command.Parameters.AddWithValue("@Username", UsernameBox.Text);
                        command.Parameters.AddWithValue("@Password", PasswordBox.Text);
                        command.Parameters.AddWithValue("@Name", NameBox.Text);
                        command.Parameters.AddWithValue("@ContactNumber", ContactNumberBox.Text);
                        command.Parameters.AddWithValue("@Address", AddressBox.Text);
                        command.Parameters.AddWithValue("@Birthday", BirthdayPicker.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validates if the contact number is exactly 11 digits.
        /// </summary>
        /// <param name="contactNumber">The contact number to validate.</param>
        /// <returns>True if valid; otherwise, false.</returns>
        private bool IsValidContactNumber(string contactNumber)
        {
            // Check if the contact number is 11 digits
            return System.Text.RegularExpressions.Regex.IsMatch(contactNumber, @"^\d{11}$");
        }

        /// <summary>
        /// Validates the strength of a password.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>True if the password is strong; otherwise, false.</returns>
        private bool IsPasswordStrong(string password)
        {
            // Minimum 8 characters
            if (password.Length < 8)
                return false;

            // At least one uppercase letter
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"[A-Z]"))
                return false;

            // At least one lowercase letter
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"[a-z]"))
                return false;

            // At least one digit
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"\d"))
                return false;

            // At least one special character
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"[\W_]"))
                return false;

            return true;
        }



        private void UsernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContactNumberBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BirthdayPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddressBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
