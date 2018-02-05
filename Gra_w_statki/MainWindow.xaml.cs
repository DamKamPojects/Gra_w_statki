using System;
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
        }

        //inicjalizacja stron
        GameOptionsPage gameOptionsPage = new GameOptionsPage();
        GameWindowPage gameWindowPage = new GameWindowPage();
        CreateMapPage createMapPage = new CreateMapPage(10);
        ConnectionPage connectionPage = new ConnectionPage();
        WelcomePage welcomePage = new WelcomePage();
        WaitingPage waitingPage = new WaitingPage();

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
            if (EventChangeCurrentPage!=null)
            {
                EventChangeCurrentPage(pageIndex, new EventArgs());
            }
        }        




        //załadowanie okna aplikacji
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeCurrentPage(0);
        }
        

        private void GameWindowButton_Click(object sender, RoutedEventArgs e)
        {
            WindowFrame.Content = gameWindowPage;


        }

        private void GameOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            WindowFrame.Content = gameOptionsPage;
        }

        private void CreateMapButton_Click(object sender, RoutedEventArgs e)
        {
            WindowFrame.Content = createMapPage;
        }




        //testowy
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }



        private void Test()
        {
            DependencyObject dependencyObject = Content as DependencyObject;
            Button button = LogicalTreeHelper.FindLogicalNode(dependencyObject, "x2y2") as Button;
            button.Content = "dziala!";
        }
    }
}
