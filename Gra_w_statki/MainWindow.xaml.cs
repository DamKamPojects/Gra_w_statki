using Gra_w_statki.Classes;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Gra_w_statki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //inicjalizacja stron
        GameOptionsPage gameOptionsPage = new GameOptionsPage();
        GameWindowPage gameWindowPage = new GameWindowPage();
        CreateMapPage createMapPage = new CreateMapPage();
        ConnectionPage connectionPage = new ConnectionPage();
        WelcomePage welcomePage = new WelcomePage();
        WaitingPage waitingPage = new WaitingPage();

        //deklaracja eventów
        public static event EventHandler EventChangeCurrentPage; //event obslugujacy zawartosc strony
        public static event EventHandler EventGetConnectionParameters;  //event pobierający dane wymagane do połączenia

        ConnectionServerSide server;
        ConnectionClientSide client;


        TextBox chat = new TextBox();

        public MainWindow()
        {
            InitializeComponent();

            //inicjalizacja eventów
            EventChangeCurrentPage += new EventHandler(_changeCurrentPage);
            EventGetConnectionParameters += new EventHandler(_getConnectionParameters);
            
        }

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
                            WindowFrame.Content = connectionPage;
                            break;
                        }
                    case 11:
                        {
                            WindowFrame.Content = waitingPage;
                            break;
                        }
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
                            WindowFrame.Content = gameWindowPage;
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



        //załadowanie okna aplikacji
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeCurrentPage(0);
        }

        private void tb_ToSend_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key==System.Windows.Input.Key.Enter && server!=null) server.SendMsg(tb_ToSend.Text);
            if (e.Key == System.Windows.Input.Key.Enter && client != null)
            {
                Thread clientSendThread = new Thread(new ThreadStart(client.Send));
                clientSendThread.Start();
            }
            //tb_Czat.Text += tb_ToSend.Text;

        }

        public string GetMessageClient()
        {
            return tb_ToSend.Text;
        }

        public void Hh(string text)
        {
            tb_Czat.AppendText(text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            server = new ConnectionServerSide(this);
            server.Start();
            server.Listen();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            client = new ConnectionClientSide(this);
            Thread clientThread = new Thread(new ThreadStart(client.Connect));
            clientThread.Start();
        }
    }
}
