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
    public partial class MaintenanceAdminF6 : Form
    {

        public MaintenanceAdminF6()
        {
            InitializeComponent();

            // Initialize the connection string before any method calls that depend on it
            connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";

            // Load maintenance items
            LoadMaintenanceItems();
        }

        private string connectionString;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StockBt5_Click(object sender, EventArgs e)
        {
            {
                // Create an instance of the stock form
                StocksAdminF8 stockForm = new StocksAdminF8();

                // Hide the current form
                this.Hide();

                // Show the stock form as a modal dialog
                stockForm.ShowDialog();

                // Show the current form again when returning from the stock form
                this.Close();
            }
        }

        private void ItemBt4_Click(object sender, EventArgs e)
        {
            {
                // Create an instance of the stock form
                AdminView itemsAdmin = new AdminView();

                // Hide the current form
                this.Hide();

                // Show the stock form as a modal dialog
                itemsAdmin.ShowDialog();

                // Show the current form again when returning from the stock form
                this.Close();
            }
        }

        private void HistoriesBt9_Click(object sender, EventArgs e)
        {
            {
                // Create an instance of the stock form
                HistoryAdminF7 historyForm = new HistoryAdminF7();

                // Hide the current form
                this.Hide();

                // Show the stock form as a modal dialog
                historyForm.ShowDialog();

                // Show the current form again when returning from the stock form
                this.Close();
            }
        }

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            MaintenanceAdminF6 maintenanceAdminF6 = new MaintenanceAdminF6();
            this.Hide();
            maintenanceAdminF6.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadMaintenanceItems()
        {
            // Connection string (already stored in the class variable)
            string query = @"
    SELECT 
        i.item_id AS 'ID', 
        i.item_name AS 'ItemName', 
        i.item_serial_number AS 'SerialNumber',
        m.maintenance_description AS 'Description', 
        m.maintenance_start_date AS 'StartDate',
        m.maintenance_complete_date AS 'EndDate'
    FROM items i
    INNER JOIN maintenance m ON i.item_id = m.maintenance_item_id
    WHERE 
        i.item_is_archived = 0 
        AND i.item_is_maintenance = 1
        AND m.maintenance_complete_date IS NULL"; // Add this condition

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable maintenanceTable = new DataTable();
                    adapter.Fill(maintenanceTable);
                    dataGridView1.DataSource = maintenanceTable;

                    // Adjust columns to fit the DataGridView
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Hide the ID column
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["EndDate"].Visible = false;


                    // Format the StartDate and EndDate columns
                    dataGridView1.Columns["StartDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dataGridView1.Columns["EndDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading maintenance data: {ex.Message}");
            }
        }



        private void FixedButton_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row's ID
                int selectedItemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // SQL query to update the item_is_maintenance and set maintenance_complete_date
                string query = @"
            UPDATE items 
            SET item_is_maintenance = 0 
            WHERE item_id = @ItemId;

            UPDATE maintenance
            SET maintenance_complete_date = GETDATE()
            WHERE maintenance_item_id = @ItemId;";

                try
                {
                    // Create a connection to the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Create a SQL command
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add the parameter to the query
                            command.Parameters.AddWithValue("@ItemId", selectedItemId);

                            // Open the connection
                            connection.Open();

                            // Execute the query
                            int rowsAffected = command.ExecuteNonQuery();

                            // Notify the user
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Item has been successfully updated!");

                                // Reload the DataGridView to reflect changes
                                LoadMaintenanceItems();
                            }
                            else
                            {
                                MessageBox.Show("No rows were updated. Please try again.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the process
                    MessageBox.Show($"Error updating item: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }


        private void ArchiveBt3_Click(object sender, EventArgs e)
        {
            ArchiveSelectedItem();
        }
        private void ArchiveSelectedItem()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int selectedItemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = @"
                    UPDATE items
                    SET 
                        item_is_archived = 1, 
                        item_is_maintenance = 1, 
                        item_is_borrowed = 0
                    WHERE item_id = @ItemId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ItemId", selectedItemId);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Item archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadMaintenanceItems();
                            }
                            else
                            {
                                MessageBox.Show("No item was archived. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error archiving item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to archive.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Pigilan ang default behavior ng Enter key
                e.SuppressKeyPress = true; // Pigilan ang beep sound

                SearchItems(textBox1.Text.Trim());
            }
        }

        private void SearchItems(string searchText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
    SELECT 
        i.item_id AS 'ID', 
        i.item_name AS 'ItemName', 
        i.item_brand AS 'Brand', 
        i.item_serial_number AS 'SerialNumber', 
        i.item_type AS 'ItemType', 
        i.item_condition AS 'Condition', 
        CASE 
            WHEN i.item_is_borrowed = 1 OR i.item_is_maintenance = 1 THEN 'Unavailable' 
            ELSE 'Available' 
        END AS 'ItemStatus'
    FROM items i
    INNER JOIN stocks s ON i.item_stock_id = s.stock_id
    WHERE 
        i.item_is_archived = 0
        AND i.item_is_borrowed = 0   -- Exclude unavailable items
        AND i.item_is_maintenance = 0  -- Exclude unavailable items
        AND (
            i.item_name LIKE @SearchText
            OR i.item_brand LIKE @SearchText
            OR i.item_serial_number LIKE @SearchText
            OR i.item_type LIKE @SearchText
            OR i.item_condition LIKE @SearchText
        )";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                    DataTable dataTable = new DataTable();

                    connection.Open();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Hide the ID column
                        dataGridView1.Columns["ID"].Visible = false;
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        MessageBox.Show("No items found matching your search.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaintenanceHistory maintenanceHistory = new MaintenanceHistory();
            this.Hide();
            maintenanceHistory.ShowDialog();
            this.Close();
        }

        private void RequestBt7_Click(object sender, EventArgs e)
        {
            BorrowedAdminF5 borrowReq = new BorrowedAdminF5();
            this.Hide();
            borrowReq.ShowDialog();
            this.Close();
        }

        private void BorrowedBt8_Click(object sender, EventArgs e)
        {
            Borrower borrower = new Borrower();
            this.Hide();
            borrower.ShowDialog();
            this.Close();
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            ArchiveAdminF4 archiveAdminF4 = new ArchiveAdminF4();
            this.Hide();
            archiveAdminF4.ShowDialog();
            this.Close();
        }
    }
}
