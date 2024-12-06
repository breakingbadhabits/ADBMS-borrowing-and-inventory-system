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
    public partial class HistoryAdminF7 : Form
    {
        private string connectionString;

        public HistoryAdminF7()
        {
            InitializeComponent();
            connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;"; // Assign the connection string here
        }

        // The rest of your code follows...



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ItemBt4_Click(object sender, EventArgs e)
        {
            {
                // Create an instance of the stock form
                AdminView itemForm = new AdminView();

                // Hide the current form
                this.Hide();

                // Show the stock form as a modal dialog
                itemForm.ShowDialog();

                // Show the current form again when returning from the stock form
                this.Close();
            }
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

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            {
                // Create an instance of the stock form
                MaintenanceAdminF6 maintenanceForm = new MaintenanceAdminF6();

                // Hide the current form
                this.Hide();

                // Show the stock form as a modal dialog
                maintenanceForm.ShowDialog();

                // Show the current form again when returning from the stock form
                this.Close();
            }
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            {
                // Create an instance of the stock form
                ArchiveAdminF4 archiveForm = new ArchiveAdminF4();

                // Hide the current form
                this.Hide();

                // Show the stock form as a modal dialog
                archiveForm.ShowDialog();

                // Show the current form again when returning from the stock form
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

                    connection.Open();
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
            Borrower borrower = new Borrower();
            this.Hide();
            borrower.ShowDialog();
            this.Close();
        }

        private void HistoriesBt9_Click(object sender, EventArgs e)
        {
            HistoryAdminF7 historyAdminF7 = new HistoryAdminF7();
            this.Hide();
            historyAdminF7.ShowDialog();
            this.Close();
        }
        private void HistoryAdminF7_Load(object sender, EventArgs e)
        {
            ShowTransactionHistory();
        }
        private void ShowTransactionHistory()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    transactions.transaction_id AS 'Transaction ID',
                    ISNULL(users.user_name, 'No user assigned') AS 'User Name',
                    items.item_name AS 'Item Name',
                    transactions.transaction_borrow_date AS 'Borrow Date',
                    transactions.transaction_due_date AS 'Due Date',
                    transactions.transaction_return_date AS 'Return Date'
                FROM 
                    transactions
                LEFT JOIN 
                    users ON transactions.transaction_user_id = users.user_id
                INNER JOIN 
                    items ON transactions.transaction_item_id = items.item_id
                WHERE 
                    transactions.transaction_borrow_date IS NOT NULL
                    AND transactions.transaction_return_date IS NOT NULL";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    connection.Open();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Optionally hide the "Transaction ID" column if needed
                        dataGridView1.Columns["Transaction ID"].Visible = false;

                        // Optionally format the columns (e.g., center-aligned headers)
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        MessageBox.Show("No transactions found with non-null borrow and return dates.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching transaction history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



