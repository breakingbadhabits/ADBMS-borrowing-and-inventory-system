namespace AnotherSample
{
    partial class SignUpF2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpF2));
            this.RoleComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.BirthdayPicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ContactNumberBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UliBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.EyeOpenButton = new System.Windows.Forms.Button();
            this.EyeCloseButton = new System.Windows.Forms.Button();
            this.SignUpButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // RoleComboBox
            // 
            this.RoleComboBox.FormattingEnabled = true;
            this.RoleComboBox.Items.AddRange(new object[] {
            "Student"});
            this.RoleComboBox.Location = new System.Drawing.Point(295, 401);
            this.RoleComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RoleComboBox.Name = "RoleComboBox";
            this.RoleComboBox.Size = new System.Drawing.Size(246, 28);
            this.RoleComboBox.TabIndex = 6;
            this.RoleComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.BirthdayPicker);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.AddressBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ContactNumberBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.NameBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.UliBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.EyeOpenButton);
            this.panel1.Controls.Add(this.EyeCloseButton);
            this.panel1.Controls.Add(this.SignUpButton);
            this.panel1.Controls.Add(this.RoleComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PasswordBox);
            this.panel1.Controls.Add(this.UsernameBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 562);
            this.panel1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(544, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 25);
            this.label9.TabIndex = 24;
            this.label9.Text = "Birthday:";
            // 
            // BirthdayPicker
            // 
            this.BirthdayPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BirthdayPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BirthdayPicker.Location = new System.Drawing.Point(547, 229);
            this.BirthdayPicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BirthdayPicker.Name = "BirthdayPicker";
            this.BirthdayPicker.Size = new System.Drawing.Size(246, 41);
            this.BirthdayPicker.TabIndex = 23;
            this.BirthdayPicker.Value = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.BirthdayPicker.ValueChanged += new System.EventHandler(this.BirthdayPicker_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "Address:";
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(22, 314);
            this.AddressBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddressBox.Multiline = true;
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(770, 45);
            this.AddressBox.TabIndex = 21;
            this.AddressBox.TextChanged += new System.EventHandler(this.AddressBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(282, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Contact Number:";
            // 
            // ContactNumberBox
            // 
            this.ContactNumberBox.Location = new System.Drawing.Point(285, 228);
            this.ContactNumberBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ContactNumberBox.Multiline = true;
            this.ContactNumberBox.Name = "ContactNumberBox";
            this.ContactNumberBox.Size = new System.Drawing.Size(246, 45);
            this.ContactNumberBox.TabIndex = 19;
            this.ContactNumberBox.TextChanged += new System.EventHandler(this.ContactNumberBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Name:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(22, 228);
            this.NameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NameBox.Multiline = true;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(246, 45);
            this.NameBox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(282, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Student No. / ULI:";
            // 
            // UliBox
            // 
            this.UliBox.Location = new System.Drawing.Point(285, 151);
            this.UliBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UliBox.Multiline = true;
            this.UliBox.Name = "UliBox";
            this.UliBox.Size = new System.Drawing.Size(246, 45);
            this.UliBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Role:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(326, 498);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(187, 20);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Already have an accoun?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Bodoni MT Condensed", 18F);
            this.label3.Location = new System.Drawing.Point(368, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(425, 54);
            this.label3.TabIndex = 11;
            this.label3.Text = "Equipment Borrowing Management System";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(33, 31);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(177, 58);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // EyeOpenButton
            // 
            this.EyeOpenButton.Image = ((System.Drawing.Image)(resources.GetObject("EyeOpenButton.Image")));
            this.EyeOpenButton.Location = new System.Drawing.Point(752, 151);
            this.EyeOpenButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EyeOpenButton.Name = "EyeOpenButton";
            this.EyeOpenButton.Size = new System.Drawing.Size(42, 46);
            this.EyeOpenButton.TabIndex = 1;
            this.EyeOpenButton.UseVisualStyleBackColor = true;
            this.EyeOpenButton.Click += new System.EventHandler(this.EyeOpenButton_Click);
            // 
            // EyeCloseButton
            // 
            this.EyeCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("EyeCloseButton.Image")));
            this.EyeCloseButton.Location = new System.Drawing.Point(752, 151);
            this.EyeCloseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EyeCloseButton.Name = "EyeCloseButton";
            this.EyeCloseButton.Size = new System.Drawing.Size(42, 46);
            this.EyeCloseButton.TabIndex = 9;
            this.EyeCloseButton.UseVisualStyleBackColor = true;
            this.EyeCloseButton.Click += new System.EventHandler(this.EyeCloseButton_Click);
            // 
            // SignUpButton
            // 
            this.SignUpButton.BackColor = System.Drawing.Color.Green;
            this.SignUpButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SignUpButton.Location = new System.Drawing.Point(360, 451);
            this.SignUpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(109, 35);
            this.SignUpButton.TabIndex = 8;
            this.SignUpButton.Text = "SIGN UP";
            this.SignUpButton.UseVisualStyleBackColor = false;
            this.SignUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(544, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username:";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(547, 151);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordBox.Multiline = true;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(246, 45);
            this.PasswordBox.TabIndex = 3;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(22, 151);
            this.UsernameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UsernameBox.Multiline = true;
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(246, 45);
            this.UsernameBox.TabIndex = 2;
            this.UsernameBox.TextChanged += new System.EventHandler(this.UsernameBox_TextChanged);
            // 
            // SignUpF2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 562);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SignUpF2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox RoleComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button EyeOpenButton;
        private System.Windows.Forms.Button EyeCloseButton;
        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ContactNumberBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UliBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.DateTimePicker BirthdayPicker;
        private System.Windows.Forms.Label label9;
    }
}