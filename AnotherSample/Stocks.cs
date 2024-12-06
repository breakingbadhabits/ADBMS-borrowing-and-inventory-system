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


        private Timer autoUpdateTimer;

        public StocksAdminF8()
        {
            InitializeComponent();
            LoadStockData();

            // Initialize and configure the timer
            autoUpdateTimer = new Timer
            {
                Interval = 5000 // 5 seconds (adjust as needed)
            };
            autoUpdateTimer.Tick += AutoUpdateTimer_Tick;
            autoUpdateTimer.Start();
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
            SUM(CASE WHEN i.item_is_archived = 1 THEN 1 ELSE 0 END) AS stock_archived,

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
                        dataGridView1.Columns["stock_archived"].HeaderText = "Archived";
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
                AdminView itemsAdmin = new AdminView();
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
            StocksAdminF8 itemStocks = new StocksAdminF8();
            this.Hide();
            itemStocks.ShowDialog();
            this.Close();
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

            private void button1_Click(object sender, EventArgs e)
            {
                ShowItemListPopup();
            }
            private void ShowItemListPopup()
            {
                Form overlay = new Form
                {
                    FormBorderStyle = FormBorderStyle.None,
                    BackColor = Color.Black,
                    Opacity = 0.5,
                    ShowInTaskbar = false,
                    StartPosition = FormStartPosition.Manual,
                    Bounds = this.Bounds,
                    Owner = this
                };

                try
                {
                    overlay.Show();

                    // Show the AddStock form
                    AddStock addStockPopup = new AddStock
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        Owner = this
                    };

                    // Show the dialog and check its result
                    if (addStockPopup.ShowDialog() == DialogResult.OK)
                    {
                        // Reload stock data after successfully adding a stock
                        LoadStockData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    overlay.Close();
                }
            }

            private void DeleteBt3_Click(object sender, EventArgs e)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string selectedStockName = dataGridView1.SelectedRows[0].Cells["stock_name"].Value.ToString();

                    // Create overlay
                    Form overlay = new Form
                    {
                        FormBorderStyle = FormBorderStyle.None,
                        BackColor = Color.Black,
                        Opacity = 0.5,
                        ShowInTaskbar = false,
                        StartPosition = FormStartPosition.Manual,
                        Bounds = this.Bounds,
                        Owner = this
                    };

                    try
                    {
                        overlay.Show();

                        // Create and show the Warning Form (Form15)
                        Form15 warningForm = new Form15
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            Owner = this,
                            SelectedStockName = selectedStockName // Pass the selected stock name
                        };

                        if (warningForm.ShowDialog() == DialogResult.OK) // User confirmed delete
                        {
                            LoadStockData(); // Reload the DataGridView after deletion
                        }
                    }
                    finally
                    {
                        overlay.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a stock to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        private void AutoUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue; // Skip the new row

                        // Retrieve values from the DataGridView
                        string stockName = row.Cells["stock_name"].Value?.ToString();
                        int stockAvailable = Convert.ToInt32(row.Cells["stock_available"].Value ?? 0);
                        int stockUnderMaintenance = Convert.ToInt32(row.Cells["stock_under_maintenance"].Value ?? 0);
                        int stockBorrowed = Convert.ToInt32(row.Cells["stock_borrowed"].Value ?? 0);
                        int stockArchived = Convert.ToInt32(row.Cells["stock_archived"].Value ?? 0);

                        // Update query
                        string updateQuery = @"
                    UPDATE stocks
                    SET 
                        stock_available = @stockAvailable,
                        stock_under_maintenance = @stockUnderMaintenance,
                        stock_borrowed = @stockBorrowed,
                        stock_archived = @stockArchived
                    WHERE 
                        stock_name = @stockName";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Add parameters
                            command.Parameters.AddWithValue("@stockName", stockName);
                            command.Parameters.AddWithValue("@stockAvailable", stockAvailable);
                            command.Parameters.AddWithValue("@stockUnderMaintenance", stockUnderMaintenance);
                            command.Parameters.AddWithValue("@stockBorrowed", stockBorrowed);
                            command.Parameters.AddWithValue("@stockArchived", stockArchived);

                            // Execute the query
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during automatic update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
