using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace TCP_Klienti
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void txtIpAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            
            String ipAddress = txtIpAddress.Text;
            int port = Int32.Parse(txtPort.Text);
            startClient(ipAddress, port);

        }

        public static void startClient(String ipAddress, int port)
        {

            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry host = Dns.GetHostEntry(ipAddress);
                IPAddress ipAddr = host.AddressList[0];
                IPEndPoint remoteEp = new IPEndPoint(ipAddr, port);

                Socket sender =
                    new Socket(ipAddr.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEp);
                    byte[] msg = Encoding.ASCII.GetBytes("TEst");
                    int byteSent = sender.Send(msg);
                    byte[] msg4 = Encoding.ASCII.GetBytes("TEstLAVDA<EOF>");
                    int byteSent4 = sender.Send(msg4);
                    MessageBox.Show("Sukses: " + byteSent);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

            } catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void defaultValueCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultValueCheck.Checked == true)
            {
                txtIpAddress.Text = "192.168.43.159";
                txtPort.Text = "11000";
                txtIpAddress.Enabled = false;
                txtPort.Enabled = false;
            } else
            {
                txtIpAddress.Text = "";
                txtPort.Text = "";
                txtIpAddress.Enabled = true;
                txtPort.Enabled = true;
            }  


        }
    }
}
