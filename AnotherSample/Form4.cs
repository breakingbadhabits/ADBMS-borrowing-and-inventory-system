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
    public partial class ArchiveAdminF4 : Form
    {
        private string connectionString = "Data Source=JERMAINE;Initial Catalog=inventory_system;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ArchiveAdminF4()
        {
            InitializeComponent();
        }
        private void ArchiveAdminF4_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to fetch only archived items
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

                    dataGridView1.AutoGenerateColumns = true; // Ensure columns are always generated
                    dataGridView1.Visible = true;

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dataTable;

                    // No message is shown if no data is fetched
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

        private void TextBox1_TextChanged(object sender, EventArgs e)
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
                    WHEN i.item_is_archived = 1 OR i.item_is_maintenance = 1 THEN 'Unavailable' 
                    ELSE 'Available' 
                END AS 'ItemStatus'
            FROM items i
            INNER JOIN stocks s ON i.item_stock_id = s.stock_id
            WHERE 
                i.item_is_archived = 1
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

                    // Make sure columns are visible
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dataTable;

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Hide the ID column (if required)
                        dataGridView1.Columns["ID"].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No items found matching your search.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    using (SqlConnection connection = new SqlConnection(connectionString))
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

        private void RequestBt7_Click(object sender, EventArgs e)
        {
            AdminBorrowRequest borrowReq = new AdminBorrowRequest();
            this.Hide();
            borrowReq.ShowDialog();
            this.Close();
        }

        private void BorrowedBt8_Click(object sender, EventArgs e)
        {
            AdminBorrowedItem borrower = new AdminBorrowedItem();
            this.Hide();
            borrower.ShowDialog();
            this.Close();
        }
    }
}
