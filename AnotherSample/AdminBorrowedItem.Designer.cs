using System;

namespace AnotherSample
{
    partial class AdminBorrowedItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminBorrowedItem));
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ArchivesBt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LogoutBt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.HistoriesBt = new System.Windows.Forms.Button();
            this.BorrowedItemBt = new System.Windows.Forms.Button();
            this.BorrowerReqBt = new System.Windows.Forms.Button();
            this.MaintenanceBt = new System.Windows.Forms.Button();
            this.ReturnedBt = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.StocksBt = new System.Windows.Forms.Button();
            this.ItemsBt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NotifBt = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelNotifCount = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bodoni MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "BORROWED ITEMS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Borrower:";
            // 
            // ArchivesBt
            // 
            this.ArchivesBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArchivesBt.Location = new System.Drawing.Point(14, 588);
            this.ArchivesBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArchivesBt.Name = "ArchivesBt";
            this.ArchivesBt.Size = new System.Drawing.Size(188, 60);
            this.ArchivesBt.TabIndex = 17;
            this.ArchivesBt.Text = "ARCHIVES";
            this.ArchivesBt.UseVisualStyleBackColor = true;
            this.ArchivesBt.Click += new System.EventHandler(this.ArchivesBt10_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search Name:";
            // 
            // LogoutBt
            // 
            this.LogoutBt.BackColor = System.Drawing.Color.DarkRed;
            this.LogoutBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBt.ForeColor = System.Drawing.Color.White;
            this.LogoutBt.Location = new System.Drawing.Point(1110, 635);
            this.LogoutBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogoutBt.Name = "LogoutBt";
            this.LogoutBt.Size = new System.Drawing.Size(112, 38);
            this.LogoutBt.TabIndex = 11;
            this.LogoutBt.Text = "LOGOUT";
            this.LogoutBt.UseVisualStyleBackColor = false;
            this.LogoutBt.Click += new System.EventHandler(this.LogoutBt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Inventory:";
            // 
            // HistoriesBt
            // 
            this.HistoriesBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoriesBt.Location = new System.Drawing.Point(15, 520);
            this.HistoriesBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HistoriesBt.Name = "HistoriesBt";
            this.HistoriesBt.Size = new System.Drawing.Size(188, 60);
            this.HistoriesBt.TabIndex = 16;
            this.HistoriesBt.Text = "HISTORIES";
            this.HistoriesBt.UseVisualStyleBackColor = true;
            this.HistoriesBt.Click += new System.EventHandler(this.HistoriesBt9_Click);
            // 
            // BorrowedItemBt
            // 
            this.BorrowedItemBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowedItemBt.Location = new System.Drawing.Point(14, 452);
            this.BorrowedItemBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BorrowedItemBt.Name = "BorrowedItemBt";
            this.BorrowedItemBt.Size = new System.Drawing.Size(188, 60);
            this.BorrowedItemBt.TabIndex = 15;
            this.BorrowedItemBt.Text = "BORROWED ITEM";
            this.BorrowedItemBt.UseVisualStyleBackColor = true;
            this.BorrowedItemBt.Click += new System.EventHandler(this.BorrowedBt8_Click);
            // 
            // BorrowerReqBt
            // 
            this.BorrowerReqBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowerReqBt.Location = new System.Drawing.Point(14, 346);
            this.BorrowerReqBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BorrowerReqBt.Name = "BorrowerReqBt";
            this.BorrowerReqBt.Size = new System.Drawing.Size(188, 60);
            this.BorrowerReqBt.TabIndex = 14;
            this.BorrowerReqBt.Text = "BORROWER REQ";
            this.BorrowerReqBt.UseVisualStyleBackColor = true;
            this.BorrowerReqBt.Click += new System.EventHandler(this.RequestBt7_Click);
            // 
            // MaintenanceBt
            // 
            this.MaintenanceBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaintenanceBt.Location = new System.Drawing.Point(14, 279);
            this.MaintenanceBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaintenanceBt.Name = "MaintenanceBt";
            this.MaintenanceBt.Size = new System.Drawing.Size(188, 60);
            this.MaintenanceBt.TabIndex = 13;
            this.MaintenanceBt.Text = "MAINTENANCE";
            this.MaintenanceBt.UseVisualStyleBackColor = true;
            this.MaintenanceBt.Click += new System.EventHandler(this.MaintenanceBt6_Click);
            // 
            // ReturnedBt
            // 
            this.ReturnedBt.BackColor = System.Drawing.Color.Green;
            this.ReturnedBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnedBt.ForeColor = System.Drawing.Color.White;
            this.ReturnedBt.Location = new System.Drawing.Point(822, 461);
            this.ReturnedBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReturnedBt.Name = "ReturnedBt";
            this.ReturnedBt.Size = new System.Drawing.Size(124, 38);
            this.ReturnedBt.TabIndex = 11;
            this.ReturnedBt.Text = "RETURNED";
            this.ReturnedBt.UseVisualStyleBackColor = false;
            this.ReturnedBt.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(695, 15);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(272, 26);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // StocksBt
            // 
            this.StocksBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StocksBt.Location = new System.Drawing.Point(14, 211);
            this.StocksBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StocksBt.Name = "StocksBt";
            this.StocksBt.Size = new System.Drawing.Size(188, 60);
            this.StocksBt.TabIndex = 12;
            this.StocksBt.Text = "STOCKS";
            this.StocksBt.UseVisualStyleBackColor = true;
            this.StocksBt.Click += new System.EventHandler(this.StockBt5_Click);
            // 
            // ItemsBt
            // 
            this.ItemsBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsBt.Location = new System.Drawing.Point(14, 144);
            this.ItemsBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ItemsBt.Name = "ItemsBt";
            this.ItemsBt.Size = new System.Drawing.Size(188, 60);
            this.ItemsBt.TabIndex = 11;
            this.ItemsBt.Text = "ITEMS";
            this.ItemsBt.UseVisualStyleBackColor = true;
            this.ItemsBt.Click += new System.EventHandler(this.ItemBt4_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Bodoni MT Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(410, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(574, 62);
            this.label3.TabIndex = 2;
            this.label3.Text = "Equipment Borrowing Management System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.ReturnedBt);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(217, 108);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1023, 518);
            this.panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(209, 128);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 26);
            this.textBox1.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(75, 162);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(892, 291);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.labelNotifCount);
            this.panel1.Controls.Add(this.NotifBt);
            this.panel1.Controls.Add(this.LogoutBt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ArchivesBt);
            this.panel1.Controls.Add(this.HistoriesBt);
            this.panel1.Controls.Add(this.BorrowedItemBt);
            this.panel1.Controls.Add(this.BorrowerReqBt);
            this.panel1.Controls.Add(this.MaintenanceBt);
            this.panel1.Controls.Add(this.StocksBt);
            this.panel1.Controls.Add(this.ItemsBt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1241, 692);
            this.panel1.TabIndex = 3;
            // 
            // NotifBt
            // 
            this.NotifBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NotifBt.BackgroundImage")));
            this.NotifBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NotifBt.Location = new System.Drawing.Point(1150, 15);
            this.NotifBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NotifBt.Name = "NotifBt";
            this.NotifBt.Size = new System.Drawing.Size(78, 80);
            this.NotifBt.TabIndex = 12;
            this.NotifBt.UseVisualStyleBackColor = true;
            this.NotifBt.Click += new System.EventHandler(this.NotifBt_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelNotifCount
            // 
            this.labelNotifCount.AutoSize = true;
            this.labelNotifCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotifCount.Location = new System.Drawing.Point(1203, 17);
            this.labelNotifCount.Name = "labelNotifCount";
            this.labelNotifCount.Size = new System.Drawing.Size(23, 25);
            this.labelNotifCount.TabIndex = 21;
            this.labelNotifCount.Text = "1";
            this.labelNotifCount.Click += new System.EventHandler(this.labelNotifCount_Click);
            // 
            // AdminBorrowedItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 692);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminBorrowedItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrower";
            this.Load += new System.EventHandler(this.Borrower_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ArchivesBt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LogoutBt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button HistoriesBt;
        private System.Windows.Forms.Button BorrowedItemBt;
        private System.Windows.Forms.Button BorrowerReqBt;
        private System.Windows.Forms.Button MaintenanceBt;
        private System.Windows.Forms.Button ReturnedBt;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button StocksBt;
        private System.Windows.Forms.Button ItemsBt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NotifBt;
        private System.Windows.Forms.Label labelNotifCount;
    }
}