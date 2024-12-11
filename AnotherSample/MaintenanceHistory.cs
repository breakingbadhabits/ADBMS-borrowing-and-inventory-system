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
            connectionString = "Data Source=JERMAINE;Initial Catalog=inventory_system;Persist Security Info=True;User ID=sa;Password=12345;"; // Replace with your connection string
        }
        private void MaintenanceHistory_Load(object sender, EventArgs e)
        {
            LoadMaintenanceData();
            UpdateNotificationCount();
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
            AdminArchive archiveAdminF4 = new AdminArchive();
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
            try
            {
                // Check if any row is selected
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Retrieve the Maintenance ID of the selected row
                    int maintenanceId = Convert.ToInt32(selectedRow.Cells["Maintenance ID"].Value);

                    // Confirm the deletion
                    var result = MessageBox.Show(
                        "Are you sure you want to archive/delete this record?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Perform the deletion in the database
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "DELETE FROM maintenance WHERE maintenance_id = @MaintenanceId";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaintenanceId", maintenanceId);
                                command.ExecuteNonQuery();
                            }
                        }

                        // Remove the row from the DataGridView
                        dataGridView1.Rows.Remove(selectedRow);

                        MessageBox.Show("Record archived/deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                // Reload all maintenance data if the search box is empty
                LoadMaintenanceData();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
            SELECT 
                maintenance.maintenance_id AS 'Maintenance ID',
                items.item_name AS 'Item Name',
                maintenance.maintenance_start_date AS 'Start Date',
                maintenance.maintenance_complete_date AS 'Complete Date',
                maintenance.maintenance_description AS 'Description'
            FROM maintenance
            INNER JOIN items ON maintenance.maintenance_item_id = items.item_id
            WHERE 
                items.item_name LIKE @SearchText
                OR CONVERT(VARCHAR, maintenance.maintenance_start_date, 120) LIKE @SearchText
                OR CONVERT(VARCHAR, maintenance.maintenance_complete_date, 120) LIKE @SearchText
                OR maintenance.maintenance_description LIKE @SearchText";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Update the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Automatically resize columns
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Hide the Maintenance ID column
                    if (dataGridView1.Columns.Contains("Maintenance ID"))
                    {
                        dataGridView1.Columns["Maintenance ID"].Visible = false;
                    }

                    // Format the date columns
                    if (dataGridView1.Columns.Contains("Start Date"))
                    {
                        dataGridView1.Columns["Start Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    }
                    if (dataGridView1.Columns.Contains("Complete Date"))
                    {
                        dataGridView1.Columns["Complete Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    }

                    // Handle no matching rows
                    if (dataTable.Rows.Count == 0)
                    {
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void RequestBt7_Click(object sender, EventArgs e)
        {
            AdminBorrowRequest borrowReq = new AdminBorrowRequest();
            this.Hide();
            borrowReq.ShowDialog();
            this.Close();
        }

        private void BorrowedBt8_Click(object sender, EventArgs e)
        {

        }

        private void NotifBt_Click(object sender, EventArgs e)
        {
            Notif notifForm = new Notif();
            notifForm.OnNotificationCountUpdated += count =>
            {
                labelNotifCount.Text = $"Notifications: {count}";
            };
            notifForm.ShowDialog();
        }
        private void UpdateNotificationCount()
        {
            try
            {
                // Create an instance of the Notif form to access the row count
                using (Notif notifForm = new Notif())
                {
                    notifForm.LoadNotifications(); // Load the notifications (or your existing method)
                    int notificationCount = notifForm.GetNotificationCount(); // Get the row count

                    labelNotifCount.Text = $"{notificationCount}"; // Update the label
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating notification count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelNotifCount_Click(object sender, EventArgs e)
        {

        }
    }
}
