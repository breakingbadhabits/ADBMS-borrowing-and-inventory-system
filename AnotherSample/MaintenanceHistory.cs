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
    public partial class MaintenanceHistory : Form
    {
        private string connectionString;

        public MaintenanceHistory()
        {
            InitializeComponent();
            connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;"; // Replace with your connection string
        }
        private void MaintenanceHistory_Load(object sender, EventArgs e)
        {
            LoadMaintenanceData();

        }


        private void LoadMaintenanceData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Updated query with JOIN
                    string query = @"
                SELECT 
                    maintenance.maintenance_id AS 'Maintenance ID',
                    items.item_name AS 'Item Name',
                    maintenance.maintenance_start_date AS 'Start Date',
                    maintenance.maintenance_complete_date AS 'Complete Date',
                    maintenance.maintenance_description AS 'Description'
                FROM maintenance
                INNER JOIN items ON maintenance.maintenance_item_id = items.item_id";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with data
                    dataAdapter.Fill(dataTable);

                    // Bind the data to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Automatically resize the columns to fit the content
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Hide the 'Maintenance ID' column
                    dataGridView1.Columns["Maintenance ID"].Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading maintenance data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void ItemBt4_Click_1(object sender, EventArgs e)
        {
            AdminView itemsAdminF3 = new AdminView();
            this.Hide();
            itemsAdminF3.ShowDialog();
            this.Close();
        }

        private void StockBt5_Click_1(object sender, EventArgs e)
        {
            StocksAdmin itemStocks = new StocksAdmin();
            this.Hide();
            itemStocks.ShowDialog();
            this.Close();
        }

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            MaintenanceAdminF6 maintenanceAdminF6 = new MaintenanceAdminF6();
            this.Hide();
            maintenanceAdminF6.ShowDialog();
            this.Close();
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            ArchiveAdminF4 archiveAdminF4 = new ArchiveAdminF4();
            this.Hide();
            archiveAdminF4.ShowDialog();
            this.Close();
        }

        private void LogoutBt11_Click(object sender, EventArgs e)
        {
            Logout();
        }
        private void Logout()
        {
            // Confirm logout action
            var result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Assuming there's a login form named `LoginF1`
                    LoginF1 loginForm = new LoginF1();

                    // Hide the current form
                    this.Hide();

                    // Show the login form and wait for it to close
                    loginForm.ShowDialog();

                    // After the login form is closed, exit the application to ensure all forms are closed
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while logging out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
            private void ArchiveBt3_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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

        }
    }
}
