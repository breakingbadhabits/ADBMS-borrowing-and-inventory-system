﻿using System;
using System.Collections;
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
    public partial class StocksAdmin : Form
    {
        SqlConnection connection = DatabaseConnection.Instance.Connection;

        private Timer autoUpdateTimer;

        public StocksAdmin()
        {
            InitializeComponent();
            LoadStockData();
            UpdateNotificationCount();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            // Configuration for the panel
            panel1.Margin = new Padding(0);
            panel1.Padding = new Padding(0);

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
            string query = @"
                SELECT 
                    s.stock_name AS StockName,
                    COUNT(i.item_id) AS TotalQuantity,
                    SUM(CASE WHEN i.item_is_borrowed = 1 THEN 1 ELSE 0 END) AS Borrowed,
                    SUM(CASE WHEN i.item_is_maintenance = 1 THEN 1 ELSE 0 END) AS UnderMaintenance,
                    SUM(CASE WHEN i.item_is_archived = 1 THEN 1 ELSE 0 END) AS Archived,
                    SUM(CASE WHEN i.item_is_borrowed = 0 AND i.item_is_maintenance = 0 AND i.item_is_archived = 0 THEN 1 ELSE 0 END) AS Available
                FROM 
                    stocks s
                LEFT JOIN 
                    items i ON s.stock_id = i.item_stock_id
                GROUP BY 
                    s.stock_name
                ORDER BY 
                    s.stock_name;";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    // Optionally, set column headers
                    dataGridView1.Columns["StockName"].HeaderText = "Stock Name";
                    dataGridView1.Columns["TotalQuantity"].HeaderText = "Total Quantity";
                    dataGridView1.Columns["Borrowed"].HeaderText = "Borrowed";
                    dataGridView1.Columns["UnderMaintenance"].HeaderText = "Under Maintenance";
                    dataGridView1.Columns["Archived"].HeaderText = "Archived";
                    dataGridView1.Columns["Available"].HeaderText = "Available";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        // Button handlers to navigate to other forms (already in your code)
        private void ItemBt4_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new AdminView());
        }

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new MaintenanceAdminF6());
        }

        private void StockBt5_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new StocksAdmin());
        }

        private void HistoriesBt9_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new HistoryAdminF7());
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new AdminArchive());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current column is the "Available" column
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Available")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int available))
                {
                    // Change the "Available" cell's background color based on its value
                    if (available == 0)
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White; // Optional: For better text visibility
                    }
                    else if (available <= 4)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            }
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
                string selectedStockName = dataGridView1.SelectedRows[0].Cells["StockName"].Value.ToString();

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
            string updateQuery = @"
                UPDATE stocks
                SET 
                    stock_available = @Available,
                    stock_under_maintenance = @UnderMaintenance,
                    stock_borrowed = @Borrowed,
                    stock_archived = @Archived
                WHERE 
                    stock_name = @StockName";
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnection.Instance.ConnectionString)) // Use a new instance
                {
                    connection.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string stockName = row.Cells["StockName"].Value?.ToString();
                        int available = Convert.ToInt32(row.Cells["Available"].Value ?? 0);
                        int underMaintenance = Convert.ToInt32(row.Cells["UnderMaintenance"].Value ?? 0);
                        int borrowed = Convert.ToInt32(row.Cells["Borrowed"].Value ?? 0);
                        int archived = Convert.ToInt32(row.Cells["Archived"].Value ?? 0);

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Bind parameters
                            command.Parameters.AddWithValue("@StockName", stockName);
                            command.Parameters.AddWithValue("@Available", available);
                            command.Parameters.AddWithValue("@UnderMaintenance", underMaintenance);
                            command.Parameters.AddWithValue("@Borrowed", borrowed);
                            command.Parameters.AddWithValue("@Archived", archived);

                            // Execute the query
                            command.ExecuteNonQuery();
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during automatic update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RequestBt7_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new AdminBorrowRequest());
        }

        private void BorrowedBt8_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new AdminBorrowedItem());
        }

        private void StocksAdmin_Load(object sender, EventArgs e)
        {

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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Retrieve the selected stock name from the DataGridView
                string selectedStockName = dataGridView1.SelectedRows[0].Cells["StockName"].Value.ToString();

                // Create overlay form
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

                    // Create and show the confirmation form (Form15)
                    Form15 confirmationForm = new Form15
                    {
                        SelectedStockName = selectedStockName, // Pass the selected stock name to Form15
                        StartPosition = FormStartPosition.CenterParent,
                        Owner = this
                    };

                    // Show the dialog and check if the deletion is confirmed
                    if (confirmationForm.ShowDialog() == DialogResult.OK)
                    {
                        // If deletion is successful, refresh the DataGridView
                        LoadStockData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
