namespace TCP_Klienti
{
    partial class Register
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label11 = new System.Windows.Forms.Label();
            this.textHours = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbTitle = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.textNumber = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.bttnRegister = new System.Windows.Forms.Button();
            this.bttnLogin = new System.Windows.Forms.Button();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblCPass = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.textMbiemri = new System.Windows.Forms.TextBox();
            this.lblMbiemri = new System.Windows.Forms.Label();
            this.txtEmri = new System.Windows.Forms.TextBox();
            this.lblEmri = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.textHours);
            this.splitContainer1.Panel2.Controls.Add(this.lblHours);
            this.splitContainer1.Panel2.Controls.Add(this.lblSubject);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox3);
            this.splitContainer1.Panel2.Controls.Add(this.lblTitle);
            this.splitContainer1.Panel2.Controls.Add(this.cmbTitle);
            this.splitContainer1.Panel2.Controls.Add(this.lblGender);
            this.splitContainer1.Panel2.Controls.Add(this.textNumber);
            this.splitContainer1.Panel2.Controls.Add(this.lblPhoneNumber);
            this.splitContainer1.Panel2.Controls.Add(this.cmbGender);
            this.splitContainer1.Panel2.Controls.Add(this.bttnRegister);
            this.splitContainer1.Panel2.Controls.Add(this.bttnLogin);
            this.splitContainer1.Panel2.Controls.Add(this.textEmail);
            this.splitContainer1.Panel2.Controls.Add(this.lblEmail);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.lblCPass);
            this.splitContainer1.Panel2.Controls.Add(this.textPassword);
            this.splitContainer1.Panel2.Controls.Add(this.lblPass);
            this.splitContainer1.Panel2.Controls.Add(this.textMbiemri);
            this.splitContainer1.Panel2.Controls.Add(this.lblMbiemri);
            this.splitContainer1.Panel2.Controls.Add(this.txtEmri);
            this.splitContainer1.Panel2.Controls.Add(this.lblEmri);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Size = new System.Drawing.Size(584, 561);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(131, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(317, 31);
            this.label11.TabIndex = 0;
            this.label11.Text = "User Registration Form";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // textHours
            // 
            this.textHours.Location = new System.Drawing.Point(338, 309);
            this.textHours.Name = "textHours";
            this.textHours.Size = new System.Drawing.Size(41, 22);
            this.textHours.TabIndex = 47;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(335, 290);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(44, 16);
            this.lblHours.TabIndex = 46;
            this.lblHours.Text = "Hours";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(83, 288);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(53, 16);
            this.lblSubject.TabIndex = 45;
            this.lblSubject.Text = "Subject";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Data Security",
            "Database",
            "Mathematics"});
            this.comboBox3.Location = new System.Drawing.Point(85, 307);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(201, 24);
            this.comboBox3.TabIndex = 44;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(93, 42);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(34, 16);
            this.lblTitle.TabIndex = 43;
            this.lblTitle.Text = "Title";
            // 
            // cmbTitle
            // 
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Items.AddRange(new object[] {
            "Dr",
            "MSc",
            "BSc"});
            this.cmbTitle.Location = new System.Drawing.Point(85, 61);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(50, 24);
            this.cmbTitle.TabIndex = 42;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(347, 231);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(53, 16);
            this.lblGender.TabIndex = 36;
            this.lblGender.Text = "Gender";
            // 
            // textNumber
            // 
            this.textNumber.Location = new System.Drawing.Point(85, 250);
            this.textNumber.Name = "textNumber";
            this.textNumber.Size = new System.Drawing.Size(133, 22);
            this.textNumber.TabIndex = 34;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(93, 234);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(98, 16);
            this.lblPhoneNumber.TabIndex = 33;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cmbGender.Location = new System.Drawing.Point(337, 250);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(133, 24);
            this.cmbGender.TabIndex = 32;
            this.cmbGender.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bttnRegister
            // 
            this.bttnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.bttnRegister.Location = new System.Drawing.Point(338, 354);
            this.bttnRegister.Name = "bttnRegister";
            this.bttnRegister.Size = new System.Drawing.Size(101, 29);
            this.bttnRegister.TabIndex = 29;
            this.bttnRegister.Text = "Register";
            this.bttnRegister.UseVisualStyleBackColor = false;
            this.bttnRegister.Click += new System.EventHandler(this.button1_Click);
            // 
            // bttnLogin
            // 
            this.bttnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.bttnLogin.Location = new System.Drawing.Point(85, 354);
            this.bttnLogin.Name = "bttnLogin";
            this.bttnLogin.Size = new System.Drawing.Size(101, 29);
            this.bttnLogin.TabIndex = 28;
            this.bttnLogin.Text = "Log In";
            this.bttnLogin.UseVisualStyleBackColor = false;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(85, 123);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(385, 22);
            this.textEmail.TabIndex = 19;
            this.textEmail.TextChanged += new System.EventHandler(this.textEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(93, 104);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 16);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(337, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(133, 22);
            this.textBox2.TabIndex = 17;
            // 
            // lblCPass
            // 
            this.lblCPass.AutoSize = true;
            this.lblCPass.Location = new System.Drawing.Point(344, 165);
            this.lblCPass.Name = "lblCPass";
            this.lblCPass.Size = new System.Drawing.Size(116, 16);
            this.lblCPass.TabIndex = 16;
            this.lblCPass.Text = "Confirm Password";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(85, 181);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(133, 22);
            this.textPassword.TabIndex = 15;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(93, 165);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(68, 16);
            this.lblPass.TabIndex = 14;
            this.lblPass.Text = "Password";
            // 
            // textMbiemri
            // 
            this.textMbiemri.Location = new System.Drawing.Point(317, 63);
            this.textMbiemri.Name = "textMbiemri";
            this.textMbiemri.Size = new System.Drawing.Size(153, 22);
            this.textMbiemri.TabIndex = 13;
            // 
            // lblMbiemri
            // 
            this.lblMbiemri.AutoSize = true;
            this.lblMbiemri.Location = new System.Drawing.Point(370, 44);
            this.lblMbiemri.Name = "lblMbiemri";
            this.lblMbiemri.Size = new System.Drawing.Size(56, 16);
            this.lblMbiemri.TabIndex = 12;
            this.lblMbiemri.Text = "Mbiemri";
            // 
            // txtEmri
            // 
            this.txtEmri.Location = new System.Drawing.Point(150, 65);
            this.txtEmri.Multiline = true;
            this.txtEmri.Name = "txtEmri";
            this.txtEmri.Size = new System.Drawing.Size(160, 20);
            this.txtEmri.TabIndex = 11;
            // 
            // lblEmri
            // 
            this.lblEmri.AutoSize = true;
            this.lblEmri.Location = new System.Drawing.Point(214, 42);
            this.lblEmri.Name = "lblEmri";
            this.lblEmri.Size = new System.Drawing.Size(35, 16);
            this.lblEmri.TabIndex = 10;
            this.lblEmri.Text = "Emri";
            this.lblEmri.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bttnRegister;
        private System.Windows.Forms.Button bttnLogin;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblCPass;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox textMbiemri;
        private System.Windows.Forms.Label lblMbiemri;
        private System.Windows.Forms.TextBox txtEmri;
        private System.Windows.Forms.Label lblEmri;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox textNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox textHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbTitle;
    }
}