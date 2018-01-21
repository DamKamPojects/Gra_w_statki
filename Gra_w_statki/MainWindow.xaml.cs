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
        //inicjalizacja stron
        GameOptionsPage gameOptions = new GameOptionsPage();
        GameWindowPage gameWindow = new GameWindowPage();
        CreateMapPage createMap = new CreateMapPage(10);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowFrame.Content = gameOptions;
        }

        private void GameWindowButton_Click(object sender, RoutedEventArgs e)
        {
            WindowFrame.Content = gameWindow;
        }

        private void GameOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            WindowFrame.Content = gameOptions;
        }

        private void CreateMapButton_Click(object sender, RoutedEventArgs e)
        {
            WindowFrame.Content = createMap;
        }
    }
}
