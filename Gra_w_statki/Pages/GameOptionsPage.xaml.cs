using System;
using System.Windows.Controls;
using System.Windows;

namespace Gra_w_statki
{
    /// <summary>
    /// Interaction logic for GameOptionsPage.xaml
    /// </summary>
    /// 
    public partial class GameOptionsPage : Page
    {
        //zmienne
        private int[] _eachShipAmount = new int[6]; //od lewej:  1 2 3 4 5 6 masztowiec
        private int _boardSize;

        public GameOptionsPage()
        {
            InitializeComponent();
            GetShipsAmountAndBoardSize();
            ShowAvailableShips();
        }

        //przyciski
        private void PlayButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.ChangeCurrentPage(30);
        }





        //test pokazywania ilosci stakow
        int[] tablica = new int[6] { 1, 2, 3, 1, 5, 1};


        //metody
        private void GetShipsAmountAndBoardSize()
        {
            if (rb_Size6.IsChecked==true)
            {
                _eachShipAmount = new int[]{3,2,0,0,0,0};
                _boardSize = 6;
            }
            else if (rb_Size8.IsChecked == true)
            {
                _eachShipAmount = new int[] { 3, 3, 1, 0, 0, 0 };
                _boardSize = 6;
            }
            else if (rb_Size10.IsChecked == true)
            {
                _eachShipAmount = new int[] { 4, 3, 2, 1, 0, 0 };
                _boardSize = 6;
            }
            else if (rb_Size12.IsChecked == true)
            {
                _eachShipAmount = new int[] { 4, 3, 2, 2, 1, 0 };
                _boardSize = 6;
            }
            else if (rb_Size14.IsChecked == true)
            {
                _eachShipAmount = new int[] { 5, 4, 3, 3, 2, 0 };
                _boardSize = 6;
            }
            else if (rb_Size16.IsChecked == true)
            {
                _eachShipAmount = new int[] { 6, 5, 4, 3, 2, 1 };
                _boardSize = 6;
            }

            //warunek sprawdzajacy radiobutony z iloscia statkow
            int k;
            if (rb_little.IsChecked == true) k = -1;
            else if (rb_many.IsChecked == true) k = 1;
            else k = 0;

            for (int i = 0; i < _eachShipAmount.Length; i++)
            {
                if (_eachShipAmount[i]>0 && _eachShipAmount[i]+k>=0)
                {
                    _eachShipAmount[i] += k;
                }
            }

            ShowAvailableShips();
        }


        private void ShowAvailableShips()
        {
            AvailableShipsStackPanel.Children.Clear(); //czyszczenie stackpanela

            for (int i = 0; i < 6; i++)
            {
                if (_eachShipAmount[i]!=0) //to oznacza że jest jakiś statek danego rodzaju
                {
                    //stack panel zawierajacy w sobie textblocki
                    StackPanel ShipStackPanel = new StackPanel()
                    {
                        MinWidth = 70,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment=HorizontalAlignment.Center,
                        Margin=new Thickness(10,0,10,0)
                        
                    };

                    TextBlock ShipName = new TextBlock()
                    {
                        Text = (i + 1) + "-masztowe:",
                        FontSize = 16,
                        TextAlignment = TextAlignment.Center
                    };                    
                    TextBlock ShipAmount = new TextBlock()
                    {
                        Text = Convert.ToString(_eachShipAmount[i]),
                        FontSize = 24,
                        TextAlignment=TextAlignment.Center                        
                    };

                    ShipStackPanel.Children.Add(ShipName);
                    ShipStackPanel.Children.Add(ShipAmount);

                    //dodanie do glownego stack panela
                    AvailableShipsStackPanel.Children.Add(ShipStackPanel);
                }
            }
        }

        private void RadioButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GetShipsAmountAndBoardSize();
        }
    }
}
