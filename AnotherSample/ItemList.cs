using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace AnotherSample
{
    public partial class ItemList : Form
    {
        SqlConnection connection = DatabaseConnection.Instance.Connection;

        public ItemList()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                // Validate the input fields before proceeding
                if (!ValidateInput())
                {
                    return; // Exit the function if validation fails
                }

                // Extract information from input fields
                string itemName = textBox1.Text;                  // Item Name
                string brand = textBox2.Text;                     // Brand
                string serialNumber = textBox3.Text;              // Serial Number
                string itemType = comboBox1.SelectedItem.ToString(); // Item Type
                string condition = comboBox3.Text;                // Condition
                string itemStatus = comboBox2.SelectedItem.ToString(); // Item Status

                // Add the item to the database
                bool isSuccess = AddItem(itemName, brand, serialNumber, itemType, condition, itemStatus);

                if (isSuccess)
                {
                    // Show success message
                    MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Close the current form (overlay)
                    this.DialogResult = DialogResult.OK; // Return OK to signal success
                    this.Close(); // Close the overlay form

                    // Clear the form fields for the next entry (if required)
                    ClearFormFields();
                }
            }
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || // ItemName
                string.IsNullOrWhiteSpace(textBox2.Text) || // Brand
                string.IsNullOrWhiteSpace(textBox3.Text) || // SerialNo
                comboBox1.SelectedItem == null ||          // ItemType
                string.IsNullOrWhiteSpace(comboBox3.Text) || // Condition
                comboBox2.SelectedItem == null ||           // ItemStatus
                comboBox3.SelectedItem == null)            // ItemStatus

            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Function to add an item to the database
        private bool AddItem(string itemName, string brand, string serialNumber, string itemType, string condition, string itemStatus)
        {
            try
            {
                string insertQuery = @"
            INSERT INTO items 
            (item_stock_id, item_name, item_brand, item_serial_number, item_type, item_condition, item_is_borrowed, item_is_archived, item_is_maintenance)
            VALUES 
            (@ItemStockId, @ItemName, @Brand, @SerialNumber, @ItemType, @Condition, @ItemIsBorrowed, @ItemIsArchived, @ItemIsMaintenance)";

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["InventorySystemDB"].ConnectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction()) // Start a transaction
                    {
                        try
                        {
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                            {
                                // Retrieve stock ID using stockName
                                string stockName = comboBox2.SelectedItem.ToString();
                                int? stockId = GetStockIdByStockName(stockName);
                                if (stockId == null)
                                {
                                    MessageBox.Show("Invalid stock selected. Please select a valid stock.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                                // Add parameters for the INSERT query
                                insertCommand.Parameters.AddWithValue("@ItemStockId", stockId);
                                insertCommand.Parameters.AddWithValue("@ItemName", itemName);
                                insertCommand.Parameters.AddWithValue("@Brand", brand);
                                insertCommand.Parameters.AddWithValue("@SerialNumber", serialNumber);
                                insertCommand.Parameters.AddWithValue("@ItemType", itemType);
                                insertCommand.Parameters.AddWithValue("@Condition", condition);
                                insertCommand.Parameters.AddWithValue("@ItemIsBorrowed", 0);
                                insertCommand.Parameters.AddWithValue("@ItemIsArchived", 0);
                                insertCommand.Parameters.AddWithValue("@ItemIsMaintenance", 0);

                                // Execute the INSERT command
                                insertCommand.ExecuteNonQuery();

                                // Now that the item is added, update the stock quantity
                                UpdateStockTotalQuantity(stockId.Value, connection, transaction);

                                transaction.Commit(); // Commit the transaction
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Rollback the transaction on error
                            MessageBox.Show($"Error adding item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }




        private int? GetStockIdByStockName(string stockName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["InventorySystemDB"].ConnectionString))
                {
                    string query = "SELECT stock_id FROM stocks WHERE stock_name = @StockName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StockName", stockName);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        // If a result is found, return it; otherwise, return null
                        if (result != DBNull.Value && result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching stock ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null; // Return null if no match or an error occurs
        }




        // Clear input fields after adding an item
        private void ClearFormFields()
        {
            textBox1.Clear(); // ItemName
            textBox2.Clear(); // Brand
            textBox3.Clear(); // SerialNo
            comboBox1.SelectedIndex = -1; // Reset ItemType selection
            comboBox3.SelectedIndex = -1; // Condition
            comboBox2.SelectedIndex = -1; // Reset ItemStatus selection
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private string GenerateItemStockId()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["InventorySystemDB"].ConnectionString))
                {
                    string query = "SELECT MAX(item_stock_id) FROM items";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        // If no IDs exist yet, start from 1 or your preferred starting point
                        int newId = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;

                        return newId.ToString(); // Convert to string if item_stock_id is a string type
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating Item Stock ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void ItemList_Load(object sender, EventArgs e)
        {
            LoadStockNames(); // Load stock names into comboBox2
        }

        private void LoadStockNames()
        {
            try
            {
                SqlConnection connection = DatabaseConnection.Instance.Connection;
                string query = "SELECT stock_name FROM stocks ORDER BY stock_name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> stockNames = new List<string>();

                        // Read each stock_name and add it to the list
                        while (reader.Read())
                        {
                            stockNames.Add(reader["stock_name"].ToString());
                        }

                        // Bind the list of stock names to comboBox2
                        comboBox2.DataSource = stockNames;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock names: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateStockTotalQuantity(int stockId, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                // Query to calculate the total number of items in the stock
                string countQuery = "SELECT COUNT(*) FROM items WHERE item_stock_id = @StockId";

                // Query to update the total quantity in the stocks table
                string updateQuery = "UPDATE stocks SET stock_total_quantity = @TotalQuantity WHERE stock_id = @StockId";

                int totalQuantity = 0;

                // Calculate the total number of items
                using (SqlCommand countCommand = new SqlCommand(countQuery, connection, transaction))
                {
                    countCommand.Parameters.AddWithValue("@StockId", stockId);
                    totalQuantity = Convert.ToInt32(countCommand.ExecuteScalar());
                }

                // Update the stock_total_quantity in the stocks table
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                {
                    updateCommand.Parameters.AddWithValue("@TotalQuantity", totalQuantity);
                    updateCommand.Parameters.AddWithValue("@StockId", stockId);
                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating stock total quantity: {ex.Message}");
            }
        }
    }
}
