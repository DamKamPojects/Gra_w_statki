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
    /// Interaction logic for ConnectionPage.xaml
    /// </summary>
    public partial class ConnectionPage : Page
    {
        public ConnectionPage()
        {
            InitializeComponent();
        }
        public static string Nickname;
        public static string IP;
        public static string Port;
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            Nickname = PlayerName.Text;
            IP = IPAdress.Text;
            Port = PortNumber.Text;
            MainWindow.ChangeCurrentPage(11);
        }
    }
}
