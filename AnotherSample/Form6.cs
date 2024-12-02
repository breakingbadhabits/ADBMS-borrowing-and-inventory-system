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
        }

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
                ItemsAdminF3 itemsAdmin = new ItemsAdminF3();

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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadMaintenanceItems()
        {
            // Connection string (update with your server and database details)
            string connectionString = "Server=your_server;Database=your_database;Trusted_Connection=True;";

            // SQL query to fetch items where item_is_maintenance = 1
            string query = @"
    SELECT 
        i.item_id AS 'ID', 
        i.item_name AS 'ItemName', 
        i.item_brand AS 'Brand', 
        i.item_serial_number AS 'SerialNumber', 
        i.item_type AS 'ItemType', 
        i.item_condition AS 'Condition', 
        s.stock_id AS 'StockID', 
        s.stock_name AS 'StockUnder', 
        CASE 
            WHEN i.item_is_borrowed = 1 OR i.item_is_maintenance = 1 THEN 'Unavailable' 
            ELSE 'Available' 
        END AS 'ItemStatus'
    FROM items i
    INNER JOIN stocks s ON i.item_stock_id = s.stock_id
    WHERE 
        i.item_is_archived = 0 
        AND i.item_is_maintenance = 1 
        AND i.item_is_borrowed = 0";
            try
            {
                // Create a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Use SqlDataAdapter to execute the query and fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Create a DataTable to store the data
                    DataTable itemsTable = new DataTable();
                    adapter.Fill(itemsTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = itemsTable;

                    // Adjust columns to fit the DataGridView
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the process
                MessageBox.Show($"Error loading items data: {ex.Message}");
            }
        }

        private void MaintenanceAdminF6_Load(object sender, EventArgs e)
        {
            LoadMaintenanceItems();
        }

    }
}
