using Gra_w_statki.Classes;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gra_w_statki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        //inicjalizacja stron
        GameOptionsPage gameOptionsPage = new GameOptionsPage();
        CreateMapPage createMapPage = new CreateMapPage();
        ConnectionPage connectionPage = new ConnectionPage();
        WelcomePage welcomePage = new WelcomePage();
        WaitingPage waitingPage = new WaitingPage();
        LobbyPage lobbyPage = new LobbyPage();
        GameWindowPage gameWindowPage = new GameWindowPage();
        SerwerOrClientPage serwerOrClientPage = new SerwerOrClientPage();
        SerwerConnectionPage serwerConnectionPage = new SerwerConnectionPage();

        ConnectionServerSide server;
        ConnectionClientSide client;

        //deklaracja eventów
        public static event EventHandler EventChangeCurrentPage; //event obslugujacy zawartosc strony
        public static event EventHandler EventGetConnectionParameters;  //event pobierający dane wymagane do połączenia
        public static event EventHandler EventStartServer;  //event pobierający dane wymagane do połączenia

        public MainWindow()
        {
            InitializeComponent();
            //inicjalizacja eventów
            EventChangeCurrentPage += new EventHandler(_changeCurrentPage);
            EventSendClickCordinates += new EventHandler(_sendClickCordinates);
            EventGetConnectionParameters += new EventHandler(_getConnectionParameters);

            EventStartServer += new EventHandler(_startServer);
            EventStartClient += new EventHandler(_startClient);

        }

        



        #region Eventy
        //metoda wywoływana przez event do zmiany zawartocsi strony
        private void _changeCurrentPage(object sender, EventArgs e)
        {
            try
            {
                switch((int)sender)
                {
                    case 0:
                        {
                            WindowFrame.Content = welcomePage;
                            break;
                        }
                    case 10:
                        {
                            WindowFrame.Content = serwerOrClientPage;
                            break;
                        }
                    case 11:
                        {
                            WindowFrame.Content = waitingPage;
                            break;
                        }
                    case 12:
                        WindowFrame.Content = connectionPage;
                        break;
                    case 13:
                        WindowFrame.Content = serwerConnectionPage;
                        break;

                    case 20:
                        {
                            WindowFrame.Content = gameOptionsPage;
                            break;
                        }
                    case 30:
                        {
                            WindowFrame.Content = createMapPage;
                            break;
                        }
                    case 40:
                        {
                            WindowFrame.Content = lobbyPage;
                            break;
                        }
                    case 50:
                        {
                            WindowFrame.Content=gameWindowPage;
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Zła wartość aktualnej strony!");
                            break;
                        }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Coś nie pyklo" + Environment.NewLine+ ex.Message);
            }
        }
        public static void ChangeCurrentPage(int pageIndex)
        {
            EventChangeCurrentPage?.Invoke(pageIndex, new EventArgs());
        }

        private void _getConnectionParameters(object sender, EventArgs e)
        {
            var connectionData = (string[])sender;

        }
        public static void GetConnectionParameters(string[] Params)
        {
            EventGetConnectionParameters?.Invoke(Params, new EventArgs());
        }

        public static void StartServer(string nickname)
        {
            EventStartServer?.Invoke(nickname, new EventArgs());
        }
        private void _startServer(object sender, EventArgs e)
        {
            server = new ConnectionServerSide(this);
            server.Start((string)sender);
            server.Listen();
        }
        #endregion

        //załadowanie okna aplikacji
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeCurrentPage(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[] cordinates = new int[2] {Convert.ToInt32(X.Text), Convert.ToInt32(Y.Text)};
            
            cos.Text=gameWindowPage.CheckFieldHit(cordinates)+"ss";
            gameWindowPage._showAvailableShips(null, new EventArgs());
        }



        private static event EventHandler EventSendClickCordinates;

        public static void SendClickCordinates(string cordinates)
        {
            EventSendClickCordinates?.Invoke(cordinates, new EventArgs());
        }

        private void _sendClickCordinates(object sender, EventArgs e)
        {
            cos.Text = (string)sender;
            //tu dostajemy kordynaty klikniecia
        }

#region 07.02 23:22 - łaczenie 1
        public void UpdateText(string text)
        {
            tb_Czat.Text += text;
        }

        public string GetMessage()
        {
            return tb_ToSend.Text;
        }

        private void tb_ToSend_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && server != null)
            {
                server.SendMsg(tb_ToSend.Text);
                ClearMsgTB();
            }
            if (e.Key == System.Windows.Input.Key.Enter && client != null)
            {
                Thread clientSendThread = new Thread(new ThreadStart(client.Send));
                clientSendThread.Start();
                //tb_ToSend.Text = null;

            }
        }

        public void ClearMsgTB()
        {
            tb_ToSend.Text = null;

        }

        public static event EventHandler EventStartClient;  //event pobierający dane wymagane do połączenia

        private void _startClient(object sender, EventArgs e)
        {
            string[] parameters = (string[])sender;
            client = new ConnectionClientSide(this, parameters[0], parameters[1], parameters[2]);
            Thread clientThread = new Thread(new ThreadStart(client.Connect));            
            clientThread.Start();
            ChangeCurrentPage(30);  //tutaj okno do którego ma iść
        }
        public static void StartClient(string nickname, string ip, string port)
        {
            EventStartClient?.Invoke(new string[] { nickname, ip, port }, new EventArgs());

        }
        #endregion
    }
}
