using System.Windows.Controls;
using System.Windows;

namespace Gra_w_statki
{
    /// <summary>
    /// Interaction logic for WaitingPage.xaml
    /// </summary>
    public partial class WaitingPage : Page
    {
        public WaitingPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ChangeCurrentPage(12);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.StartClient(ConnectionPage.Nickname, ConnectionPage.IP, ConnectionPage.Port);

        }
    }
}
