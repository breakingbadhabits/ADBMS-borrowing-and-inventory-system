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
            this.LogoutBt = new System.Windows.Forms.Button();
            this.ViewBorrow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BorrowDataGrid = new System.Windows.Forms.DataGridView();
            this.BorrowBt = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bodoni MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "BORROW ITEM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ViewHistory
            // 
            this.ViewHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewHistory.Location = new System.Drawing.Point(12, 254);
            this.ViewHistory.Name = "ViewHistory";
            this.ViewHistory.Size = new System.Drawing.Size(167, 48);
            this.ViewHistory.TabIndex = 16;
            this.ViewHistory.Text = "BORROWED HISTORY";
            this.ViewHistory.UseVisualStyleBackColor = true;
            this.ViewHistory.Click += new System.EventHandler(this.ViewHistory_Click);
            // 
            // ViewCurrent
            // 
            this.ViewCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewCurrent.Location = new System.Drawing.Point(12, 191);
            this.ViewCurrent.Name = "ViewCurrent";
            this.ViewCurrent.Size = new System.Drawing.Size(167, 48);
            this.ViewCurrent.TabIndex = 15;
            this.ViewCurrent.Text = "CURRENT BORROWED";
            this.ViewCurrent.UseVisualStyleBackColor = true;
            this.ViewCurrent.Click += new System.EventHandler(this.ViewCurrent_Click);
            // 
            // LogoutBt
            // 
            this.LogoutBt.BackColor = System.Drawing.Color.Blue;
            this.LogoutBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBt.ForeColor = System.Drawing.Color.White;
            this.LogoutBt.Location = new System.Drawing.Point(798, 479);
            this.LogoutBt.Name = "LogoutBt";
            this.LogoutBt.Size = new System.Drawing.Size(100, 30);
            this.LogoutBt.TabIndex = 11;
            this.LogoutBt.Text = "LOGOUT";
            this.LogoutBt.UseVisualStyleBackColor = false;
            this.LogoutBt.Click += new System.EventHandler(this.LogoutBt11_Click);
            // 
            // ViewBorrow
            // 
            this.ViewBorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewBorrow.Location = new System.Drawing.Point(12, 128);
            this.ViewBorrow.Name = "ViewBorrow";
            this.ViewBorrow.Size = new System.Drawing.Size(167, 48);
            this.ViewBorrow.TabIndex = 11;
            this.ViewBorrow.Text = "BORROW";
            this.ViewBorrow.UseVisualStyleBackColor = true;
            this.ViewBorrow.Click += new System.EventHandler(this.ViewBorrow_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.BorrowBt);
            this.panel2.Controls.Add(this.BorrowDataGrid);
            this.panel2.Controls.Add(this.LogoutBt);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(193, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 521);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.ViewHistory);
            this.panel1.Controls.Add(this.ViewCurrent);
            this.panel1.Controls.Add(this.ViewBorrow);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 607);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.BorrowDataGrid.Location = new System.Drawing.Point(55, 91);
            this.BorrowDataGrid.Name = "BorrowDataGrid";
            this.BorrowDataGrid.RowHeadersWidth = 51;
            this.BorrowDataGrid.RowTemplate.Height = 24;
            this.BorrowDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.BorrowDataGrid.Size = new System.Drawing.Size(801, 299);
            this.BorrowDataGrid.TabIndex = 12;
            // 
            // BorrowBt
            // 
            this.BorrowBt.BackColor = System.Drawing.Color.Blue;
            this.BorrowBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorrowBt.Location = new System.Drawing.Point(55, 410);
            this.BorrowBt.Name = "BorrowBt";
            this.BorrowBt.Size = new System.Drawing.Size(105, 30);
            this.BorrowBt.TabIndex = 13;
            this.BorrowBt.Text = "BORROW";
            this.BorrowBt.UseVisualStyleBackColor = false;
            // 
            // BorrowerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 607);
            this.Controls.Add(this.panel1);
            this.Name = "BorrowerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrower View";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ViewHistory;
        private System.Windows.Forms.Button ViewCurrent;
        private System.Windows.Forms.Button LogoutBt;
        private System.Windows.Forms.Button ViewBorrow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView BorrowDataGrid;
        private System.Windows.Forms.Button BorrowBt;
    }
}