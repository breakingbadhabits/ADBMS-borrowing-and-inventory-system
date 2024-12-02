    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace AnotherSample
    {
        public partial class MaintenanceAdminF6 : Form
        {
            public MaintenanceAdminF6()
            {
                InitializeComponent();
            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void StockBt5_Click(object sender, EventArgs e)
            {
                {
                    // Create an instance of the stock form
                    StocksAdminF8 stockForm = new StocksAdminF8();

                    // Hide the current form
                    this.Hide();

                    // Show the stock form as a modal dialog
                    stockForm.ShowDialog();

                    // Show the current form again when returning from the stock form
                    this.Close();
                }
            }

            private void ItemBt4_Click(object sender, EventArgs e)
            {
                {
                    // Create an instance of the stock form
                    ItemsAdminF3 itemsAdmin = new ItemsAdminF3();

                    // Hide the current form
                    this.Hide();

                    // Show the stock form as a modal dialog
                    itemsAdmin.ShowDialog();

                    // Show the current form again when returning from the stock form
                    this.Close();
                }
            }

            private void HistoriesBt9_Click(object sender, EventArgs e)
            {
                {
                    // Create an instance of the stock form
                    HistoryAdminF7 historyForm = new HistoryAdminF7();

                    // Hide the current form
                    this.Hide();

                    // Show the stock form as a modal dialog
                    historyForm.ShowDialog();

                    // Show the current form again when returning from the stock form
                    this.Close();
                }
            }

            private void MaintenanceBt6_Click(object sender, EventArgs e)
            {

            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            
            }
        }
    }
