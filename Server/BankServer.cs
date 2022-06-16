using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;
using System;


namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        IPEndPoint IP;
        Socket server;
        List<Socket> ClientList;

        void Connect()
        {
            addContent("listening");
            ClientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 2000);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            server.Bind(IP);

            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket Client = server.Accept();
                        ClientList.Add(Client);

                        if (Client.Connected)
                        {
                            addContent("listening to a new client");
                            Thread receive = new Thread(Receive);
                            receive.IsBackground = true;
                            receive.Start(Client);
                        }
                    }
                }
                catch (Exception)
                {
                    IP = new IPEndPoint(IPAddress.Any, 2000);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        void Receive(object obj)
        {
            Socket Client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    Client.Receive(data);

                    string message = (string)deserialize(data);

                    addContent(message);

                    foreach (Socket item in ClientList)
                    {
                        if (item != null)
                            item.Send(serialize(message));
                    }
                }
            }
            catch (Exception)
            {
                addContent("Close 1 client");
                ClientList.Remove(Client);
                Client.Close();
            }
        }

        void addContent(string s)
        {
            IV_content.Items.Add(new ListViewItem() { Text = s });
            IV_content.View = View.List;
        }

        byte[] serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        object deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }
        private void BankServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        void Close()
        {
            server.Close();
        }

        private void btn_Listen_Click(object sender, EventArgs e)
        {
            Connect();
        }
    }
}
