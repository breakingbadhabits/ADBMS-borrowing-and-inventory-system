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
    public partial class HistoryAdminF7 : Form
    {
        public HistoryAdminF7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ItemBt4_Click(object sender, EventArgs e)
        {
            {
                // Create an instance of the stock form
                ItemsAdminF3 itemForm = new ItemsAdminF3();

                // Hide the current form
                this.Hide();

                // Show the stock form as a modal dialog
                itemForm.ShowDialog();

                // Show the current form again when returning from the stock form
                this.Close();
            }
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

        private void MaintenanceBt6_Click(object sender, EventArgs e)
        {
            {
                // Create an instance of the stock form
                MaintenanceAdminF6 maintenanceForm = new MaintenanceAdminF6();

                // Hide the current form
                this.Hide();

                // Show the stock form as a modal dialog
                maintenanceForm.ShowDialog();

                // Show the current form again when returning from the stock form
                this.Close();
            }
        }

        private void ArchivesBt10_Click(object sender, EventArgs e)
        {
            {
                // Create an instance of the stock form
                ArchiveAdminF4 archiveForm = new ArchiveAdminF4();

                // Hide the current form
                this.Hide();

                // Show the stock form as a modal dialog
                archiveForm.ShowDialog();

                // Show the current form again when returning from the stock form
                this.Close();
            }
        }
    }
}
