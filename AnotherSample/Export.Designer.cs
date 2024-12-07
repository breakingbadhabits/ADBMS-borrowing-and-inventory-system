namespace AnotherSample
{
    partial class Export
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
            this.ExportCheckList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExportBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExportCheckList
            // 
            this.ExportCheckList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportCheckList.FormattingEnabled = true;
            this.ExportCheckList.Items.AddRange(new object[] {
            "Users",
            "Transactions",
            "Items"});
            this.ExportCheckList.Location = new System.Drawing.Point(12, 107);
            this.ExportCheckList.Name = "ExportCheckList";
            this.ExportCheckList.Size = new System.Drawing.Size(528, 129);
            this.ExportCheckList.TabIndex = 1;
            this.ExportCheckList.SelectedIndexChanged += new System.EventHandler(this.ExportCheckList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bodoni MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "MAINTENANCE HISTORY";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ExportBt
            // 
            this.ExportBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportBt.Location = new System.Drawing.Point(31, 269);
            this.ExportBt.Name = "ExportBt";
            this.ExportBt.Size = new System.Drawing.Size(167, 48);
            this.ExportBt.TabIndex = 18;
            this.ExportBt.Text = "Export";
            this.ExportBt.UseVisualStyleBackColor = true;
            this.ExportBt.Click += new System.EventHandler(this.ExportBt_Click);
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 350);
            this.Controls.Add(this.ExportBt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportCheckList);
            this.Name = "Export";
            this.Text = "Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox ExportCheckList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExportBt;
    }
}