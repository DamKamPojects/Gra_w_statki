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
        private int _boardSize;
        private int[] EachShipAmount;

        //kontruktory
        public CreateMapPage()
        {
            InitializeComponent();
            EventCreateNewMap += new EventHandler(_createNewMap);
            EventCreateShipsAmountBoard += new EventHandler(_createShipsAmountBoard);
            EventCountShips += new EventHandler(_countShips);
        }
        


        //Eventy


        //deklaracja eventow
        private static event EventHandler EventCreateNewMap;
        private static event EventHandler EventCreateShipsAmountBoard;
        private static event EventHandler EventCountShips;

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
            if (EventCreateNewMap != null)
            {
                EventCreateNewMap(boardSize, new EventArgs()); //tworzy nowa mape
            }
        }        

        public static void CountShips(int[] countedShips)
        {
            if (EventCountShips!=null)
            {
                EventCountShips(countedShips, new EventArgs());
            }
        }

        //tworzy nowa mape
        private void _createNewMap(object sender, EventArgs e)
        {
            BoardPage OurBoard = new BoardPage((int)sender);
            BoardFrame.Content = OurBoard;
        }
        //tworzy tabelke z iloscia statkow
        private void _createShipsAmountBoard(object sender, EventArgs e)
        {
            int[] eachShipAmount = (int[])sender;

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
                }
                ShipAmountInfoGrid.RowDefinitions.Count();
            }
        }


        //metoda odwolujaca sie do metody liczacej statki
        private void _countShips(object sender, EventArgs e)
        {
            int[] remainingShips = (int[])sender;
            ShipAmountInfoGrid.Children.Clear();
            for (int i = 0; i < ShipAmountInfoGrid.RowDefinitions.Count(); i++)
            {
                TextBlock shipRemaining = new TextBlock()
                {
                    Text = Convert.ToString(remainingShips[i]),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                };
                Grid.SetRow(shipRemaining, i);
                Grid.SetColumn(shipRemaining, 2);
                ShipAmountInfoGrid.Children.Add(shipRemaining);
            }

            //EachShipAmount=((GameBoard)(BoardFrame.Content)).CountShips();
        }

        


    }
}
