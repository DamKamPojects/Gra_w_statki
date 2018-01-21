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
        public GameWindowPage()
        {
            InitializeComponent();
        }

        private void GameWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var BoardSize = 16; //rozmiar planszy

            //dodaje kolumny nowe
            for (int i = 0; i < BoardSize + 1; i++)
            {
                OurBoard.RowDefinitions.Add(new RowDefinition());
                OurBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 1; i < BoardSize + 1; i++)
            {
                TextBlock xDescriptionBlock = new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = Convert.ToString(i),
                    Margin = new Thickness(1)
                };
                Grid.SetRow(xDescriptionBlock, 0);
                Grid.SetColumn(xDescriptionBlock, i);
                this.OurBoard.Children.Add(xDescriptionBlock);

                TextBlock yDescriptionBlock = new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = Convert.ToString(Convert.ToChar(64 + i)),
                    Margin = new Thickness(0.2)
                };
                Grid.SetRow(yDescriptionBlock, i);
                Grid.SetColumn(yDescriptionBlock, 0);
                this.OurBoard.Children.Add(yDescriptionBlock);
            }

            // tworzy buttony dynamicznie
            for (int i = 1; i < BoardSize + 1; i++)
            {
                for (int j = 1; j < BoardSize + 1; j++)
                {
                    Button FieldButton = new Button();
                    //guzik.Content = "x" + i + "y" + j;
                    FieldButton.Margin = new Thickness(1);
                    FieldButton.Background = Brushes.White;
                    FieldButton.Name = "x" + i + "y" + j;
                    FieldButton.ToolTip = Convert.ToString(FieldButton.Name);
                    Grid.SetRow(FieldButton, i);
                    Grid.SetColumn(FieldButton, j);
                    this.OurBoard.Children.Add(FieldButton);
                }
            }
        }

    }
}
