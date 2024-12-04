using System;
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
    public partial class AdminView : Form
    {
        SqlConnection connection = DatabaseConnection.Instance.Connection;
        string query;

        public AdminView()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string query = @"
                        SELECT 
                            i.item_id AS 'ID',  -- Add the ID column to the query
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
                            AND i.item_is_maintenance = 0 
                            AND i.item_is_borrowed = 0";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        // Bind the data if rows are available
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Hide the ID column (the column we added in the query)
                        dataGridView1.Columns["ID"].Visible = false;
                    }
                    else
                    {
                        // Clear the DataGridView if no rows are returned
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = null; // Clear the DataGridView in case of an error
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void AddBt1_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new ItemList());
            //ShowItemListPopup();
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

                // Create the ItemList form (popup)
                ItemList itemListPopup = new ItemList
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = this // Pass parent form reference
                };

                // Show the popup and wait for it to close
                if (itemListPopup.ShowDialog() == DialogResult.OK) // Wait for the dialog to return OK
                {
                    // Reload items after adding data
                    LoadItems(); // Make sure this is called after a successful add
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the Item List: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the overlay after the ItemList form has been handled
                overlay.Close();
            }
        }


        private void StockBt5_Click(object sender, EventArgs e)
        {
            StocksAdminF8 itemStocks = new StocksAdminF8();
            this.Hide();
            itemStocks.ShowDialog();
            this.Close();
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            ArchiveAdminF4 itemArchive = new ArchiveAdminF4();
            this.Hide();
            itemArchive.ShowDialog();
            this.Close();
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

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        string query = @"
                            UPDATE items
                            SET 
                                item_is_archived = 1, 
                                item_is_maintenance = 0, 
                                item_is_borrowed = 0
                            WHERE item_id = @ItemId";

                        command.Parameters.AddWithValue("@ItemId", selectedItemId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadItems();
                        }
                        else
                        {
                            MessageBox.Show("No item was archived. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void RequestBt7_Click(object sender, EventArgs e)
        {

        }

        private void ItemBt4_Click(object sender, EventArgs e)
        {

        }

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            MaintenanceAdminF6 itemMaintenance = new MaintenanceAdminF6();
            this.Hide();
            itemMaintenance.ShowDialog();
            this.Close();
        }

        private void EditBt2_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Kunin ang ID mula sa selected row
                int selectedItemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Buksan ang FixItem form at ipasa ang itemId
                FixItem fixItemForm = new FixItem(selectedItemId);

                // Ipakita ang form bilang modal dialog
                if (fixItemForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload the data in DataGridView after fixing the item
                    LoadItems();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to fix.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowFixItemPopup(int itemId)
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

                // Pass the itemId to the FixItem form
                FixItem fixItemForm = new FixItem(itemId)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = this
                };

                // Check if the dialog result is OK and refresh items
                if (fixItemForm.ShowDialog() == DialogResult.OK)
                {
                    LoadItems(); // Refresh the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the Fix Item form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                overlay.Close();
            }
        }

        private void HistoriesBt9_Click(object sender, EventArgs e)
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
                using (SqlCommand command = new SqlCommand(query, connection))
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



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}