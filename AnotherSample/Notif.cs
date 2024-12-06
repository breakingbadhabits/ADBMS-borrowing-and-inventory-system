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
    public partial class Notif : Form
    {
        public Notif()
        {
            InitializeComponent();
            LoadNotif();
        }

        public void LoadNotif ()
        {
            try
            {
                // Define your connection string
                string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";

                // Your SQL query (adjust as needed)
                string query = @"
                SELECT 
                    transaction_id, 
                    user_name, 
                    item_name, 
                    transaction_borrow_date
                FROM 
                    transactions
                LEFT JOIN 
                    users ON transactions.transaction_user_id = users.user_id
                LEFT JOIN 
                    items ON transactions.transaction_item_id = items.item_id
                WHERE 
                    transactions.transaction_borrow_date IS NOT NULL
                    AND transactions.transaction_return_date IS NULL
                ORDER BY transactions.transaction_due_date";

                // Create a DataTable to hold the query results
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                // If there are results, show each row as a notification
                if (dataTable.Rows.Count > 0)
                {
                    // Create a DataTable to hold formatted notifications
                    var notificationsTable = new DataTable();
                    notificationsTable.Columns.Add("Notification");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        DateTime dueDate = Convert.ToDateTime(row["transaction_due_date"]);
                        if (dueDate < DateTime.Now)
                        {
                            // String interpolation to format the notification message
                            string message = $"User: {row["user_name"]}, Did not return the Item: {row["item_name"]} on time, Borrowed on: {row["transaction_borrow_date"]} with Due date: {row["transaction_due_date"]}";
                            notificationsTable.Rows.Add(message);
                        } else if (dueDate == DateTime.Now) {
                            string message = $"User: {row["user_name"]}, need to return the Item: {row["item_name"]} today, Borrowed on: {row["transaction_borrow_date"]}";
                            notificationsTable.Rows.Add(message);
                        } else if (dueDate > DateTime.Now.AddDays(3)) {
                            string message = $"User: {row["user_name"]}, need to return the Item: {row["item_name"]} within 3 days, Borrowed on: {row["transaction_borrow_date"]} with Due date: {row["transaction_due_date"]}";
                            notificationsTable.Rows.Add(message);
                        }
                    }

                    // Bind the notifications to the DataGridView
                    NotifGridView.DataSource = notificationsTable;

                    // Optional: Hide the column headers
                    NotifGridView.ColumnHeadersVisible = false;

                    NotifGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    NotifGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    NotifGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    NotifGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
                else
                {
                    // show message and goes back to admin view if no notifs
                    MessageBox.Show("No active transactions to display.", "No Transactions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormNavigator.Navigate(this, new AdminView());
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur during the query
                MessageBox.Show($"An error occurred while fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Notif_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
