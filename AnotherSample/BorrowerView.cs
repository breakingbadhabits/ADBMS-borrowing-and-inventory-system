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
    public partial class BorrowerView : Form
    {
        public BorrowerView()
        {
            InitializeComponent();
            loadBorrowDataGrid();
        }

        public void loadBorrowDataGrid()
        {
            SqlConnection connection = DatabaseConnection.Instance.Connection;
            string query = @"
        SELECT  
            stock_name AS 'Name',
            stock_available AS 'Available Items'
        FROM stocks";

            try
            {
                // Create a DataTable to hold the data
                DataTable dataTable = new DataTable();

                // Use SqlDataAdapter to fetch data into the DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable); // Populate the DataTable
                }

                // Bind the DataTable to the DataGridView
                BorrowDataGrid.DataSource = dataTable;

                // Optional: Format the DataGridView
                BorrowDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                BorrowDataGrid.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LogoutBt11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewHistory_Click(object sender, EventArgs e)
        {

        }

        private void ViewCurrent_Click(object sender, EventArgs e)
        {

        }

        private void ViewBorrow_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
