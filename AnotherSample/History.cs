    using System;
using System.Collections;
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
        SqlConnection connection = DatabaseConnection.Instance.Connection;

        public HistoryAdminF7()
        {
            InitializeComponent();
            UpdateNotificationCount();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ItemBt4_Click(object sender, EventArgs e)
        {
            {
                FormNavigator.Navigate(this, new AdminView());
            }
        }

        private void StockBt5_Click(object sender, EventArgs e)
        {
            {
                FormNavigator.Navigate(this, new StocksAdmin());
            }
        }

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            {
                FormNavigator.Navigate(this, new MaintenanceAdminF6());
            }
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            {
                FormNavigator.Navigate(this, new AdminArchive());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                // Reload all transaction history if the search box is empty
                ShowTransactionHistory();
                return;
            }

            try
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
            AND transactions.transaction_return_date IS NOT NULL
            AND (
                users.user_name LIKE @SearchText
                OR items.item_name LIKE @SearchText
                OR CONVERT(VARCHAR, transactions.transaction_borrow_date, 120) LIKE @SearchText
                OR CONVERT(VARCHAR, transactions.transaction_due_date, 120) LIKE @SearchText
                OR CONVERT(VARCHAR, transactions.transaction_return_date, 120) LIKE @SearchText
            )";

                using (SqlConnection localConnection = new SqlConnection(connection.ConnectionString))
                {
                    DataTable dataTable = new DataTable();

                    using (SqlCommand command = new SqlCommand(query, localConnection))
                    {
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        dataAdapter.Fill(dataTable);
                    }

                    // Update the DataGridView with the filtered results
                    dataGridView1.DataSource = dataTable;

                    // Auto-size columns
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Hide the "Transaction ID" column
                    if (dataGridView1.Columns.Contains("Transaction ID"))
                    {
                        dataGridView1.Columns["Transaction ID"].Visible = false;
                    }

                    // Format date columns
                    if (dataGridView1.Columns.Contains("Borrow Date"))
                    {
                        dataGridView1.Columns["Borrow Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    }
                    if (dataGridView1.Columns.Contains("Due Date"))
                    {
                        dataGridView1.Columns["Due Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    }
                    if (dataGridView1.Columns.Contains("Return Date"))
                    {
                        dataGridView1.Columns["Return Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
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
                AND i.item_is_borrowed = 0
                AND i.item_is_maintenance = 0
                AND (
                    i.item_name LIKE @SearchText
                    OR i.item_brand LIKE @SearchText
                    OR i.item_serial_number LIKE @SearchText
                    OR i.item_type LIKE @SearchText
                    OR i.item_condition LIKE @SearchText
                )";

                using (SqlConnection localConnection = new SqlConnection(connection.ConnectionString))
                {
                    localConnection.Open();

                    using (SqlCommand command = new SqlCommand(query, localConnection))
                    {
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
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
            FormNavigator.Navigate(this, new AdminBorrowRequest());
        }

        private void BorrowedBt8_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new AdminBorrowedItem());
        }

        private void HistoriesBt9_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new HistoryAdminF7());
        }
        private void HistoryAdminF7_Load(object sender, EventArgs e)
        {
            ShowTransactionHistory();
        }
        private void ShowTransactionHistory()
        {
            try
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

                using (SqlConnection localConnection = new SqlConnection(connection.ConnectionString))
                {
                    localConnection.Open();

                    using (SqlCommand command = new SqlCommand(query, localConnection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        dataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            // Optionally hide the "Transaction ID" column
                            dataGridView1.Columns["Transaction ID"].Visible = false;

                            // Optionally format columns
                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                            // Remove the message box here
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching transaction history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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



