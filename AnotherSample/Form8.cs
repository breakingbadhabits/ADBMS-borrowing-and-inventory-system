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
namespace AnotherSample

{
    public partial class StocksAdminF8 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["InventorySystemDB"].ConnectionString;


        public StocksAdminF8()
        {
            InitializeComponent();
            LoadStockData();
        }

        private void LoadStockData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
    SELECT 
        s.stock_name,
        COUNT(i.item_id) AS stock_total_quantity,
        SUM(CASE WHEN i.item_is_borrowed = 1 THEN 1 ELSE 0 END) AS stock_borrowed,
        SUM(CASE WHEN i.item_is_maintenance = 1 THEN 1 ELSE 0 END) AS stock_under_maintenance,
        SUM(CASE WHEN i.item_is_borrowed = 0 AND i.item_is_maintenance = 0 AND i.item_is_archived = 0 THEN 1 ELSE 0 END) AS stock_available
    FROM 
        stocks s
    LEFT JOIN 
        items i ON s.stock_id = i.item_stock_id
    GROUP BY 
        s.stock_name
    ORDER BY 
        s.stock_name;";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Optionally, set column headers
                    dataGridView1.Columns["stock_name"].HeaderText = "Stock Name";
                    dataGridView1.Columns["stock_total_quantity"].HeaderText = "Total Quantity";
                    dataGridView1.Columns["stock_borrowed"].HeaderText = "Borrowed";
                    dataGridView1.Columns["stock_under_maintenance"].HeaderText = "Under Maintenance";
                    dataGridView1.Columns["stock_available"].HeaderText = "Available";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button handlers to navigate to other forms (already in your code)
        private void ItemBt4_Click(object sender, EventArgs e)
        {
            ItemsAdminF3 itemsAdmin = new ItemsAdminF3();
            this.Hide();
            itemsAdmin.ShowDialog();
            this.Close();
        }

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            MaintenanceAdminF6 maintenanceAdmin = new MaintenanceAdminF6();
            this.Hide();
            maintenanceAdmin.ShowDialog();
            this.Close();
        }

        private void StockBt5_Click(object sender, EventArgs e)
        {
            // Code for StockBt5 (if needed)
        }

        private void HistoriesBt9_Click(object sender, EventArgs e)
        {
            HistoryAdminF7 historyForm = new HistoryAdminF7();
            this.Hide();
            historyForm.ShowDialog();
            this.Close();
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            ArchiveAdminF4 archiveForm = new ArchiveAdminF4();
            this.Hide();
            archiveForm.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}