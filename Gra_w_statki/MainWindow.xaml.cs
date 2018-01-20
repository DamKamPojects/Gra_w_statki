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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var powt = 10;
            //dodaje kolumny nowe
            for (int i = 0; i < powt + 1; i++)
            {
                OurBoard.RowDefinitions.Add(new RowDefinition());
                OurBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 1; i < powt + 1; i++)
            {
                TextBlock textblockx = new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = Convert.ToString(i),
                    //FontSize = 20,
                    Margin = new Thickness(1)
                };
                Grid.SetRow(textblockx, 0);
                Grid.SetColumn(textblockx, i);
                this.OurBoard.Children.Add(textblockx);

                TextBlock textblocky = new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = Convert.ToString(Convert.ToChar(64 + i)),
                    //FontSize = 20,
                    Margin = new Thickness(0.5)
                };
                Grid.SetRow(textblocky, i);
                Grid.SetColumn(textblocky, 0);
                this.OurBoard.Children.Add(textblocky);
            }

            // tworzy buttony dynamicznie
            for (int i = 1; i < powt + 1; i++)
            {
                for (int j = 1; j < powt + 1; j++)
                {
                    Button guzik = new Button();
                    //guzik.Content = "x" + i + "y" + j;
                    guzik.Margin = new Thickness(1);
                    guzik.Background = Brushes.White;
                    guzik.Name = "x" + i + "y" + j;
                    Grid.SetRow(guzik, i);
                    Grid.SetColumn(guzik, j);
                    this.OurBoard.Children.Add(guzik);
                }
            }            
        }


    }
}
