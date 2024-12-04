using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnotherSample
{
    public partial class LoginF1 : Form
    {
        public LoginF1()
        {
            InitializeComponent();
            LoadRolesToComboBox();
        }

        private bool Login(string username, string password, string role)
        {
            SqlConnection connection = DatabaseConnection.Instance.Connection;
            string query = @"
                SELECT u.user_id, u.user_username, r.role_name
                FROM users u
                JOIN roles r ON u.role_id = r.role_id
                WHERE u.user_username = @username AND u.user_password = @password AND r.role_name = @role";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@role", role);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Save user information in the session
                            UserSession.UserId = Convert.ToInt32(reader["user_id"]);
                            UserSession.Username = reader["user_username"].ToString();
                            UserSession.Role = reader["role_name"].ToString();

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Text.Trim();
            string role = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please select a role.", "Role Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Login(username, password, role))
            {
                MessageBox.Show($"Login successful! Welcome, {role}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                if (role == "Admin")
                {
                    FormNavigator.Navigate(this, new AdminView());
                }
                else if (role == "Student")
                {
                    FormNavigator.Navigate(this, new BorrowerView());
                }

                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid username, password, or role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void EyeOpenButton_Click_1(object sender, EventArgs e)
        {
            if (PasswordBox.PasswordChar == '*')
            {
                EyeCloseButton.BringToFront();
                PasswordBox.PasswordChar = '\0';
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpF2 f2 = new SignUpF2();
            f2.ShowDialog();
            f2 = null;
            this.Show();
        }
        private void LoadRolesToComboBox()
        {
            SqlConnection connection = DatabaseConnection.Instance.Connection;
            string query = "SELECT role_name FROM roles";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        comboBox1.Items.Clear(); // Clear previous items
                        while (reader.Read())
                        {
                            string role = reader["role_name"].ToString();
                            comboBox1.Items.Add(role); // Add role to ComboBox
                        }

                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedIndex = 0; // Select the first item
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void PasswordBox_TextChanged(object sender, EventArgs e) { }

        private void UsernameBox_TextChanged(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
