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
            MainWindow.ChangeCurrentPage(20);
        }
    }
}
