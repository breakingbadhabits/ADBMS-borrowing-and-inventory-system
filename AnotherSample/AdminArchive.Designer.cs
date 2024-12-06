namespace AnotherSample
{
    partial class AdminArchive
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminArchive));
            this.LogoutBt11 = new System.Windows.Forms.Button();
            this.HistoriesBt9 = new System.Windows.Forms.Button();
            this.BorrowedBt8 = new System.Windows.Forms.Button();
            this.RequestBt7 = new System.Windows.Forms.Button();
            this.MaintenanceBt6 = new System.Windows.Forms.Button();
            this.StockBt5 = new System.Windows.Forms.Button();
            this.ItemBt4 = new System.Windows.Forms.Button();
            this.ArchiveBt3 = new System.Windows.Forms.Button();
            this.AddBt1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory_systemDataSet = new AnotherSample.inventory_systemDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ArchivesBt10 = new System.Windows.Forms.Button();
            this.itemsTableAdapter = new AnotherSample.inventory_systemDataSetTableAdapters.itemsTableAdapter();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemstockidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itembrandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemserialnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemconditionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemisborrowedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemisarchivedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory_systemDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogoutBt11
            // 
            this.LogoutBt11.BackColor = System.Drawing.Color.DarkRed;
            this.LogoutBt11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBt11.ForeColor = System.Drawing.Color.White;
            this.LogoutBt11.Location = new System.Drawing.Point(987, 508);
            this.LogoutBt11.Name = "LogoutBt11";
            this.LogoutBt11.Size = new System.Drawing.Size(100, 30);
            this.LogoutBt11.TabIndex = 11;
            this.LogoutBt11.Text = "LOGOUT";
            this.LogoutBt11.UseVisualStyleBackColor = false;
            this.LogoutBt11.Click += new System.EventHandler(this.LogoutBt11_Click);
            // 
            // HistoriesBt9
            // 
            this.HistoriesBt9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoriesBt9.Location = new System.Drawing.Point(13, 416);
            this.HistoriesBt9.Name = "HistoriesBt9";
            this.HistoriesBt9.Size = new System.Drawing.Size(167, 48);
            this.HistoriesBt9.TabIndex = 16;
            this.HistoriesBt9.Text = "HISTORIES";
            this.HistoriesBt9.UseVisualStyleBackColor = true;
            this.HistoriesBt9.Click += new System.EventHandler(this.HistoriesBt9_Click);
            // 
            // BorrowedBt8
            // 
            this.BorrowedBt8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowedBt8.Location = new System.Drawing.Point(12, 362);
            this.BorrowedBt8.Name = "BorrowedBt8";
            this.BorrowedBt8.Size = new System.Drawing.Size(167, 48);
            this.BorrowedBt8.TabIndex = 15;
            this.BorrowedBt8.Text = "BORROWED ITEM";
            this.BorrowedBt8.UseVisualStyleBackColor = true;
            this.BorrowedBt8.Click += new System.EventHandler(this.BorrowedBt8_Click);
            // 
            // RequestBt7
            // 
            this.RequestBt7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestBt7.Location = new System.Drawing.Point(12, 277);
            this.RequestBt7.Name = "RequestBt7";
            this.RequestBt7.Size = new System.Drawing.Size(167, 48);
            this.RequestBt7.TabIndex = 14;
            this.RequestBt7.Text = "BORROWER REQ";
            this.RequestBt7.UseVisualStyleBackColor = true;
            this.RequestBt7.Click += new System.EventHandler(this.RequestBt7_Click);
            // 
            // MaintenanceBt6
            // 
            this.MaintenanceBt6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaintenanceBt6.Location = new System.Drawing.Point(12, 223);
            this.MaintenanceBt6.Name = "MaintenanceBt6";
            this.MaintenanceBt6.Size = new System.Drawing.Size(167, 48);
            this.MaintenanceBt6.TabIndex = 13;
            this.MaintenanceBt6.Text = "MAINTENANCE";
            this.MaintenanceBt6.UseVisualStyleBackColor = true;
            this.MaintenanceBt6.Click += new System.EventHandler(this.MaintenanceBt6_Click);
            // 
            // StockBt5
            // 
            this.StockBt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockBt5.Location = new System.Drawing.Point(12, 169);
            this.StockBt5.Name = "StockBt5";
            this.StockBt5.Size = new System.Drawing.Size(167, 48);
            this.StockBt5.TabIndex = 12;
            this.StockBt5.Text = "STOCKS";
            this.StockBt5.UseVisualStyleBackColor = true;
            this.StockBt5.Click += new System.EventHandler(this.StockBt5_Click);
            // 
            // ItemBt4
            // 
            this.ItemBt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemBt4.Location = new System.Drawing.Point(12, 115);
            this.ItemBt4.Name = "ItemBt4";
            this.ItemBt4.Size = new System.Drawing.Size(167, 48);
            this.ItemBt4.TabIndex = 11;
            this.ItemBt4.Text = "ITEMS";
            this.ItemBt4.UseVisualStyleBackColor = true;
            this.ItemBt4.Click += new System.EventHandler(this.ItemBt4_Click);
            // 
            // ArchiveBt3
            // 
            this.ArchiveBt3.BackColor = System.Drawing.Color.Red;
            this.ArchiveBt3.ForeColor = System.Drawing.Color.White;
            this.ArchiveBt3.Location = new System.Drawing.Point(757, 369);
            this.ArchiveBt3.Name = "ArchiveBt3";
            this.ArchiveBt3.Size = new System.Drawing.Size(103, 30);
            this.ArchiveBt3.TabIndex = 10;
            this.ArchiveBt3.Text = "DELETE";
            this.ArchiveBt3.UseVisualStyleBackColor = false;
            this.ArchiveBt3.Click += new System.EventHandler(this.ArchiveBt3_Click);
            // 
            // AddBt1
            // 
            this.AddBt1.BackColor = System.Drawing.Color.Green;
            this.AddBt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBt1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AddBt1.Location = new System.Drawing.Point(750, 94);
            this.AddBt1.Name = "AddBt1";
            this.AddBt1.Size = new System.Drawing.Size(110, 30);
            this.AddBt1.TabIndex = 8;
            this.AddBt1.Text = "RESTORE";
            this.AddBt1.UseVisualStyleBackColor = false;
            this.AddBt1.Click += new System.EventHandler(this.AddBt1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(618, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(242, 22);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search Item:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bodoni MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(401, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "ARCHIVES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Bodoni MT Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(364, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(510, 50);
            this.label3.TabIndex = 2;
            this.label3.Text = "Equipment Borrowing Management System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.ArchiveBt3);
            this.panel2.Controls.Add(this.AddBt1);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(193, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 414);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemidDataGridViewTextBoxColumn,
            this.itemstockidDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.itembrandDataGridViewTextBoxColumn,
            this.itemserialnumberDataGridViewTextBoxColumn,
            this.itemconditionDataGridViewTextBoxColumn,
            this.itemisborrowedDataGridViewCheckBoxColumn,
            this.itemisarchivedDataGridViewCheckBoxColumn,
            this.itemtypeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.itemsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(47, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(820, 233);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "items";
            this.itemsBindingSource.DataSource = this.inventory_systemDataSet;
            // 
            // inventory_systemDataSet
            // 
            this.inventory_systemDataSet.DataSetName = "inventory_systemDataSet";
            this.inventory_systemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.LogoutBt11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ArchivesBt10);
            this.panel1.Controls.Add(this.HistoriesBt9);
            this.panel1.Controls.Add(this.BorrowedBt8);
            this.panel1.Controls.Add(this.RequestBt7);
            this.panel1.Controls.Add(this.MaintenanceBt6);
            this.panel1.Controls.Add(this.StockBt5);
            this.panel1.Controls.Add(this.ItemBt4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 607);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Borrower:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Inventory:";
            // 
            // ArchivesBt10
            // 
            this.ArchivesBt10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArchivesBt10.Location = new System.Drawing.Point(12, 470);
            this.ArchivesBt10.Name = "ArchivesBt10";
            this.ArchivesBt10.Size = new System.Drawing.Size(167, 48);
            this.ArchivesBt10.TabIndex = 17;
            this.ArchivesBt10.Text = "ARCHIVES";
            this.ArchivesBt10.UseVisualStyleBackColor = true;
            this.ArchivesBt10.Click += new System.EventHandler(this.ArchivesBt10_Click);
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "item_id";
            this.itemidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Width = 125;
            // 
            // itemstockidDataGridViewTextBoxColumn
            // 
            this.itemstockidDataGridViewTextBoxColumn.DataPropertyName = "item_stock_id";
            this.itemstockidDataGridViewTextBoxColumn.HeaderText = "item_stock_id";
            this.itemstockidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.itemstockidDataGridViewTextBoxColumn.Name = "itemstockidDataGridViewTextBoxColumn";
            this.itemstockidDataGridViewTextBoxColumn.Width = 125;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "item_name";
            this.itemnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // itembrandDataGridViewTextBoxColumn
            // 
            this.itembrandDataGridViewTextBoxColumn.DataPropertyName = "item_brand";
            this.itembrandDataGridViewTextBoxColumn.HeaderText = "item_brand";
            this.itembrandDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.itembrandDataGridViewTextBoxColumn.Name = "itembrandDataGridViewTextBoxColumn";
            this.itembrandDataGridViewTextBoxColumn.Width = 125;
            // 
            // itemserialnumberDataGridViewTextBoxColumn
            // 
            this.itemserialnumberDataGridViewTextBoxColumn.DataPropertyName = "item_serial_number";
            this.itemserialnumberDataGridViewTextBoxColumn.HeaderText = "item_serial_number";
            this.itemserialnumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.itemserialnumberDataGridViewTextBoxColumn.Name = "itemserialnumberDataGridViewTextBoxColumn";
            this.itemserialnumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // itemconditionDataGridViewTextBoxColumn
            // 
            this.itemconditionDataGridViewTextBoxColumn.DataPropertyName = "item_condition";
            this.itemconditionDataGridViewTextBoxColumn.HeaderText = "item_condition";
            this.itemconditionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.itemconditionDataGridViewTextBoxColumn.Name = "itemconditionDataGridViewTextBoxColumn";
            this.itemconditionDataGridViewTextBoxColumn.Width = 125;
            // 
            // itemisborrowedDataGridViewCheckBoxColumn
            // 
            this.itemisborrowedDataGridViewCheckBoxColumn.DataPropertyName = "item_is_borrowed";
            this.itemisborrowedDataGridViewCheckBoxColumn.HeaderText = "item_is_borrowed";
            this.itemisborrowedDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.itemisborrowedDataGridViewCheckBoxColumn.Name = "itemisborrowedDataGridViewCheckBoxColumn";
            this.itemisborrowedDataGridViewCheckBoxColumn.Width = 125;
            // 
            // itemisarchivedDataGridViewCheckBoxColumn
            // 
            this.itemisarchivedDataGridViewCheckBoxColumn.DataPropertyName = "item_is_archived";
            this.itemisarchivedDataGridViewCheckBoxColumn.HeaderText = "item_is_archived";
            this.itemisarchivedDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.itemisarchivedDataGridViewCheckBoxColumn.Name = "itemisarchivedDataGridViewCheckBoxColumn";
            this.itemisarchivedDataGridViewCheckBoxColumn.Width = 125;
            // 
            // itemtypeDataGridViewTextBoxColumn
            // 
            this.itemtypeDataGridViewTextBoxColumn.DataPropertyName = "item_type";
            this.itemtypeDataGridViewTextBoxColumn.HeaderText = "item_type";
            this.itemtypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.itemtypeDataGridViewTextBoxColumn.Name = "itemtypeDataGridViewTextBoxColumn";
            this.itemtypeDataGridViewTextBoxColumn.Width = 125;
            // 
            // AdminArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 607);
            this.Controls.Add(this.panel1);
            this.Name = "AdminArchive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArchivesAdmin";
            this.Load += new System.EventHandler(this.ArchiveAdminF4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory_systemDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LogoutBt11;
        private System.Windows.Forms.Button HistoriesBt9;
        private System.Windows.Forms.Button BorrowedBt8;
        private System.Windows.Forms.Button RequestBt7;
        private System.Windows.Forms.Button MaintenanceBt6;
        private System.Windows.Forms.Button StockBt5;
        private System.Windows.Forms.Button ItemBt4;
        private System.Windows.Forms.Button ArchiveBt3;
        private System.Windows.Forms.Button AddBt1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ArchivesBt10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private inventory_systemDataSet inventory_systemDataSet;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private inventory_systemDataSetTableAdapters.itemsTableAdapter itemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemstockidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itembrandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemserialnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemconditionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn itemisborrowedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn itemisarchivedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtypeDataGridViewTextBoxColumn;
    }
}