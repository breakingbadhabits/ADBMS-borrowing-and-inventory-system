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
    public partial class MaintenanceHistory : Form
    {
        private string connectionString;

        public MaintenanceHistory()
        {
            InitializeComponent();
            connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;"; // Replace with your connection string
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadMaintenanceHistory();
        }

        private void LoadMaintenanceHistory()
        {
            try
            {
                // Open connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            maintenance_id AS 'MaintenanceID', 
                            item_id AS 'ItemID', 
                            maintenance_date AS 'MaintenanceDate', 
                            maintenance_description AS 'Description', 
                            maintenance_status AS 'Status'
                        FROM maintenance
                        ORDER BY maintenance_date DESC"; // Adjust the query as per your table structure

                    // Set up the DataAdapter to fill the DataTable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    connection.Open(); // Open the connection
                    dataAdapter.Fill(dataTable); // Fill the DataTable with the data

                    // Check if there are records to display
                    if (dataTable.Rows.Count > 0)
                    {
                        // Bind the data to the DataGridView
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        // If no records are found, display a message
                        MessageBox.Show("No maintenance history available.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null; // Clear any previous data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading maintenance history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = null; // Clear the DataGridView in case of an error
            }
        }
    }
}
