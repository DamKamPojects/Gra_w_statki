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
    /// Interaction logic for GameWindowPage.xaml
    /// </summary>
    public partial class GameWindowPage : Page
    {
        //zmienne
        private int[] _eachShipAmount;
        private BoardPage _ourBoard;
        private BoardPage _enemyBoard;

        private static event EventHandler EventGetPlayerBoard;
        private static event EventHandler EventGetShipAmount;
        private static event EventHandler EventGetRemainingShipAmount;


        public GameWindowPage()
        {
            InitializeComponent();
            EventGetPlayerBoard += new EventHandler(_getPlayerBoard);
            EventGetShipAmount += new EventHandler(_getShipAmount);
            EventGetRemainingShipAmount += new EventHandler(_showAvailableShips);
        }



        //metody
        //1 event
        public static void GetPlayerBoard(BoardPage ourBoard)
        {
            EventGetPlayerBoard?.Invoke(ourBoard, new EventArgs());
        }

        //2 event
        public static void GetShipAmount(int[] eachShipAmount)
        {
            EventGetShipAmount?.Invoke(eachShipAmount, new EventArgs());
        }

        //3 event
        public static void GetRemainingShips(int[] remainingShips)
        {
            EventGetRemainingShipAmount?.Invoke(remainingShips,new EventArgs());
        }



        //1 event - meotda
        private void _getPlayerBoard(object sender, EventArgs e)
        {
            _ourBoard = (BoardPage)sender;
            OurBoardFrame.Content = _ourBoard;
        }        
        
        //2 event - metoda
        private void _getShipAmount(object sender, EventArgs e)
        {
            _eachShipAmount = (int[])sender;
            _showAvailableShips(_eachShipAmount, new EventArgs());
        }

        //3 event - metody
        private void _showAvailableShips(object sender, EventArgs e)
        {
            OurShipsStackPanel.Children.Clear(); //czyszczenie stackpanela

            for (int i = 0; i < 6; i++)
            {
                if (_eachShipAmount[i] != 0) //to oznacza że jest jakiś statek danego rodzaju
                {
                    //stack panel zawierajacy w sobie textblocki
                    StackPanel ShipStackPanel = new StackPanel()
                    {
                        MinWidth = 25,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(5, 0, 5, 0)

                    };

                    TextBlock ShipName = new TextBlock()
                    {
                        Text = (i + 1) + "-maszt.",
                        FontSize = 14,
                        TextAlignment = TextAlignment.Center
                    };
                    TextBlock ShipAmount = new TextBlock()
                    {
                        Text = Convert.ToString(_eachShipAmount[i]),
                        FontSize = 20,
                        TextAlignment = TextAlignment.Center
                    };

                    ShipStackPanel.Children.Add(ShipName);
                    ShipStackPanel.Children.Add(ShipAmount);

                    //dodanie do glownego stack panela
                    OurShipsStackPanel.Children.Add(ShipStackPanel);
                }
            }
        }



    }
}
