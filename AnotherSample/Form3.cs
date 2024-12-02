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
    public partial class ItemsAdminF3 : Form
    {
        private string connectionString;

        public ItemsAdminF3()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["InventorySystemDB"].ConnectionString;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
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
        AND i.item_is_maintenance = 0 
        AND i.item_is_borrowed = 0";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    connection.Open();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        // Bind the data if rows are available
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = @"
                    UPDATE items
                    SET 
                        item_is_archived = 1, 
                        item_is_maintenance = 0, 
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
                                LoadItems();
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
                // Retrieve the selected item's ID
                int selectedItemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Pass the selected item ID to the popup
                ShowFixItemPopup(selectedItemId);
            }
            else
            {

            }
            {
                MessageBox.Show("Please select an item to fix.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}