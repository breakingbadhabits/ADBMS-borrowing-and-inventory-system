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
    public partial class ItemBorrow : Form
    {
        public ItemBorrow(string itemName)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(itemName))
            {
                textBox1.Text = itemName; // Display the selected item name
            }
            else
            {
                textBox1.Text = "No selected item"; // Default message
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }   

        private void ItemBorrow_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate if an item is selected
            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text == "No selected item")
            {
                MessageBox.Show("Please select a valid item to borrow.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate if the selected due date is greater than the current date
            if (dateTimePicker1.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Please choose a due date greater than the current date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Establish connection
                SqlConnection connection = DatabaseConnection.Instance.Connection;

                // Define query
                string query = @"
                    INSERT INTO transactions (transaction_item_id, transaction_due_date, transaction_user_id)
                    VALUES (@itemId, @dueDate, @userId);
                ";

                // Get necessary data
                int itemId = GetSelectedItemId(textBox1.Text); // Replace with your method to fetch item ID by name
                DateTime dueDate = dateTimePicker1.Value.Date;
                int userId = UserSession.UserId; // Get the user_id of the logged-in user from UserSession

                // Execute query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@itemId", itemId);
                    command.Parameters.AddWithValue("@dueDate", dueDate);
                    command.Parameters.AddWithValue("@userId", userId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Borrow request successfully recorded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Close the popup
                    }
                    else
                    {
                        MessageBox.Show("Failed to record the borrow request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedItemId(string itemName)
        {
            int itemId = -1; // Default value for invalid item ID
            try
            {
                SqlConnection connection = DatabaseConnection.Instance.Connection;
                string query = "SELECT item_id FROM items WHERE item_name = @itemName";

                // Use a "using" block to ensure proper disposal of resources
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@itemName", itemName);

                    if (connection.State != ConnectionState.Open) // Check if the connection is closed
                    {
                        connection.Open();
                    }

                    object result = command.ExecuteScalar();

                    if (connection.State == ConnectionState.Open) // Ensure connection is closed afterward
                    {
                        connection.Close();
                    }

                    if (result != null)
                    {
                        itemId = Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("Item not found in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching item ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return itemId;
        }

        public static class LoggedInUser
        {
            public static int user_id { get; set; }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
