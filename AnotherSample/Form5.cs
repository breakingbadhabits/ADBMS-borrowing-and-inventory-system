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
    public partial class BorrowedAdminF5 : Form
    {
        public BorrowedAdminF5()
        {
            InitializeComponent();
        }
        private void BorrowedAdminF5_Load(object sender, EventArgs e)
        {
            ShowTransactionsWithNullBorrowDate();
        }

        private void ShowTransactionsWithNullBorrowDate()
        {
            try
            {
                string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";
                string query = @"
            SELECT 
                transactions.transaction_id AS [Transaction ID],
                users.user_name AS [User Name],
                items.item_name AS [Item Name],
                transactions.transaction_due_date AS [Due Date]
            FROM 
                transactions
            LEFT JOIN 
                users ON transactions.transaction_user_id = users.user_id
            LEFT JOIN 
                items ON transactions.transaction_item_id = items.item_id
            WHERE 
                transactions.transaction_borrow_date IS NULL";

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

                        // Hide the "Transaction ID" column
                        if (dataGridView1.Columns["Transaction ID"] != null)
                        {
                            dataGridView1.Columns["Transaction ID"].Visible = false;
                        }

                        // Auto-size columns to fill the DataGridView
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Optional: Adjust alignment and minimum width
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.MinimumWidth = 100;
                        }
                    }
                    else
                    {
                        // Clear the DataGridView without showing any message
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HistoriesBt9_Click(object sender, EventArgs e)
        {
            HistoryAdminF7 historyAdminF7 = new HistoryAdminF7();
            this.Hide();
            historyAdminF7.ShowDialog();
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
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Retrieve the "Transaction ID" from the selected row
                    if (dataGridView1.SelectedRows[0].Cells["Transaction ID"] != null)
                    {
                        int transactionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Transaction ID"].Value);

                        // SQL connection string
                        string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            // First, fetch the `transaction_item_id` for the given `transaction_id`
                            string selectQuery = @"
                        SELECT transaction_item_id
                        FROM transactions
                        WHERE transaction_id = @TransactionId";

                            int transactionItemId = 0;

                            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                            {
                                // Add parameter to prevent SQL injection
                                selectCommand.Parameters.AddWithValue("@TransactionId", transactionId);

                                // Open the connection
                                connection.Open();

                                // Execute the SELECT query and retrieve the result
                                object result = selectCommand.ExecuteScalar();
                                if (result != null)
                                {
                                    transactionItemId = Convert.ToInt32(result);
                                }
                                else
                                {
                                    MessageBox.Show("Transaction Item ID not found for the selected Transaction ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return; // Exit the method if no item ID is found
                                }
                            }

                            // Update the `item_is_borrowed` column to 1 for the retrieved `transaction_item_id`
                            string updateItemQuery = @"
                        UPDATE items
                        SET item_is_borrowed = 1
                        WHERE item_id = @ItemId";

                            using (SqlCommand updateItemCommand = new SqlCommand(updateItemQuery, connection))
                            {
                                // Add parameter to prevent SQL injection
                                updateItemCommand.Parameters.AddWithValue("@ItemId", transactionItemId);

                                // Execute the UPDATE query
                                int rowsAffected = updateItemCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Also update the `transaction_borrow_date` column to the current date and time
                                    string updateTransactionQuery = @"
                                UPDATE transactions
                                SET transaction_borrow_date = @BorrowDate
                                WHERE transaction_id = @TransactionId";

                                    using (SqlCommand updateTransactionCommand = new SqlCommand(updateTransactionQuery, connection))
                                    {
                                        // Add parameters for the query
                                        updateTransactionCommand.Parameters.AddWithValue("@BorrowDate", DateTime.Now); // Current date and time
                                        updateTransactionCommand.Parameters.AddWithValue("@TransactionId", transactionId);

                                        // Execute the UPDATE query
                                        updateTransactionCommand.ExecuteNonQuery();
                                    }

                                    // Success message
                                    MessageBox.Show("Item is now marked as borrowed and borrow date has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Refresh the DataGridView to reflect changes
                                    ShowTransactionsWithNullBorrowDate();
                                }
                                else
                                {
                                    // No rows updated, possibly incorrect Transaction ID
                                    MessageBox.Show($"No item found with the selected Transaction Item ID: {transactionItemId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected row does not contain a valid Transaction ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Handle unexpected errors
                    MessageBox.Show($"An error occurred while updating the item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // No row selected
                MessageBox.Show("Please select a row to archive.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ItemBt4_Click(object sender, EventArgs e)
        {
            AdminView adminView = new AdminView();
            this.Hide();
            adminView.ShowDialog();
            this.Close();
        }

        private void RequestBt7_Click(object sender, EventArgs e)
        {
            BorrowedAdminF5 borrowReq = new BorrowedAdminF5();
            this.Hide();
            borrowReq.ShowDialog();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StockBt5_Click(object sender, EventArgs e)
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

        private void BorrowedBt8_Click(object sender, EventArgs e)
        {
            Borrower borrowReq = new Borrower();
            this.Hide();
            borrowReq.ShowDialog();
            this.Close();
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            ArchiveAdminF4 archiveAdminF4 = new ArchiveAdminF4();
            this.Hide();
            archiveAdminF4.ShowDialog();
            this.Close();
        }
    }
}
