using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MyLib;

namespace About_Sock
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        Socket sock_lis = null;
        Thread thread_accept = null;

        private void 서버개설ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sock_lis = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock_lis.Bind(new IPEndPoint(MySock.GetMyIP(), 10200));
            sock_lis.Listen(10);

            thread_accept = new Thread(new ThreadStart(AcceptLoop));
            thread_accept.Start();
        }
        //
        Socket sock_do = null;
        private void AcceptLoop()
        {
            while (true) {

                if (thread_accept == null) {
                    return;
                }
                try {

                    sock_do = sock_lis.Accept();
                    while (true) {

                        if (sock_do.Connected == false) {
                            break;
                        }
                        RecvProc(sock_do);
                    }
                }
                catch (Exception) {

                }
            }
        }

        delegate void AddItem(Byte[] msg);
        private void RecvProc(Socket sock)
        {
            Byte[] buffer = new Byte[100000];
            try
            {
                sock.Receive(buffer);
                if (lb_msgs.InvokeRequired)
                {
                    lb_msgs.Invoke(new AddItem(AddMsg), new object[] { buffer });
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void AddMsg(Byte[] msg)
        {
            lb_msgs.Items.Add(Encoding.Default.GetString(msg));
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            string msg = MySock.GetMyIP().ToString() + "::" + tb_msg.Text;
            try
            {
                sock_do.Send(Encoding.Default.GetBytes(msg));
                lb_msgs.Items.Add(msg);
            }
            catch (Exception)
            {
                
            }
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread_accept != null)
            {
                thread_accept = null;
            }
            if (sock_do != null)
            {
                sock_do.Close();
                sock_do = null;
            }
            if (sock_lis != null)
            {
                sock_lis.Close();
                sock_lis = null;
            }
        }
    }
}
