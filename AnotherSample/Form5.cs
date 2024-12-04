using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherSample
{
    public partial class BorrowedAdminF5 : Form
    {
        public BorrowedAdminF5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HistoriesBt9_Click(object sender, EventArgs e)
        {

        }

        private void LogoutBt11_Click(object sender, EventArgs e)
        {
            Logout();
        }
        private void Logout()
        {
            // Confirm logout action
            var result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Assuming there's a login form named `LoginF1`
                    LoginF1 loginForm = new LoginF1();

                    // Hide the current form
                    this.Hide();

                    // Show the login form and wait for it to close
                    loginForm.ShowDialog();

                    // After the login form is closed, exit the application to ensure all forms are closed
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while logging out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ArchiveBt3_Click(object sender, EventArgs e)
        {
            // Make sure that a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Get the item ID from the selected row
                    int selectedItemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                    // SQL connection string (you should replace this with your actual connection string)
                    string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // SQL query to update the item_is_borrowed column to 0
                        string query = @"
                    UPDATE items
                    SET item_is_borrowed = 0
                    WHERE item_id = @ItemId";

                        // Create a SqlCommand object
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameter to SQL query
                            command.Parameters.AddWithValue("@ItemId", selectedItemId);

                            // Open the connection
                            connection.Open();

                            // Execute the query
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Inform the user that the item was updated
                                MessageBox.Show("Item is now marked as not borrowed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No item found with the selected ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors
                    MessageBox.Show($"Error updating the item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to archive.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
