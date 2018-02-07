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
    class ConnectionClientSide
    {

        // Receiving byte array  
        byte[] bytes = new byte[1024];
        Socket senderSock;
        //int bytesRec;

        StringHandler msgHandler;
        string Opponent;

        MainWindow main;

        public delegate void UpdateTextCallback(string message);
        public delegate string GetMessageToSendCallback();


        public ConnectionClientSide(MainWindow Main)
        {

            main = Main;
            msgHandler = new StringHandler(Main, 2);
            //msgHandler.Opponent = "Serwer";
            msgHandler.Me = "KlientMe";
        }

        public void Connect()
        {
            try
            {
                Application.Current.Dispatcher.Invoke(
                                                          new UpdateTextCallback(main.Hh),
                                                          new object[] { "\nNawiązywanie połączenia....." }
                                                          );                // Create one SocketPermission for socket access restrictions 
                SocketPermission permission = new SocketPermission(
                    NetworkAccess.Connect,    // Connection permission 
                    TransportType.Tcp,        // Defines transport types 
                    "",                       // Gets the IP addresses 
                    SocketPermission.AllPorts // All ports 
                    );

                // Ensures the code to have permission to access a Socket 
                permission.Demand();

                // Resolves a host name to an IPHostEntry instance            
                //IPHostEntry ipHost = Dns.GetHostEntry("");
                IPHostEntry ipHost = Dns.GetHostEntry("127.0.0.1"); //tutaj trzeba wpisać adres i modlić się żeby działało

                

                // Gets first IP address associated with a localhost 
                IPAddress ipAddr = ipHost.AddressList[0];
                
                // Creates a network endpoint 
                //IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
                //IPEndPoint ipEndPoint = new IPEndPoint(ip, 8888);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8888);
                //IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 4510);

                // Create one Socket object to setup Tcp connection 
                senderSock = new Socket(
                    //ip.AddressFamily,// Specifies the addressing scheme 
                    ipAddr.AddressFamily,// Specifies the addressing scheme 
                                         //IPAddress.Parse("127.0.0.1").AddressFamily,// Specifies the addressing scheme 
                    SocketType.Stream,   // The type of socket  
                    ProtocolType.Tcp     // Specifies the protocols  
                    );

                senderSock.NoDelay = false;   // Using the Nagle algorithm 

                // Establishes a connection to a remote host 
                senderSock.Connect(ipEndPoint);
                Application.Current.Dispatcher.Invoke(
                                          new UpdateTextCallback(main.Hh),
                                          new object[] { "\nPołączono z: " + ipAddr.MapToIPv4().ToString() + Environment.NewLine }
                                          );
                Send(msgHandler.GetNickMsg("Klient"));

                while (senderSock.Connected == true)
                {
                    ReceiveDataFromServer();
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }

        }

        public void Send()
        {
            try
            {
                // Sending message 
                //fin is the sign for end of data 
                string theMessageToSend;
                theMessageToSend = Application.Current.Dispatcher.Invoke(
                                          new GetMessageToSendCallback(main.GetMessageClient)
                                          
                                          ) as string;

                
                byte[] msg = Encoding.Unicode.GetBytes(msgHandler.CreateMessage(theMessageToSend) + "fin");

                Application.Current.Dispatcher.Invoke(
                                           new UpdateTextCallback(main.Hh),
                                           new object[] { msgHandler.Me + ": " + theMessageToSend.ToString() + Environment.NewLine }
                                           );

                // Sends data to a connected Socket. 
                int bytesSend = senderSock.Send(msg);

                ReceiveDataFromServer();


            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        public void Send(string text)
        {
            try
            {
                // Sending message 
                //fin is the sign for end of data 
                string theMessageToSend = text;
                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + "fin");

                // Sends data to a connected Socket. 
                int bytesSend = senderSock.Send(msg);

                ReceiveDataFromServer();

                
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        private void ReceiveDataFromServer()
        {
            try
            {
                
                // Receives data from a bound Socket. 
                 int bytesRec = senderSock.Receive(bytes);
               

                // Converts byte array to string 
                String theMessageToReceive = Encoding.Unicode.GetString(bytes, 0, bytesRec);

                // Continues to read the data till data isn't available 
                while (senderSock.Available > 3)
                {
                    bytesRec = senderSock.Receive(bytes);
                    theMessageToReceive += Encoding.Unicode.GetString(bytes, 0, bytesRec);
                }

                var separators = new char[] { '\n', '\r' };
                var lines = theMessageToReceive.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (lines[0][0] == 'n') Opponent = msgHandler.GetNick(lines[0]);
                foreach (var line in lines)
                {
                    msgHandler.DecodeIncomingString(line);
                }
                
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

      

        public void Disconnect()
        {
            try
            {
                // Disables sends and receives on a Socket. 
                senderSock.Shutdown(SocketShutdown.Both);

                //Closes the Socket connection and releases all resources 
                senderSock.Close();

                
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }
    
}

}

