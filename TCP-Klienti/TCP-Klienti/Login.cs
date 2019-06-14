using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace TCP_Klienti
{
    public partial class Login : Form
    {
        Socket sender = null;
        byte[] response = new byte[1024];
        public Login(Socket sender)
        {
            this.sender = sender;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text;
            String password = txtPassword.Text;

            byte[] byteEmail = Encoding.ASCII.GetBytes(email +" "+password);

            this.sender.Send(byteEmail);

            this.sender.Receive(this.response);

            String response = Encoding.ASCII.GetString(this.response);

            MessageBox.Show(response);

            if(response != "")
            {
                new Details().Show();
                this.Close();
            } else
            {
                MessageBox.Show("Could not connect");
            }


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new Register(this.sender).Show();
            this.Close();
        }
    }
}
