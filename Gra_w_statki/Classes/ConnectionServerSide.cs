using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Gra_w_statki.Classes
{
    class ConnectionServerSide
    {

        SocketPermission permission;
        Socket sListener;
        IPEndPoint ipEndPoint;
        Socket handler;

        MainWindow main;
        StringHandler msgHandler;
        //private TextBox tbAux = new TextBox();

        public string Opponent = null;

        public delegate void UpdateTextCallback(string text);


        //public object Dispatcher { get; private set; }

        public ConnectionServerSide(MainWindow Main)
        {
            main = Main;
            //tbAux.SelectionChanged += tbAux_SelectionChanged;
            msgHandler = new StringHandler(Main,1);
           // msgHandler.Me = "SerwerMe";
            


        }

        //private void tbAux_SelectionChanged(object sender, RoutedEventArgs e)
        //{
        //    main.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
        //    {
        //        main.tb_Czat.Text = tbAux.Text;
        //    }
        //    );
        //}

        public void Start()
        {
            try
            {
                // Creates one SocketPermission object for access restrictions
                permission = new SocketPermission(
                NetworkAccess.Accept,     // Allowed to accept connections 
                TransportType.Tcp,        // Defines transport types 
                "",                       // The IP addresses of local host 
                SocketPermission.AllPorts // Specifies all ports 
                );

                // Listening Socket object 
                sListener = null;

                // Ensures the code to have permission to access a Socket 
                permission.Demand();

                // Resolves a host name to an IPHostEntry instance 
                IPHostEntry ipHost = Dns.GetHostEntry("");

                // Gets first IP address associated with a localhost 
                IPAddress ipAddr = ipHost.AddressList[0];

                // Creates a network endpoint 
                ipEndPoint = new IPEndPoint(ipAddr, 8888);

                // Create one Socket object to listen the incoming connection 
                sListener = new Socket(
                    ipAddr.AddressFamily,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );

                // Associates a Socket with a local endpoint 
                sListener.Bind(ipEndPoint);

                //tbStatus.Text = "Server started.";
                //Listen();

            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        public void Start(string nickname)
        {
            msgHandler.Me = nickname;
            try
            {
                // Creates one SocketPermission object for access restrictions
                permission = new SocketPermission(
                NetworkAccess.Accept,     // Allowed to accept connections 
                TransportType.Tcp,        // Defines transport types 
                "",                       // The IP addresses of local host 
                SocketPermission.AllPorts // Specifies all ports 
                );

                // Listening Socket object 
                sListener = null;

                // Ensures the code to have permission to access a Socket 
                permission.Demand();

                // Resolves a host name to an IPHostEntry instance 
                IPHostEntry ipHost = Dns.GetHostEntry("");

                // Gets first IP address associated with a localhost 
                IPAddress ipAddr = ipHost.AddressList[0];

                // Creates a network endpoint 
                ipEndPoint = new IPEndPoint(ipAddr, 8888);

                // Create one Socket object to listen the incoming connection 
                sListener = new Socket(
                    ipAddr.AddressFamily,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );

                // Associates a Socket with a local endpoint 
                sListener.Bind(ipEndPoint);

                //tbStatus.Text = "Server started.";
                //Listen();

            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        public void Listen()
        {
            try
            {
                main.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                {
                    main.tb_Czat.Text += "\nUruchomiono serwer\n";
                }
                    );
                // Places a Socket in a listening state and specifies the maximum 
                // Length of the pending connections queue 
                sListener.Listen(10);

                // Begins an asynchronous operation to accept an attempt 
                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                sListener.BeginAccept(aCallback, sListener);

                //tbStatus.Text = "Server is now listening on " + ipEndPoint.Address + " port: " + ipEndPoint.Port;

                //StartListen_Button.IsEnabled = false;
                //Send_Button.IsEnabled = true;
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            //main.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            //{
            //    main.tb_Czat.Text += "\nAcceptCallback";
            //}
            //        );
            Socket listener = null;

            // A new Socket to handle remote host communication 
            Socket handler = null;
            try
            {
                // Receiving byte array 
                byte[] buffer = new byte[1024];
                // Get Listening Socket object 
                listener = (Socket)ar.AsyncState;
                // Create a new socket 
                handler = listener.EndAccept(ar);

                // Using the Nagle algorithm 
                handler.NoDelay = false;

                // Creates one object array for passing data 
                object[] obj = new object[2];
                obj[0] = buffer;
                obj[1] = handler;

                while (!sListener.Connected)
                {
                    // Begins to asynchronously receive data 
                    handler.BeginReceive(
                        buffer,        // An array of type Byt for received data 
                        0,             // The zero-based position in the buffer  
                        buffer.Length, // The number of bytes to receive 
                        SocketFlags.None,// Specifies send and receive behaviors 
                        new AsyncCallback(ReceiveCallback),//An AsyncCallback delegate 
                        obj            // Specifies infomation for receive operation 
                        );

                    // Begins an asynchronous operation to accept an attempt 
                    AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                    listener.BeginAccept(aCallback, listener);
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            //main.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            //{
            //    tbAux.Text += "\nRecieveCallback";
            //}
            //        );
            try
            {
                // Fetch a user-defined object that contains information 
                object[] obj = new object[2];
                obj = (object[])ar.AsyncState;

                // Received byte array 
                byte[] buffer = (byte[])obj[0];

                // A Socket to handle remote host communication. 
                handler = (Socket)obj[1];

                // Received message 
                string content = string.Empty;


                // The number of bytes received. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    content += Encoding.Unicode.GetString(buffer, 0,
                        bytesRead);

                    //// If message contains "<Client Quit>", finish receiving
                    //if (content.IndexOf("fin") > -1)
                    //{
                    //    // Convert byte array to string
                    //    string str = content.Substring(0, content.LastIndexOf("fin"));

                    //    //this is used because the UI couldn't be accessed from an external Thread
                    //    main.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                    //    {
                    //        //tbAux.Text += "Read " + str.Length * 2 + " bytes from client.\n Data: " + str;
                    //    }
                    //    );
                    //}
                    //else
                    //{
                        // Continues to asynchronously receive data
                        byte[] buffernew = new byte[1024];
                        obj[0] = buffernew;
                        obj[1] = handler;
                        handler.BeginReceive(buffernew, 0, buffernew.Length,
                            SocketFlags.None,
                            new AsyncCallback(ReceiveCallback), obj);
                    //}

                    

                    var separators = new char[] { '\n', '\r' };
                    var lines = content.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    if (Opponent == null && lines[0][0] == 'n')
                    {
                        Opponent = msgHandler.GetNick(lines[0]);
                        Send(msgHandler.CreateNickMsg(msgHandler.Me));
                    }
                    foreach (var line in lines)
                    {
                        msgHandler.DecodeIncomingString(line);
                    }

                    
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        #region wysyłanie
        public void Send(string text)
        {
            try
            {
                // Convert byte array to string 
                string str = text;

                // Prepare the reply message 
                byte[] byteData =
                    Encoding.Unicode.GetBytes(str+"fin");

                // Sends data asynchronously to a connected Socket 
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), handler);

                //Send_Button.IsEnabled = false;
               // Close_Button.IsEnabled = true;
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        public void SendMsg(string text)
        {
            main.Dispatcher.Invoke(new UpdateTextCallback(main.UpdateText), new object[] { msgHandler.Me + ": " + text + Environment.NewLine });
            Send(msgHandler.CreateMessage(text));
           
        }

        public void SendStartingParameters(int Dimension, int[] Ships)
        {

            Send(msgHandler.CreateStartingParameters(Dimension,Ships));
        }

        public void SendTurnChangeSignal()
        {
            Send(msgHandler.CreateTurnChangeSignal());
        }

        public void SendHit(int[] coords)
        {
            Send(msgHandler.CreateHit(coords));
        }

        public void SendConfirmationHit(bool hit, int[] coords, int sinkedSize)
        {
            Send(msgHandler.CreateConfirmationHit(hit, coords, sinkedSize));
        }

        public void SendReadySignal()
        {
            Send(msgHandler.CreateReadySignal());
        }
        #endregion


        public void SendCallback(IAsyncResult ar)
        {
            try
            {
                // A Socket which has sent the data to remote host 
                Socket handler = (Socket)ar.AsyncState;

                // The number of bytes sent to the Socket 
                int bytesSend = handler.EndSend(ar);
                
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        public void Close()
        {
            try
            {
                if (sListener.Connected)
                {
                    sListener.Shutdown(SocketShutdown.Receive);
                    sListener.Close();
                }

            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }
        }
}
