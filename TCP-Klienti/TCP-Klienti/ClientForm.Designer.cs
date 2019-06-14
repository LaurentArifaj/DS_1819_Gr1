namespace TCP_Klienti
{
    partial class ClientForm
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
            this.ipAddressLbl = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.portLbl = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.defaultValueCheck = new System.Windows.Forms.CheckBox();
            this.btnClick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipAddressLbl
            // 
            this.ipAddressLbl.AutoSize = true;
            this.ipAddressLbl.Location = new System.Drawing.Point(12, 27);
            this.ipAddressLbl.Name = "ipAddressLbl";
            this.ipAddressLbl.Size = new System.Drawing.Size(72, 13);
            this.ipAddressLbl.TabIndex = 0;
            this.ipAddressLbl.Text = "IP ADDRESS";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(12, 57);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(154, 20);
            this.txtIpAddress.TabIndex = 1;
            this.txtIpAddress.TextChanged += new System.EventHandler(this.txtIpAddress_TextChanged);
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Location = new System.Drawing.Point(12, 113);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(26, 13);
            this.portLbl.TabIndex = 2;
            this.portLbl.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(12, 129);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(154, 20);
            this.txtPort.TabIndex = 3;
            // 
            // defaultValueCheck
            // 
            this.defaultValueCheck.AutoSize = true;
            this.defaultValueCheck.Location = new System.Drawing.Point(15, 195);
            this.defaultValueCheck.Name = "defaultValueCheck";
            this.defaultValueCheck.Size = new System.Drawing.Size(90, 17);
            this.defaultValueCheck.TabIndex = 4;
            this.defaultValueCheck.Text = "Default Value";
            this.defaultValueCheck.UseVisualStyleBackColor = true;
            this.defaultValueCheck.CheckedChanged += new System.EventHandler(this.defaultValueCheck_CheckedChanged);
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(118, 231);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(75, 23);
            this.btnClick.TabIndex = 5;
            this.btnClick.Text = "Click";
            this.btnClick.UseVisualStyleBackColor = true;
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 279);
            this.Controls.Add(this.btnClick);
            this.Controls.Add(this.defaultValueCheck);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.portLbl);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.ipAddressLbl);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipAddressLbl;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.CheckBox defaultValueCheck;
        private System.Windows.Forms.Button btnClick;
    }
}