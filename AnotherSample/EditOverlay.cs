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
    public partial class EditOverlay : Form
    {
        private string itemName; // Field to store the passed item name

        public EditOverlay(string selectedItemName)
        {
            InitializeComponent();
            itemName = selectedItemName; // Store the passed item name
        }

        private void EditOverlay_Load(object sender, EventArgs e)
        {
            // Display the item name in textBox1
            textBox1.Text = itemName;
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

      

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the textBox1 has a value and comboBox3 has a selection
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("No item selected to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBox3.SelectedItem == null)
                {
                    MessageBox.Show("Please select a valid condition from the dropdown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedItemName = textBox1.Text;
                string selectedCondition = comboBox3.SelectedItem.ToString();

                UpdateItemConditionInDatabase(selectedItemName, selectedCondition);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateItemConditionInDatabase(string itemName, string condition)
        {
            try
            {
                SqlConnection connection = DatabaseConnection.Instance.Connection;

                string query = "UPDATE items SET item_condition = @condition WHERE item_name = @itemName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@condition", condition);
                    command.Parameters.AddWithValue("@itemName", itemName);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item condition updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Close the form automatically upon success
                    }
                    else
                    {
                        MessageBox.Show("No matching item found or no changes made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the item condition: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
