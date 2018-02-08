using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            //inicjalizacja eventów
            EventChangeCurrentPage += new EventHandler(_changeCurrentPage);
            EventSendClickCordinates += new EventHandler(_sendClickCordinates);
        }

        //inicjalizacja stron
        GameOptionsPage gameOptionsPage = new GameOptionsPage();
        CreateMapPage createMapPage = new CreateMapPage();
        ConnectionPage connectionPage = new ConnectionPage();
        WelcomePage welcomePage = new WelcomePage();
        WaitingPage waitingPage = new WaitingPage();
        LobbyPage lobbyPage = new LobbyPage();
        GameWindowPage gameWindowPage = new GameWindowPage();

        //deklaracja eventów
        public static event EventHandler EventChangeCurrentPage; //event obslugujacy zawartosc strony
        
        

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
                
        //załadowanie okna aplikacji
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeCurrentPage(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[] cordinates = new int[2] {Convert.ToInt32(X.Text), Convert.ToInt32(Y.Text)};
            
            cos.Text=gameWindowPage.CheckFieldHit(cordinates)+"";
            gameWindowPage._showAvailableShips(null, new EventArgs());
        }



        private static event EventHandler EventSendClickCordinates;
        //private static event EventHandler EventRecieveChangesStack;//zmiany kolorow buttonow


        //tu metoda dostająca kordynaty kliknietego przycisku
        public static void SendClickCordinates(int[] cordinates)
        {
            EventSendClickCordinates?.Invoke(cordinates, new EventArgs());
        }

        private void _sendClickCordinates(object sender, EventArgs e)
        {
            _checkField(sender, new EventArgs());
        }

        //event wywyłający kordynaty do sprawdzenia
        private void _checkField(object sender, EventArgs e)
        {            
            
            int value = gameWindowPage.CheckFieldHit((int[])sender);
            cos.Text = value + "";
            _setEnemyButtonsBoardField((int[]) sender, value);
        }

        private void _setEnemyButtonsBoardField(int[] cordinates, int hitInformation)
        {
            gameWindowPage.SendHitInfoToEnemyBoard(cordinates, hitInformation);
        }




    }
}
