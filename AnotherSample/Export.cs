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
using ClosedXML;

namespace AnotherSample
{
    public partial class Export : Form
    {
        public Export()
        {
            InitializeComponent();
        }

        private void ExportCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ExportBt_Click(object sender, EventArgs e)
        {
            if (ExportCheckList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one table to export.", "No Tables Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                Title = "Save Exported Data",
                FileName = "ExportedData.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Loop through selected tables
                        foreach (var item in ExportCheckList.CheckedItems)
                        {
                            string tableName = item.ToString();
                            string query = $"SELECT * FROM [{tableName}]";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable tableData = new DataTable();
                                adapter.Fill(tableData);

                                // Add data to a worksheet
                                var worksheet = workbook.Worksheets.Add(tableName);
                                worksheet.Cell(1, 1).InsertTable(tableData);
                                worksheet.Columns().AdjustToContents();
                            }
                        }

                        // Save the workbook
                        workbook.SaveAs(filePath);
                        MessageBox.Show($"Data exported successfully to {filePath}.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while exporting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ExportMainLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
