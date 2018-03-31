using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MyLib;

namespace Client
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            if (ConnectServer() == false)
            {
                return;
            }
            InitializeComponent();
        }

        Socket sock_do = null;
        Thread thread_recv = null;
        private bool ConnectServer()
        {
            sock_do = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock_do.Connect(new IPEndPoint(IPAddress.Parse("192.168.34.65"), 10200));
                thread_recv = new Thread(new ParameterizedThreadStart(RecvLoop));
                thread_recv.Start(sock_do);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("서버 개설이 안됬어요");
                return false;
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            
        }
        private void RecvLoop(Object obj)
        {
            Socket sock = obj as Socket;
            while (true)
            {
                if (thread_recv == null)
                {
                    return;
                }
                Byte[] buffer = new Byte[100000];
                try
                {
                    sock.Receive(buffer);
                    RecvProc(buffer);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        delegate void AddItem(string msg);
        private void RecvProc(byte[] buffer)
        {
            string msg = Encoding.Default.GetString(buffer);
            if (lb_msgs.InvokeRequired)
            {
                lb_msgs.Invoke(new AddItem(AddMsg), new object[] { msg });
            }
        }
        private void AddMsg(Object obj)
        {
            string msg = obj.ToString();
            lb_msgs.Items.Add(msg);
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread_recv != null)
            {
                thread_recv = null;
            }
            if (sock_do != null)
            {
                sock_do.Close();
                sock_do = null;
            }
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
    }
}
