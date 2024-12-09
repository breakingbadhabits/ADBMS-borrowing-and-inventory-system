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

            // Bind the CellClick event
            BorrowDataGrid.CellClick += BorrowDataGrid_CellClick;
        }


        public void loadBorrowDataGrid()
        {
            SqlConnection connection = DatabaseConnection.Instance.Connection;

            // Query to fetch items with specific conditions, excluding items needing maintenance
            string query = @"
    SELECT  
        item_name AS 'Name',
        item_type AS 'Type'
    FROM items
    WHERE 
        item_is_borrowed = 0 AND 
        item_is_maintenance = 0 AND 
        item_is_archived = 0 AND 
        item_condition != 'Need Maintenance'"; // Exclude items with condition "Need Maintenance"

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

                // Format the DataGridView for better presentation
                BorrowDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                BorrowDataGrid.ReadOnly = true; // Make it read-only to prevent editing
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
            FormNavigator.Navigate(this, new borrow_history());
        }

        private void ViewCurrent_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new BorrowerCurrent());
        }

        private void ViewBorrow_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate(this, new BorrowerView());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BorrowDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Highlight the selected row
                BorrowDataGrid.CurrentRow.Selected = true;
            }
        }


        private void ShowItemBorrowPopup(string itemName)
        {
            // Create overlay form
            Form overlay = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Black,
                Opacity = 0.5,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.Manual,
                Bounds = this.Bounds,
                Owner = this
            };

            try
            {
                overlay.Show();

                // Show the ItemBorrow form
                ItemBorrow itemBorrowPopup = new ItemBorrow(itemName)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = this
                };

                itemBorrowPopup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                overlay.Close();
            }
        }


        private void BorrowBt_Click(object sender, EventArgs e)
        {
            if (BorrowDataGrid.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = BorrowDataGrid.SelectedRows[0];

                // Retrieve the 'Name' value from the selected row
                string selectedName = selectedRow.Cells["Name"].Value.ToString();

                // Open the ItemBorrow popup form with the selected name
                ShowItemBorrowPopup(selectedName);
            }
            else
            {
                MessageBox.Show("Please select an item before borrowing.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BorrowDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BorrowerView_Load(object sender, EventArgs e)
        {

        }

        private void LogoutBt11_Click_1(object sender, EventArgs e)
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
    }
}


