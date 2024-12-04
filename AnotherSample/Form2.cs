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
            LoadRoles();
        }

        private void LoadRoles()
        {
            string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";
            string query = "SELECT role_name FROM roles";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            RoleComboBox.Items.Clear();
                            while (reader.Read())
                            {
                                RoleComboBox.Items.Add(reader["role_name"].ToString());
                            }

                            if (RoleComboBox.Items.Count > 0)
                            {
                                RoleComboBox.SelectedIndex = 0;
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message);
            }
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
                    MessageBox.Show("Please select a valid role.");
                    return;
            }

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
                            MessageBox.Show("User added successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add user.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting user: " + ex.Message);
            }
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
    }
}
