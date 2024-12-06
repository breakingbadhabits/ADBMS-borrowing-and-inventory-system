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
    public partial class BorrowerCurrent : Form
    {
        public BorrowerCurrent()
        {
            InitializeComponent();
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

        private void ViewBorrow_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new BorrowerView());
        }

        private void ViewCurrent_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new BorrowerCurrent());
        }

        private void ViewHistory_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new borrow_history());
        }

        private void BorrowDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void borrow_history_Load(object sender, EventArgs e)
        {
            LoadTransactionHistory();
        }
        private void LoadTransactionHistory()
        {
            try
            {
                SqlConnection connection = DatabaseConnection.Instance.Connection;

                // SQL query to get transaction data for the logged-in user, where:
                // - transaction_borrow_date is not NULL
                // - transaction_return_date is NULL
                string query = @"
            SELECT 
                i.item_name AS ItemName, 
                i.item_serial_number AS SerialNumber, 
                t.transaction_borrow_date AS BorrowDate,
                t.transaction_return_date AS DateReturned,
                t.transaction_due_date AS DueDate
            FROM transactions t
            INNER JOIN items i ON t.transaction_item_id = i.item_id
            WHERE t.transaction_user_id = @userId
              AND t.transaction_borrow_date IS NOT NULL  -- Ensure the borrow date is not NULL
              AND t.transaction_return_date IS NULL;   -- Filter for records without a return date
        ";

                // Use the logged-in user's UserId
                int userId = UserSession.UserId;

                // Create a DataTable to store the data
                DataTable dataTable = new DataTable();

                // Execute the query and fill the DataTable
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }

                // Bind the DataTable to the DataGridView
                BorrowDataGrid.DataSource = dataTable;

                // Adjust column headers and auto-size them to fit content
                BorrowDataGrid.Columns["ItemName"].HeaderText = "Item Name";
                BorrowDataGrid.Columns["SerialNumber"].HeaderText = "Serial Number";
                BorrowDataGrid.Columns["BorrowDate"].HeaderText = "Borrow Date";
                BorrowDataGrid.Columns["DateReturned"].HeaderText = "Date Returned";
                BorrowDataGrid.Columns["DueDate"].HeaderText = "Due Date";

                // Set AutoSizeColumnsMode to Fill to make the columns expand to fill the DataGridView width
                BorrowDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set row height to a consistent value to eliminate unnecessary space between rows
                BorrowDataGrid.RowTemplate.Height = 30;  // Adjust based on your content size

                // Automatically resize column headers based on content size
                BorrowDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading transaction history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
