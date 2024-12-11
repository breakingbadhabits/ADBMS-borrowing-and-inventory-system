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

    public partial class AdminArchive : Form
    {
        string ConnectionString = "Data Source=JERMAINE;Initial Catalog=inventory_system;Persist Security Info=True;User ID=sa;Password=12345;";

        public AdminArchive()
        {
            InitializeComponent();
        }
        private void ArchiveAdminF4_Load(object sender, EventArgs e)
        {
            LoadItems();
            UpdateNotificationCount();
        }

        private void LoadItems()
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            i.item_id AS 'ID', 
                            i.item_name AS 'ItemName', 
                            i.item_brand AS 'Brand', 
                            i.item_serial_number AS 'SerialNumber', 
                            i.item_type AS 'ItemType', 
                            i.item_condition AS 'Condition', 
                            CASE 
                                WHEN i.item_is_borrowed = 1 THEN 'Unavailable' 
                                ELSE 'Available' 
                            END AS 'ItemStatus'
                        FROM items i
                        INNER JOIN stocks s ON i.item_stock_id = s.stock_id
                        WHERE i.item_is_archived = 1";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.Visible = true;

                    dataGridView1.DataSource = dataTable;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ItemBt4_Click(object sender, EventArgs e)
        {
            AdminView itemForm = new AdminView();
            this.Hide();
            itemForm.ShowDialog();
            this.Close();
        }

        private void StockBt5_Click(object sender, EventArgs e)
        {
            StocksAdmin stockForm = new StocksAdmin();
            this.Hide();
            stockForm.ShowDialog();
            this.Close();
        }

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            MaintenanceAdminF6 maintenanceForm = new MaintenanceAdminF6();
            this.Hide();
            maintenanceForm.ShowDialog();
            this.Close();
        }

        private void HistoriesBt9_Click(object sender, EventArgs e)
        {
            HistoryAdminF7 historyForm = new HistoryAdminF7();
            this.Hide();
            historyForm.ShowDialog();
            this.Close();
        }

        private void ArchiveBt3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedItemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Create the warning form
                WarningSign warningSign = new WarningSign
                {
                    SelectedItemId = selectedItemId // Pass the selected ID
                };

                // Create the overlay form
                Form overlay = new Form
                {
                    StartPosition = FormStartPosition.Manual,
                    FormBorderStyle = FormBorderStyle.None,
                    Opacity = 0.5,
                    BackColor = Color.Black,
                    TopMost = false,
                    ShowInTaskbar = false,
                    Bounds = this.Bounds,
                    WindowState = FormWindowState.Normal
                };

                try
                {
                    // Set overlay as child of the main form
                    overlay.Owner = this;

                    // Show overlay
                    overlay.Show();

                    // Handle closing of WarningSign
                    warningSign.FormClosed += (s, args) =>
                    {
                        overlay.Close(); // Close overlay
                        this.BringToFront(); // Ensure the main form regains focus
                        LoadItems(); // Refresh the DataGridView after potential deletion
                    };

                    // Show the warning dialog modally
                    warningSign.ShowDialog(this); // Set `this` as the owner for proper focus
                }
                catch
                {
                    overlay.Close(); // Ensure overlay is closed even if an exception occurs
                    this.BringToFront(); // Restore focus to the main form
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void RestoreItem()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Get the ID of the selected item
                    int selectedItemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();

                        // Query to update the item_is_archived value to 0
                        string query = "UPDATE items SET item_is_archived = 0 WHERE item_id = @ItemId";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ItemId", selectedItemId);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Item successfully restored.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadItems(); // Refresh the DataGridView to reflect changes
                            }
                            else
                            {
                                MessageBox.Show("Failed to restore the item. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to restore.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AddBt1_Click(object sender, EventArgs e)
        {
            RestoreItem();
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new AdminArchive());
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
                    FormNavigator.Navigate(this, new LoginF1());
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while logging out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                // Reload all items if the search box is empty
                LoadItems();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL query to filter items based on the search input
                    string query = @"
            SELECT 
                i.item_id AS 'ID', 
                i.item_name AS 'ItemName', 
                i.item_brand AS 'Brand', 
                i.item_serial_number AS 'SerialNumber', 
                i.item_type AS 'ItemType', 
                i.item_condition AS 'Condition', 
                CASE 
                    WHEN i.item_is_borrowed = 1 THEN 'Unavailable' 
                    ELSE 'Available' 
                END AS 'ItemStatus'
            FROM items i
            INNER JOIN stocks s ON i.item_stock_id = s.stock_id
            WHERE 
                i.item_is_archived = 1
                AND (
                    i.item_id LIKE @SearchText
                    OR i.item_name LIKE @SearchText
                    OR i.item_brand LIKE @SearchText
                    OR i.item_serial_number LIKE @SearchText
                    OR i.item_type LIKE @SearchText
                    OR i.item_condition LIKE @SearchText
                )";

                    // Add search parameter and execute query
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Update DataGridView with filtered results
                    dataGridView1.DataSource = dataTable;

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Hide the ID column (optional)
                        dataGridView1.Columns["ID"].Visible = false;
                    }
                    else
                    {
                        dataGridView1.DataSource = null; // Clear DataGridView if no items are found
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
