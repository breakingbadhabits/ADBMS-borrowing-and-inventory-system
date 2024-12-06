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
        }

        //public void LoadNotif ()
        //{
        //    try
        //    {
        //        string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";

        //        string query = @"
        //            SELECT 
        //                transactions.transaction_id AS [Transaction ID],
        //                users.user_name AS [User Name],
        //                items.item_name AS [Item Name],
        //                transactions.transaction_borrow_date AS [Borrow Date],
        //                transactions.transaction_due_date AS [Due Date]
        //            FROM 
        //                transactions
        //            LEFT JOIN 
        //                users ON transactions.transaction_user_id = users.user_id
        //            LEFT JOIN 
        //                items ON transactions.transaction_item_id = items.item_id
        //            WHERE 
        //                transactions.transaction_borrow_date IS NOT NULL
        //                AND transactions.transaction_return_date IS NULL";

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            DataTable dataTable = new DataTable();

        //            // Use a data adapter to fill the DataTable
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
        //            {
        //                adapter.Fill(dataTable);
        //            }

        //            // Bind the data to the DataGridView
        //            if (dataTable.Rows.Count > 0)
        //            {
        //                NotifGridView.AutoGenerateColumns = true; // Automatically generate columns
        //                NotifGridView.DataSource = dataTable;     // Bind the data

        //                // Auto-size columns to fit the content
        //                NotifGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //            }
        //            else
        //            {
        //                NotifGridView.DataSource = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred while fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void Notif_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
