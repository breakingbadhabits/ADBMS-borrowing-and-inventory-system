﻿using System.Windows.Forms;

namespace AnotherSample
{
    partial class StocksAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StocksAdmin));
            this.ArchivesBt10 = new System.Windows.Forms.Button();
            this.BorrowedBt8 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NotifBt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LogoutBt11 = new System.Windows.Forms.Button();
            this.HistoriesBt9 = new System.Windows.Forms.Button();
            this.RequestBt7 = new System.Windows.Forms.Button();
            this.MaintenanceBt6 = new System.Windows.Forms.Button();
            this.StockBt5 = new System.Windows.Forms.Button();
            this.ItemBt4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ArchiveBt3 = new System.Windows.Forms.Button();
            this.DeleteBt3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNotifCount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ArchivesBt10
            // 
            this.ArchivesBt10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArchivesBt10.Location = new System.Drawing.Point(14, 588);
            this.ArchivesBt10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArchivesBt10.Name = "ArchivesBt10";
            this.ArchivesBt10.Size = new System.Drawing.Size(188, 60);
            this.ArchivesBt10.TabIndex = 17;
            this.ArchivesBt10.Text = "ARCHIVES";
            this.ArchivesBt10.UseVisualStyleBackColor = true;
            this.ArchivesBt10.Click += new System.EventHandler(this.ArchivesBt10_Click);
            // 
            // BorrowedBt8
            // 
            this.BorrowedBt8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowedBt8.Location = new System.Drawing.Point(14, 452);
            this.BorrowedBt8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BorrowedBt8.Name = "BorrowedBt8";
            this.BorrowedBt8.Size = new System.Drawing.Size(188, 60);
            this.BorrowedBt8.TabIndex = 15;
            this.BorrowedBt8.Text = "BORROWED ITEM";
            this.BorrowedBt8.UseVisualStyleBackColor = true;
            this.BorrowedBt8.Click += new System.EventHandler(this.BorrowedBt8_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.labelNotifCount);
            this.panel1.Controls.Add(this.NotifBt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LogoutBt11);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1241, 692);
            this.panel1.TabIndex = 4;
            // 
            // NotifBt
            // 
            this.NotifBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NotifBt.BackgroundImage")));
            this.NotifBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NotifBt.Location = new System.Drawing.Point(1150, 15);
            this.NotifBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NotifBt.Name = "NotifBt";
            this.NotifBt.Size = new System.Drawing.Size(78, 80);
            this.NotifBt.TabIndex = 13;
            this.NotifBt.UseVisualStyleBackColor = true;
            this.NotifBt.Click += new System.EventHandler(this.NotifBt_Click);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Inventory:";
            // 
            // LogoutBt11
            // 
            this.LogoutBt11.BackColor = System.Drawing.Color.DarkRed;
            this.LogoutBt11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBt11.ForeColor = System.Drawing.Color.White;
            this.LogoutBt11.Location = new System.Drawing.Point(1110, 635);
            this.LogoutBt11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogoutBt11.Name = "LogoutBt11";
            this.LogoutBt11.Size = new System.Drawing.Size(112, 38);
            this.LogoutBt11.TabIndex = 11;
            this.LogoutBt11.Text = "LOGOUT";
            this.LogoutBt11.UseVisualStyleBackColor = false;
            this.LogoutBt11.Click += new System.EventHandler(this.LogoutBt11_Click);
            // 
            // HistoriesBt9
            // 
            this.HistoriesBt9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoriesBt9.Location = new System.Drawing.Point(15, 520);
            this.HistoriesBt9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HistoriesBt9.Name = "HistoriesBt9";
            this.HistoriesBt9.Size = new System.Drawing.Size(188, 60);
            this.HistoriesBt9.TabIndex = 16;
            this.HistoriesBt9.Text = "HISTORIES";
            this.HistoriesBt9.UseVisualStyleBackColor = true;
            this.HistoriesBt9.Click += new System.EventHandler(this.HistoriesBt9_Click);
            // 
            // RequestBt7
            // 
            this.RequestBt7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestBt7.Location = new System.Drawing.Point(14, 346);
            this.RequestBt7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RequestBt7.Name = "RequestBt7";
            this.RequestBt7.Size = new System.Drawing.Size(188, 60);
            this.RequestBt7.TabIndex = 14;
            this.RequestBt7.Text = "BORROWER REQ";
            this.RequestBt7.UseVisualStyleBackColor = true;
            this.RequestBt7.Click += new System.EventHandler(this.RequestBt7_Click);
            // 
            // MaintenanceBt6
            // 
            this.MaintenanceBt6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaintenanceBt6.Location = new System.Drawing.Point(14, 279);
            this.MaintenanceBt6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaintenanceBt6.Name = "MaintenanceBt6";
            this.MaintenanceBt6.Size = new System.Drawing.Size(188, 60);
            this.MaintenanceBt6.TabIndex = 13;
            this.MaintenanceBt6.Text = "MAINTENANCE";
            this.MaintenanceBt6.UseVisualStyleBackColor = true;
            this.MaintenanceBt6.Click += new System.EventHandler(this.MaintenanceBt6_Click);
            // 
            // StockBt5
            // 
            this.StockBt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockBt5.Location = new System.Drawing.Point(14, 211);
            this.StockBt5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StockBt5.Name = "StockBt5";
            this.StockBt5.Size = new System.Drawing.Size(188, 60);
            this.StockBt5.TabIndex = 12;
            this.StockBt5.Text = "STOCKS";
            this.StockBt5.UseVisualStyleBackColor = true;
            this.StockBt5.Click += new System.EventHandler(this.StockBt5_Click);
            // 
            // ItemBt4
            // 
            this.ItemBt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemBt4.Location = new System.Drawing.Point(14, 144);
            this.ItemBt4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ItemBt4.Name = "ItemBt4";
            this.ItemBt4.Size = new System.Drawing.Size(188, 60);
            this.ItemBt4.TabIndex = 11;
            this.ItemBt4.Text = "ITEMS";
            this.ItemBt4.UseVisualStyleBackColor = true;
            this.ItemBt4.Click += new System.EventHandler(this.ItemBt4_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.ArchiveBt3);
            this.panel2.Controls.Add(this.DeleteBt3);
            this.panel2.Controls.Add(this.button1);
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
            // ArchiveBt3
            // 
            this.ArchiveBt3.BackColor = System.Drawing.Color.Red;
            this.ArchiveBt3.ForeColor = System.Drawing.Color.White;
            this.ArchiveBt3.Location = new System.Drawing.Point(853, 464);
            this.ArchiveBt3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArchiveBt3.Name = "ArchiveBt3";
            this.ArchiveBt3.Size = new System.Drawing.Size(98, 31);
            this.ArchiveBt3.TabIndex = 14;
            this.ArchiveBt3.Text = "DELETE";
            this.ArchiveBt3.UseVisualStyleBackColor = false;
            this.ArchiveBt3.Click += new System.EventHandler(this.ArchiveBt3_Click);
            // 
            // DeleteBt3
            // 
            this.DeleteBt3.BackColor = System.Drawing.Color.Red;
            this.DeleteBt3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DeleteBt3.Location = new System.Drawing.Point(955, 580);
            this.DeleteBt3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.DeleteBt3.Name = "DeleteBt3";
            this.DeleteBt3.Size = new System.Drawing.Size(90, 31);
            this.DeleteBt3.TabIndex = 13;
            this.DeleteBt3.Text = "DELETE";
            this.DeleteBt3.UseVisualStyleBackColor = false;
            this.DeleteBt3.Click += new System.EventHandler(this.DeleteBt3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(753, 464);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(210, 128);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 26);
            this.textBox1.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(53, 162);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.Size = new System.Drawing.Size(922, 291);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bodoni MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(436, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "STOCKS";
            // 
            // labelNotifCount
            // 
            this.labelNotifCount.AutoSize = true;
            this.labelNotifCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotifCount.Location = new System.Drawing.Point(1203, 16);
            this.labelNotifCount.Name = "labelNotifCount";
            this.labelNotifCount.Size = new System.Drawing.Size(23, 25);
            this.labelNotifCount.TabIndex = 21;
            this.labelNotifCount.Text = "1";
            this.labelNotifCount.Click += new System.EventHandler(this.labelNotifCount_Click);
            // 
            // StocksAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 692);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StocksAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StocksAdmin";
            this.Load += new System.EventHandler(this.StocksAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ArchivesBt10;
        private System.Windows.Forms.Button BorrowedBt8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button HistoriesBt9;
        private System.Windows.Forms.Button RequestBt7;
        private System.Windows.Forms.Button MaintenanceBt6;
        private System.Windows.Forms.Button StockBt5;
        private System.Windows.Forms.Button ItemBt4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button LogoutBt11;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DeleteBt3;
        private Button ArchiveBt3;
        private Button NotifBt;
        private Label labelNotifCount;
    }
}