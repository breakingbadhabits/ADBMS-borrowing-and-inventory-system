using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnotherSample
{
    public partial class FixItem : Form
    {
        private int itemId; // Store the item ID for use in this form

        public FixItem(int itemId)
        {
            InitializeComponent();
            this.itemId = itemId; // Assign the itemId
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Close the form without making changes
        }

        private void FixButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Use the provided itemId instead of relying on a DataGridView
                int selectedItemId = this.itemId;

                // Get the current date
                DateTime maintenanceStartDate = DateTime.Now;

                // Get the description from textbox1
                string maintenanceDescription = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(maintenanceDescription))
                {
                    MessageBox.Show("Please provide a description for the maintenance.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Define your connection string (this should come from your configuration)
                string connectionString = ConfigurationManager.ConnectionStrings["InventorySystemDB"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // INSERT query for maintenance table
                    string insertQuery = @"
                INSERT INTO maintenance (maintenance_item_id, maintenance_start_date, maintenance_description)
                VALUES (@ItemId, @StartDate, @Description)";

                    // UPDATE query for items table
                    string updateQuery = @"
                UPDATE items
                SET item_is_maintenance = 1
                WHERE item_id = @ItemId";

                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction()) // Start a transaction
                    {
                        try
                        {
                            // Insert into maintenance table
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@ItemId", selectedItemId);
                                insertCommand.Parameters.AddWithValue("@StartDate", maintenanceStartDate);
                                insertCommand.Parameters.AddWithValue("@Description", maintenanceDescription);
                                insertCommand.ExecuteNonQuery();
                            }

                            // Update item_is_maintenance in items table
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@ItemId", selectedItemId);
                                updateCommand.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();

                            MessageBox.Show("Maintenance record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Close the form and return DialogResult.OK
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of error
                            transaction.Rollback();
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}