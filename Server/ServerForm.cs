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

        Socket listenSocket = null;
        Thread acceptThread = null;

        private void 서버개설ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(MySock.GetMyIP(), 10200));
            listenSocket.Listen(10);

            acceptThread = new Thread(new ThreadStart(AcceptLoop));
            acceptThread.Start();
        }
        
        private void AcceptLoop()
        {
            while (true)
            {
                try
                {
                    Socket workerSocket = listenSocket.Accept();
                    if (workerSocket.Connected == false)
                    {
                        break;
                    }

                    // Client로 부터 연결(connect) 요청된 경우, 상호간 통신을 담당할 쓰레드 생성
                    startInteractionThread(workerSocket);
                }
                catch (Exception) {

                }
            }
        }

        private void startInteractionThread(Socket workerSocket)
        {
            Thread interactionThread = new Thread(new ParameterizedThreadStart(RecvProc));
            interactionThread.Start(workerSocket);
        }

        delegate void AddItem(Byte[] msg);
        private void RecvProc(object workerSocket)
        {
            while(true)
            {
                try
                {
                    Byte[] buffer = new Byte[1000];

                    ((Socket) workerSocket).Receive(buffer);

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
        }
        private void AddMsg(Byte[] msg)
        {
            lb_msgs.Items.Add(Encoding.Default.GetString(msg));
        }

        /*
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
        */

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (acceptThread != null)
            {
                acceptThread.Abort();
                acceptThread = null;
            }
            if (listenSocket != null)
            {
                listenSocket.Close();
                listenSocket = null;
            }
        }
    }
}
