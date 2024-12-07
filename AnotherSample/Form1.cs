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
    public partial class Form1 : Form
    {
        public Form1(string itemName)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the selected condition from comboBox3
            string selectedCondition = comboBox3.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(selectedCondition))
            {
                // Update the item condition in the database
                bool isUpdated = UpdateItemCondition(textBox1.Text, selectedCondition);

                if (isUpdated)
                {
                    // If the update is successful, close the form and return DialogResult.OK
                    this.DialogResult = DialogResult.OK; // Set DialogResult to OK to notify success
                    this.Close(); // Close the overlay form
                }
            }
            else
            {
                MessageBox.Show("Please ensure the item name and condition are valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private bool UpdateItemCondition(string itemName, string newCondition)
        {
            try
            {
                SqlConnection connection = DatabaseConnection.Instance.Connection;

                // SQL query to update the item condition based on item_name
                string query = @"
            UPDATE items
            SET item_condition = @newCondition
            WHERE item_name = @itemName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@itemName", itemName);
                    command.Parameters.AddWithValue("@newCondition", newCondition);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open(); // Open the connection if not already open
                    }

                    int rowsAffected = command.ExecuteNonQuery();

                    // Close the connection
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item condition updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true; // Return true to indicate the update was successful
                    }
                    else
                    {
                        MessageBox.Show("No item was found with that name, or the condition was not updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Return false if no rows were affected
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating item condition: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Return false in case of an error
            }
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
