using System;
using System.Windows.Forms;

namespace AnotherSample
{
    partial class BorrowerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowerView));
            this.label1 = new System.Windows.Forms.Label();
            this.ViewHistory = new System.Windows.Forms.Button();
            this.ViewCurrent = new System.Windows.Forms.Button();
            this.ViewBorrow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BorrowDataGrid = new System.Windows.Forms.DataGridView();
            this.BorrowBt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogoutBt11 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bodoni MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(401, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 89);
            this.label1.TabIndex = 3;
            this.label1.Text = "BORROW ITEM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ViewHistory
            // 
            this.ViewHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewHistory.Location = new System.Drawing.Point(14, 318);
            this.ViewHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ViewHistory.Name = "ViewHistory";
            this.ViewHistory.Size = new System.Drawing.Size(188, 60);
            this.ViewHistory.TabIndex = 16;
            this.ViewHistory.Text = "BORROWED HISTORY";
            this.ViewHistory.UseVisualStyleBackColor = true;
            this.ViewHistory.Click += new System.EventHandler(this.ViewHistory_Click);
            // 
            // ViewCurrent
            // 
            this.ViewCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewCurrent.Location = new System.Drawing.Point(14, 239);
            this.ViewCurrent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ViewCurrent.Name = "ViewCurrent";
            this.ViewCurrent.Size = new System.Drawing.Size(188, 60);
            this.ViewCurrent.TabIndex = 15;
            this.ViewCurrent.Text = "CURRENT BORROWED";
            this.ViewCurrent.UseVisualStyleBackColor = true;
            this.ViewCurrent.Click += new System.EventHandler(this.ViewCurrent_Click);
            // 
            // ViewBorrow
            // 
            this.ViewBorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewBorrow.Location = new System.Drawing.Point(14, 160);
            this.ViewBorrow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ViewBorrow.Name = "ViewBorrow";
            this.ViewBorrow.Size = new System.Drawing.Size(188, 60);
            this.ViewBorrow.TabIndex = 11;
            this.ViewBorrow.Text = "BORROW";
            this.ViewBorrow.UseVisualStyleBackColor = true;
            this.ViewBorrow.Click += new System.EventHandler(this.ViewBorrow_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Bodoni MT Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(410, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(791, 62);
            this.label3.TabIndex = 2;
            this.label3.Text = "Equipment Borrowing Management System";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.BorrowDataGrid);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BorrowBt);
            this.panel2.Location = new System.Drawing.Point(217, 108);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1023, 518);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // BorrowDataGrid
            // 
            this.BorrowDataGrid.AllowUserToAddRows = false;
            this.BorrowDataGrid.AllowUserToDeleteRows = false;
            this.BorrowDataGrid.AllowUserToOrderColumns = true;
            this.BorrowDataGrid.AllowUserToResizeColumns = false;
            this.BorrowDataGrid.AllowUserToResizeRows = false;
            this.BorrowDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.BorrowDataGrid.BackgroundColor = System.Drawing.Color.LightBlue;
            this.BorrowDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BorrowDataGrid.Location = new System.Drawing.Point(62, 114);
            this.BorrowDataGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BorrowDataGrid.Name = "BorrowDataGrid";
            this.BorrowDataGrid.RowHeadersWidth = 51;
            this.BorrowDataGrid.RowTemplate.Height = 24;
            this.BorrowDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.BorrowDataGrid.Size = new System.Drawing.Size(922, 334);
            this.BorrowDataGrid.TabIndex = 12;
            this.BorrowDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BorrowDataGrid_CellContentClick);
            // 
            // BorrowBt
            // 
            this.BorrowBt.BackColor = System.Drawing.Color.Blue;
            this.BorrowBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorrowBt.Location = new System.Drawing.Point(80, 465);
            this.BorrowBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BorrowBt.Name = "BorrowBt";
            this.BorrowBt.Size = new System.Drawing.Size(118, 38);
            this.BorrowBt.TabIndex = 13;
            this.BorrowBt.Text = "BORROW";
            this.BorrowBt.UseVisualStyleBackColor = false;
            this.BorrowBt.Click += new System.EventHandler(this.BorrowBt_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.LogoutBt11);
            this.panel1.Controls.Add(this.ViewHistory);
            this.panel1.Controls.Add(this.ViewCurrent);
            this.panel1.Controls.Add(this.ViewBorrow);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1241, 695);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.LogoutBt11.TabIndex = 14;
            this.LogoutBt11.Text = "LOGOUT";
            this.LogoutBt11.UseVisualStyleBackColor = false;
            this.LogoutBt11.Click += new System.EventHandler(this.LogoutBt11_Click_1);
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
            // BorrowerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 695);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BorrowerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrower View";
            this.Load += new System.EventHandler(this.BorrowerView_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BorrowDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ViewHistory;
        private System.Windows.Forms.Button ViewCurrent;
        private System.Windows.Forms.Button ViewBorrow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView BorrowDataGrid;
        private System.Windows.Forms.Button BorrowBt;
        private Button LogoutBt11;
    }
}