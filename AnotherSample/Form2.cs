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
            string connectionString = "your_connection_string_here";
            string query = "SELECT RoleName FROM roles";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["RoleName"].ToString());
                            }
                        }
                    }
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
    }
}
