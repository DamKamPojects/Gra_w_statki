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
    /// Interaction logic for SerwerConnectionPage.xaml
    /// </summary>
    public partial class SerwerConnectionPage : Page
    {
        public SerwerConnectionPage()
        {
            InitializeComponent();
        }
        public string PlayerName;

        private void PlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlayerName = tb_PlayerName.Text;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ChangeCurrentPage(10);
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ChangeCurrentPage(20);
            MainWindow.StartServer(tb_PlayerName.Text);
        }
    }
}
