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

        public void LoadNotif()
        {
            try
            {
                // Define your connection string
                string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";

                // Your SQL query (adjust as needed)
                string query = @"
        SELECT 
            *
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
                        DateTime currentDate = DateTime.Now;
                        int remainingDays = (dueDate - currentDate).Days;

                        // Only show notifications for due dates within the next 3 days
                        if (remainingDays >= 0 && remainingDays <= 3)
                        {
                            string message;

                            if (remainingDays == 0)
                            {
                                // Due today
                                message = $"User: {row["user_name"]}, need to return the Item: {row["item_name"]} TODAY, Borrowed on: {row["transaction_borrow_date"]} with Due date: {row["transaction_due_date"]}";
                            }
                            else if (remainingDays == 1)
                            {
                                // Due in 1 day
                                message = $"User: {row["user_name"]}, need to return the Item: {row["item_name"]} in 1 day, Borrowed on: {row["transaction_borrow_date"]} with Due date: {row["transaction_due_date"]}";
                            }
                            else
                            {
                                // Due in more than 1 day but less than or equal to 3 days
                                message = $"User: {row["user_name"]}, need to return the Item: {row["item_name"]} in {remainingDays} days, Borrowed on: {row["transaction_borrow_date"]} with Due date: {row["transaction_due_date"]}";
                            }

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
                    // Show message and go back to admin view if no notifs
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
