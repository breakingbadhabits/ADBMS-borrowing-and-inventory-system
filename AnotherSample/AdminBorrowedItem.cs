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
            }

        // Method to display all transactions with a non-null borrow date

        private void ShowBorrowedTransactions()
        {
            try
            {
                // Define your connection string (update server and database details as needed)
                string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";

                // SQL query to fetch transactions with a non-null borrow date and join with items and users, excluding those with a return date
                string query = @"
                SELECT 
                    transactions.transaction_id AS [Transaction ID],
                    users.user_name AS [User Name],
                    items.item_name AS [Item Name],
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
                    AND transactions.transaction_return_date IS NULL"; // Ensure return date is null

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataTable dataTable = new DataTable();

                    // Use a data adapter to fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Bind the data to the DataGridView
                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.AutoGenerateColumns = true; // Automatically generate columns
                        dataGridView1.DataSource = dataTable;     // Bind the data

                        // Auto-size columns to fit the content
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Hide the "Transaction ID" column
                        if (dataGridView1.Columns["Transaction ID"] != null)
                        {
                            dataGridView1.Columns["Transaction ID"].Visible = false;
                        }

                        // Customize column alignments
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = null; // Clear the grid if no data is found
                    }
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur during the query
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
                    // Get the transaction ID of the selected row
                    int transactionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Transaction ID"].Value);

                    // Get the item ID from the selected row
                    int itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Item Name"].Value); // Adjust column name if needed

                    // Get the current date and time to set as the return date
                    DateTime returnDate = DateTime.Now;

                    // Update the transaction_return_date and set item_is_borrowed to 0 in the database
                    string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Begin a transaction to ensure both updates happen together
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Update transaction_return_date
                                string updateTransactionQuery = @"
                                    UPDATE transactions
                                    SET transaction_return_date = @ReturnDate
                                    WHERE transaction_id = @TransactionId";

                                using (SqlCommand command = new SqlCommand(updateTransactionQuery, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@ReturnDate", returnDate);
                                    command.Parameters.AddWithValue("@TransactionId", transactionId);

                                    int rowsAffected = command.ExecuteNonQuery();
                                    if (rowsAffected == 0)
                                    {
                                        throw new Exception("Failed to update transaction return date.");
                                    }
                                }

                                // Update item_is_borrowed to 0
                                string updateItemQuery = @"
                                    UPDATE items
                                    SET item_is_borrowed = 0
                                    WHERE item_id = @ItemId";

                                using (SqlCommand command = new SqlCommand(updateItemQuery, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@ItemId", itemId);

                                    int rowsAffected = command.ExecuteNonQuery();
                                    if (rowsAffected == 0)
                                    {
                                        throw new Exception("Failed to update item borrow status.");
                                    }
                                }

                                // Commit the transaction
                                transaction.Commit();
                                MessageBox.Show("Transaction return date updated and item status set to 'Not Borrowed'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Refresh the data grid view to reflect the changes
                                ShowBorrowedTransactions();
                            }
                            catch (Exception ex)
                            {
                                // Rollback the transaction if anything goes wrong
                                transaction.Rollback();
                                MessageBox.Show($"An error occurred while updating the transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update the return date and item status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            FormNavigator.Navigate(this, new Notif());
        }
    }
}