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
                    string query = @"
                INSERT INTO maintenance (maintenance_item_id, maintenance_start_date, maintenance_description)
                VALUES (@ItemId, @StartDate, @Description)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@ItemId", selectedItemId);
                        command.Parameters.AddWithValue("@StartDate", maintenanceStartDate);
                        command.Parameters.AddWithValue("@Description", maintenanceDescription);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Maintenance record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Close the form and return DialogResult.OK
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add maintenance record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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