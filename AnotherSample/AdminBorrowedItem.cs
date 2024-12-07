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
        public partial class AdminBorrowedItem : Form
        {
            public AdminBorrowedItem()
            {
                InitializeComponent();
            }
            private void Borrower_Load(object sender, EventArgs e)
            {
                ShowBorrowedTransactions();
                UpdateNotificationCount();
            }

        // Method to display all transactions with a non-null borrow date

        private void ShowBorrowedTransactions()
        {
            try
            {
                string connectionString = "Data Source=JERMAINE;Initial Catalog=inventory_system;Persist Security Info=True;User ID=sa;Password=12345;";
                string query = @"
        SELECT 
            transactions.transaction_id AS [Transaction ID],
            users.user_name AS [User Name],
            items.item_name AS [Item Name],
            items.item_id AS [Item ID], -- Add this line
            transactions.transaction_borrow_date AS [Borrow Date],
            transactions.transaction_due_date AS [Due Date]
        FROM 
            transactions
        LEFT JOIN 
            users ON transactions.transaction_user_id = users.user_id
        LEFT JOIN 
            items ON transactions.transaction_item_id = items.item_id
        WHERE 
            transactions.transaction_borrow_date IS NOT NULL
            AND transactions.transaction_return_date IS NULL";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataTable dataTable = new DataTable();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                    }

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Hide the "Transaction ID" and "Item ID" columns
                        if (dataGridView1.Columns["Transaction ID"] != null)
                        {
                            dataGridView1.Columns["Transaction ID"].Visible = false;
                        }
                        if (dataGridView1.Columns["Item ID"] != null)
                        {
                            dataGridView1.Columns["Item ID"].Visible = false;
                        }

                        // Align content and headers
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Validate and fetch Transaction ID
                    if (!int.TryParse(dataGridView1.SelectedRows[0].Cells["Transaction ID"].Value?.ToString(), out int transactionId))
                    {
                        MessageBox.Show("Invalid Transaction ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validate and fetch Item ID
                    if (!int.TryParse(dataGridView1.SelectedRows[0].Cells["Item ID"].Value?.ToString(), out int itemId))
                    {
                        MessageBox.Show("Invalid Item ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime returnDate = DateTime.Now;
                    string connectionString = "Data Source=JERMAINE;Initial Catalog=inventory_system;Persist Security Info=True;User ID=sa;Password=12345;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Update transaction return date
                                string updateTransactionQuery = @"
                            UPDATE transactions
                            SET transaction_return_date = @ReturnDate
                            WHERE transaction_id = @TransactionId";

                                using (SqlCommand command = new SqlCommand(updateTransactionQuery, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@ReturnDate", returnDate);
                                    command.Parameters.AddWithValue("@TransactionId", transactionId);
                                    command.ExecuteNonQuery();
                                }

                                // Update item borrow status
                                string updateItemQuery = @"
                            UPDATE items
                            SET item_is_borrowed = 0
                            WHERE item_id = @ItemId";

                                using (SqlCommand command = new SqlCommand(updateItemQuery, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@ItemId", itemId);
                                    command.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Transaction updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Refresh the grid
                                ShowBorrowedTransactions();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Transaction failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please select a row to process the return.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void ItemBt4_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new AdminView());
        }

        private void StockBt5_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new StocksAdmin());
        }

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new MaintenanceAdminF6());
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

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new AdminArchive());
        }

        private void LogoutBt_Click(object sender, EventArgs e)
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