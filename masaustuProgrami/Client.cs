using DataCore;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace masaustuProgrami
{
    public class Client
    {
        #region Degiskenler

        public static Client Instance {
            get
            {
                if (intance == null)
                    intance = new Client();

                return intance;
            }
        }

        private static Client intance = null;

        private const int Port = 8001;

        private IPAddress ServerIPAdreess { get; set; }


        private Thread ClientThread { get; set; }

        private TcpClient TcpClient { get; set; }

        private NetworkStream NetworkStream { get; set; } 

        public bool IsConnected { get; private set; }

        public DataHelper DataHelper { get; private set; }


        public event ClientConnecttionChanged OnConnectionChanged;

        public event ClientDataRead OnDataRead;

        #endregion

        #region Yapıcı Metod

        private Client()
        {
            Initialize();
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            DataHelper = DataHelper.Instance;

            IsConnected = false;

            ServerIPAdreess = IPAddress.Parse("127.0.0.1");

            NetworkStream = null;
            TcpClient = null;
            ClientThread = null;
        }

        private void Listen()
        {
            while (IsConnected)
            {
                try
                {
                    var headerBytes = new byte[HeaderData.HeaderLength];
                    NetworkStream.Read(headerBytes, 0, headerBytes.Length);

                    var headerData = HeaderData.FromByteArray(headerBytes);

                    var dataBytes = new byte[headerData.DataLength];
                    NetworkStream.Read(dataBytes, 0, dataBytes.Length);

                    if (Enum.IsDefined(typeof(DataTypes), headerData.DataType))
                        OnDataRead?.Invoke(headerData, DataHelper.ProcessData(headerData, dataBytes));
                    else
                        Console.WriteLine("Packet Dropped");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        #endregion

        #region Public Methods

        public void Connect()
        {
            if (IsConnected)
                return;

            try
            {
                ClientThread = new Thread(Listen);

             
                TcpClient = new TcpClient(ServerIPAdreess.ToString(), Port);
                NetworkStream = TcpClient.GetStream();

                IsConnected = true;

                ClientThread.Start();

                OnConnectionChanged?.Invoke(IsConnected);

            }
            catch(Exception e)
            {
                IsConnected = false;

                OnConnectionChanged?.Invoke(IsConnected);

                Console.WriteLine(e.Message);
            }
        }

        public void Disconnect()
        {
            if (!IsConnected)
                return;

            IsConnected = false;

            NetworkStream.Close();
            TcpClient.Close();
            ClientThread.Abort();  //abort->durdurmak

            NetworkStream = null;
            TcpClient = null;
            ClientThread = null;

            OnConnectionChanged?.Invoke(IsConnected);
        }

        public void Send(DataTypes dataType, object data)
        {
            if (!IsConnected)
                return;

            
            var dataByte = DataHelper.Instance.GetSendData(dataType, data); // veriyi, byte arrayine çevirdim
            var length = dataByte.Length; //verinin uzunluğunu atadık

            var headerData = DataHelper.Instance.GetHeaderData(MainForm.ID, dataType, length); // ön bilgi içeren kısmı byte arrayine çevirdim

            NetworkStream.Write(headerData.ToByteArray(), 0, HeaderData.HeaderLength); //veriyle ilgili ön bilgiler yazıyorum.
            NetworkStream.Write(dataByte, 0, length);
            
        }

        #endregion
    }
}