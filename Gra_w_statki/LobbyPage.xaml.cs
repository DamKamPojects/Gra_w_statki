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
    /// Interaction logic for LobbyPage.xaml
    /// </summary>
    public partial class LobbyPage : Page
    {
        private static event EventHandler EventGetPlayerBoard;
        private static event EventHandler EventGetEachShipAmount;
        private static event EventHandler EventGetBoardSize;
        private static event EventHandler EventGetShipAmountInfo;
        private BoardPage _ourBoard;
        private int[] _eachShipAmount;
        private int[] _boardSize;

        //kontruktory
        public LobbyPage()
        {
            InitializeComponent();
            EventGetPlayerBoard += new EventHandler(_getPlayerBoard);
            EventGetEachShipAmount += new EventHandler(_getEachShipAmount);
            EventGetBoardSize += new EventHandler(_getBoardSize);
            EventGetShipAmountInfo += new EventHandler(_getShipAmountInfo);
        }



        //przyciski

        private void ChangeMap_Click(object sender, RoutedEventArgs e)
        {
            CreateMapPage.GetPlayerBoard((BoardPage)LobbyBoardFrame.Content);
            MainWindow.ChangeCurrentPage(30);
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ChangeCurrentPage(50);
            GameWindowPage.GetPlayerBoard(_ourBoard);
            GameWindowPage.GetShipAmount(_eachShipAmount);
        }


        //metody
        //1 event
        public static void GetPlayerBoard(BoardPage ourBoard)
        {
            EventGetPlayerBoard?.Invoke(ourBoard, new EventArgs());
        }

        //2 event - odbiera opcje gry z gameOptionsPage
        public static void GetGameOptions(int[] eachShipAmount, int boardSize, string shipAmountComment)
        {
            EventGetEachShipAmount?.Invoke(eachShipAmount, new EventArgs());
            EventGetBoardSize?.Invoke(boardSize, new EventArgs());
            EventGetShipAmountInfo?.Invoke(shipAmountComment, new EventArgs());
        }

        //1 event-metoda
        private void _getPlayerBoard(object sender, EventArgs e)
        {
            _ourBoard = (BoardPage)sender;
            LobbyBoardFrame.Content = _ourBoard;
        }
        

        
        //2 event - metody
        private void _getEachShipAmount(object sender, EventArgs e)
        {
            _eachShipAmount = (int[])sender;
        }

        private void _getBoardSize(object sender, EventArgs e)
        {
            tb_boardSize.Text = (int)sender + "x" + (int)sender;
        }

        private void _getShipAmountInfo(object sender, EventArgs e)
        {
            tb_shipsAmount.Text = (string)sender;
        }



    }
}
