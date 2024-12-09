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
                int selectedItemId = this.itemId;
                DateTime maintenanceStartDate = DateTime.Now;
                string maintenanceDescription = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(maintenanceDescription))
                {
                    MessageBox.Show("Please provide a description for the maintenance.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["InventorySystemDB"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string insertQuery = @"
                INSERT INTO maintenance (maintenance_item_id, maintenance_start_date, maintenance_description)
                VALUES (@ItemId, @StartDate, @Description)";

                    string updateQuery = @"
                UPDATE items
                SET item_is_maintenance = 1
                WHERE item_id = @ItemId";

                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@ItemId", selectedItemId);
                                insertCommand.Parameters.AddWithValue("@StartDate", maintenanceStartDate);
                                insertCommand.Parameters.AddWithValue("@Description", maintenanceDescription);
                                insertCommand.ExecuteNonQuery();
                            }

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@ItemId", selectedItemId);
                                int rowsAffected = updateCommand.ExecuteNonQuery();
                                MessageBox.Show($"Rows affected by update: {rowsAffected}");
                            }

                            transaction.Commit();
                            MessageBox.Show("Transaction committed and maintenance record saved successfully.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}