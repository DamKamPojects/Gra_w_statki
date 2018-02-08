using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gra_w_statki
{
    /// <summary>
    /// Interaction logic for CreateMapPage.xaml
    /// </summary>
    public partial class CreateMapPage : Page
    {
        ////zmienne
        private int _boardSize=2;
        private int[] EachShipAmount;
        BoardPage OurBoard;

        //deklaracja eventow
        private static event EventHandler EventCreateNewMap;
        private static event EventHandler EventCreateShipsAmountBoard;
        private static event EventHandler EventCountShips;
        private static event EventHandler EventGetPlayerBoard;

        //kontruktory
        public CreateMapPage()
        {
            InitializeComponent();
            EventCreateNewMap += new EventHandler(_createNewMap);
            EventCreateShipsAmountBoard += new EventHandler(_createShipsAmountBoard);
            EventCountShips += new EventHandler(_countShips);
            EventGetPlayerBoard += new EventHandler(_getPlayerBoard);
        }

        //przyciski
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewMap(_boardSize);
            _countShips(new int[] { 0, 0, 0, 0, 0, 0 }, new EventArgs());
        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            //LobbyPage.GetPlayerBoard((BoardPage)BoardFrame.Content);/
            OurBoard.CanBeChanged = false;
            OurBoard.PrepereButtonsForGame();
            LobbyPage.GetPlayerBoard(OurBoard);
            MainWindow.ChangeCurrentPage(40);
        }



        //Eventy - metody        

        //deklaracja metod
        //metoda przyjmuje rozmiar plansyz oraz ilosci statkow, potrzebne do stworzenia mapy
        public static void CreateNewMap(int boardSize, int[] eachShipsAmount)
        {
            if (EventCreateNewMap != null)
            {
                EventCreateNewMap(boardSize, new EventArgs()); //tworzy nowa mape
                EventCreateShipsAmountBoard(eachShipsAmount, new EventArgs()); //tworzy tabelke ze statkami
            }
        }
        //do resetowania planszy
        public static void CreateNewMap(int boardSize)
        {
            
            EventCreateNewMap?.Invoke(boardSize, new EventArgs()); //tworzy nowa mape
        }        
        //metoda wywolujaca event liczacy statki
        public static void CountShips(int[] countedShips)
        {
            EventCountShips?.Invoke(countedShips, new EventArgs());
        }

        //tworzy nowa mape
        private void _createNewMap(object sender, EventArgs e)
        {
            _boardSize = (int)sender;
            OurBoard = new BoardPage((int)sender);
            BoardFrame.Content = OurBoard;
        }

        //tworzy tabelke z iloscia statkow
        private void _createShipsAmountBoard(object sender, EventArgs e)
        {
            int[] eachShipAmount = (int[])sender;
            EachShipAmount = eachShipAmount;
            ShipAmountInfoGrid.Children.Clear();
            int tableLength=0;
            //szuka dlugosci tablicy
            for (int i = 0; i < eachShipAmount.Length; i++)
            {
                if (eachShipAmount[i]!=0)
                {
                    tableLength = i + 1;
                }
                else
                {
                    break;
                }
            }

            //dostosowuje ilosc wierszy do ilości różnych statkow
            while (ShipAmountInfoGrid.RowDefinitions.Count() != tableLength)
            {
                if (ShipAmountInfoGrid.RowDefinitions.Count() < tableLength)
                {
                    ShipAmountInfoGrid.RowDefinitions.Add(new RowDefinition());
                }
                else if (ShipAmountInfoGrid.RowDefinitions.Count()> tableLength)
                {
                    //ShipAmountInfoGrid.RowDefinitions.RemoveAt(ShipAmountInfoGrid.RowDefinitions.Count()-1);
                    ShipAmountInfoGrid.RowDefinitions.RemoveAt(1);
                }
            }

            //właściwa pętla wstawiająca wartości do tabeli
            for (int i = 0; i < eachShipAmount.Length; i++)
            {
                if (eachShipAmount[i]>0)
                {
                    //nazwa masztowca
                    TextBlock shipName = new TextBlock()
                    {
                        Text = (i + 1) + "-maszt.",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 16
                    };
                    Grid.SetRow(shipName, i);
                    Grid.SetColumn(shipName, 0);
                    ShipAmountInfoGrid.Children.Add(shipName);

                    //ilość danego rodzaju statku
                    TextBlock shipAmount = new TextBlock()
                    {
                        Text = Convert.ToString(eachShipAmount[i]),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,                        
                    };
                    Grid.SetRow(shipAmount, i);
                    Grid.SetColumn(shipAmount, 1);
                    ShipAmountInfoGrid.Children.Add(shipAmount);

                    TextBlock shipPlaced = new TextBlock()
                    {
                        Name = "shipPlaced" + i,
                        Text = Convert.ToString(0),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                    };
                    Grid.SetRow(shipPlaced, i);
                    Grid.SetColumn(shipPlaced, 2);
                    ShipAmountInfoGrid.Children.Add(shipPlaced);



                    TextBlock shipRemaining = new TextBlock()
                    {
                        Name = "shipRemaining" + i,
                        Text = Convert.ToString(EachShipAmount[i]),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                    };
                    Grid.SetRow(shipRemaining, i);
                    Grid.SetColumn(shipRemaining, 3);
                    ShipAmountInfoGrid.Children.Add(shipRemaining);


                }
                //ShipAmountInfoGrid.RowDefinitions.Count();
            }

            _countShips(new int[] { 0, 0, 0, 0, 0, 0 }, new EventArgs());
        }
                
        //metoda liczaca statki
        private void _countShips(object sender, EventArgs e)
        {
            int[] placedShips = (int[])sender;
            
            //aktualizacja danych
            for (int i = 0; i < ShipAmountInfoGrid.RowDefinitions.Count(); i++)
            {
                DependencyObject dependencyObject = Content as DependencyObject;
                
                TextBlock placedShip = LogicalTreeHelper.FindLogicalNode(dependencyObject, "shipPlaced"+i) as TextBlock;
                placedShip.Text = Convert.ToString(placedShips[i]);
                TextBlock remainingShip = LogicalTreeHelper.FindLogicalNode(dependencyObject, "shipRemaining" + i) as TextBlock;
                remainingShip.Text = Convert.ToString(EachShipAmount[i] - placedShips[i]);

                if (EachShipAmount[i] == placedShips[i])
                {
                    remainingShip.Foreground = placedShip.Foreground = Brushes.DarkGreen;
                }
                else
                {
                    remainingShip.Foreground = placedShip.Foreground = Brushes.DarkRed;
                }               

            }
            //if (EachShipAmount.Equals(placedShips))
            for (int i = 0; i < EachShipAmount.Length; i++)
            {
                if (EachShipAmount[i]!=placedShips[i])
                {
                    ConfirmButton.IsEnabled = false;
                    break;
                }
                ConfirmButton.IsEnabled = true;
            }
            
        }



        //przekazywanie planszy
        private void _getPlayerBoard(object sender, EventArgs e)
        {
            //inaczej się nie da; jestem zbyt glupi na to
            OurBoard= new BoardPage(_boardSize);
            EventCreateShipsAmountBoard(EachShipAmount, new EventArgs());

            BoardFrame.Content = OurBoard;
                    }

        //wywołanie eventu
        public static void GetPlayerBoard(BoardPage ourBoard)
        {
            EventGetPlayerBoard?.Invoke(ourBoard, new EventArgs());
        }

        private void BoardFrame_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
