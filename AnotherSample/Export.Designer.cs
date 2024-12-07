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
            this.ExportMainLabel = new System.Windows.Forms.Label();
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
            this.ExportCheckList.Location = new System.Drawing.Point(42, 92);
            this.ExportCheckList.Name = "ExportCheckList";
            this.ExportCheckList.Size = new System.Drawing.Size(556, 179);
            this.ExportCheckList.TabIndex = 0;
            this.ExportCheckList.SelectedIndexChanged += new System.EventHandler(this.ExportCheckList_SelectedIndexChanged);
            // 
            // ExportMainLabel
            // 
            this.ExportMainLabel.Font = new System.Drawing.Font("Bodoni MT Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportMainLabel.Location = new System.Drawing.Point(12, 18);
            this.ExportMainLabel.Name = "ExportMainLabel";
            this.ExportMainLabel.Size = new System.Drawing.Size(528, 50);
            this.ExportMainLabel.TabIndex = 3;
            this.ExportMainLabel.Text = "Export Data into Excel Files";
            this.ExportMainLabel.Click += new System.EventHandler(this.ExportMainLabel_Click);
            // 
            // ExportBt
            // 
            this.ExportBt.BackColor = System.Drawing.Color.White;
            this.ExportBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportBt.Location = new System.Drawing.Point(57, 304);
            this.ExportBt.Name = "ExportBt";
            this.ExportBt.Size = new System.Drawing.Size(107, 37);
            this.ExportBt.TabIndex = 22;
            this.ExportBt.Text = "EXPORT";
            this.ExportBt.UseVisualStyleBackColor = false;
            this.ExportBt.Click += new System.EventHandler(this.ExportBt_Click);
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 381);
            this.Controls.Add(this.ExportBt);
            this.Controls.Add(this.ExportMainLabel);
            this.Controls.Add(this.ExportCheckList);
            this.Name = "Export";
            this.Text = "Export";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ExportCheckList;
        private System.Windows.Forms.Label ExportMainLabel;
        private System.Windows.Forms.Button ExportBt;
    }
}