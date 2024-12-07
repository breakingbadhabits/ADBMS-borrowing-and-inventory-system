using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherSample
{
    public partial class Form15 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["InventorySystemDB"].ConnectionString;

        public Form15()
        {
            InitializeComponent();
        }
        public string SelectedStockName { get; internal set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if there are linked items
                    string checkQuery = "SELECT COUNT(*) FROM items WHERE item_stock_id = (SELECT stock_id FROM stocks WHERE stock_name = @StockName)";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@StockName", SelectedStockName);

                        int linkedItemCount = (int)checkCommand.ExecuteScalar();

                        if (linkedItemCount > 0)
                        {
                            MessageBox.Show($"Cannot delete stock '{SelectedStockName}' because it has {linkedItemCount} linked item(s).", "Delete Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.DialogResult = DialogResult.Cancel; // Prevent deletion
                            return;
                        }
                    }

                    // Perform delete if no linked items
                    string deleteQuery = "DELETE FROM stocks WHERE stock_name = @StockName";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@StockName", SelectedStockName);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stock successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Indicate success
                        }
                        else
                        {
                            MessageBox.Show("Stock not found or already deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.DialogResult = DialogResult.Cancel; // Indicate failure
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
            finally
            {
                this.Close();
            }
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }
    }
}
