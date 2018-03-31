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

        Socket workerSocket = null;
        Thread receiveThread = null;
        private bool ConnectServer()
        {
            try
            {
                workerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                workerSocket.Connect(new IPEndPoint(IPAddress.Parse("172.27.103.161"), 10200));

                receiveThread = new Thread(new ParameterizedThreadStart(RecvLoop));
                receiveThread.Start(workerSocket);

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
        private void RecvLoop(Object worker)
        {
            Socket workerSocket = worker as Socket;
            while (true)
            {
                if (receiveThread == null)
                {
                    return;
                }
                Byte[] buffer = new Byte[100000];
                try
                {
                    workerSocket.Receive(buffer);
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
            if (workerSocket != null)
            {
                workerSocket.Close();
                workerSocket = null;
            }
            if (receiveThread != null)
            {
                receiveThread.Abort();
                receiveThread = null;
            }
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            string msg = MySock.GetMyIP().ToString() + "::" + tb_msg.Text;
            try
            {
                workerSocket.Send(Encoding.Default.GetBytes(msg));
                lb_msgs.Items.Add(msg);
            }
            catch (Exception)
            {

            }
        }
    }
}
