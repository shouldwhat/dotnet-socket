using System.Net;
using System.Net.Sockets;

namespace MyLib
{
    public static class MySock
    {
        public static IPAddress GetMyIP()
        {
            string host_name = Dns.GetHostName();
            IPHostEntry host = Dns.GetHostEntry(host_name);

            foreach (IPAddress addr in host.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    return addr;
                }
            }
            return null;
        }
    }
}
