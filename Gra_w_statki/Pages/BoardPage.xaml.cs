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
    /// Interaction logic for BoardPage.xaml
    /// </summary>
    public partial class BoardPage : Page
    {
        //zmienne
        GameBoard gameBoard;
        public bool CanBeChanged = true;
        public int BoardSize;
        private int[] EachShipAmount;

        public BoardPage()
        {
            InitializeComponent();
        }

        public BoardPage(int dimension)
        {
            InitializeComponent();
            BoardSize = dimension;

            CreateEmptyGrid();
            FillGridWIthButtons();

            gameBoard= new GameBoard(dimension);
        }

        
        #region Tworzenie siatki z przyciskami
        //metoda tworzaca pustego grida w zaleznosci od rozmiaru planszy
        private void CreateEmptyGrid()
        {
            for (int i = 0; i < BoardSize + 1; i++)
            {
                Board.RowDefinitions.Add(new RowDefinition());
                Board.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        //wypełnia grida przyciskami
        private void FillGridWIthButtons()
        {
            var brushes = Brushes.Red;
            //tworzenie instancji obiektu tworzacego buttony
            CreateBoardsButton FillBoard = new CreateBoardsButton();

            //stworzenie oznaczen osi
            for (int i = 1; i < BoardSize + 1; i++)
            {
                //opisanie osi poziomej - x
                this.Board.Children.Add(FillBoard.CreateTextBlock_X(i));

                //opisanie osi pionowej - Y
                this.Board.Children.Add(FillBoard.CreateTextBlock_Y(i));
            }


            // utworzenie buttonow
            for (int i = 1; i < BoardSize + 1; i++)
            {
                for (int j = 1; j < BoardSize + 1; j++)
                {
                    Button FieldButton = FillBoard.CreateButton(i, j);
                    FieldButton.Click += FieldButton_Click;
                    this.Board.Children.Add(FieldButton);
                }
            }
        }
        #endregion


        //I.metoda dotyczaca klikniecia przycisku
        private void FieldButton_Click(object sender, RoutedEventArgs e)
        {
            if (CanBeChanged==true)
            {
                int[] cordinates = GetButtonCordinates(((Button)sender).Name);

                BoardFieldModification(cordinates);
                CreateMapPage.CountShips(GetShipsAmount());
            }            
        }
        
        //II.wyciaga wartosc wspolrzednych dabego buttona
        private int[] GetButtonCordinates(string name)
        {
            int[] cordinates = new int[2];

            string[] StringCordinates = name.Split(new char[] { 'y' });
            cordinates[0] = Convert.ToInt32(StringCordinates[0].TrimStart(new char[] { 'x' }));
            cordinates[1] = Convert.ToInt32(StringCordinates[1]);
            return cordinates;
        }

        //III. Zmienia wartosci pol
        private void BoardFieldModification(int[] cordinates)
        {
            Stack<SingleField> ChangesStack = gameBoard.ChangeFieldValue(cordinates);

            while(ChangesStack.Count !=0)
            {
                SingleField element = ChangesStack.Pop();

                ChangeButtonColor(element);
                
            }
        }

        //sprawdza wartosc przycisku o podanej nazwie
        private void ChangeButtonColor(SingleField element)
        {
            string buttonName = "x" + element.Cordinates[0] + "y" + element.Cordinates[1];

            //wyszukiwanie przycisku
            DependencyObject dependencyObject = Content as DependencyObject;
            try
            {
                Button button = LogicalTreeHelper.FindLogicalNode(dependencyObject, buttonName) as Button;
                button.Background = GetButtonColor(element.Value);
                button.Content = Convert.ToString(element.Value);
                //if (element.Value==0 || element.Value==1)
                //{
                //    button.IsEnabled = true;
                //}
                //else
                //{
                //    button.IsEnabled = false;
                //}
            }
            catch (Exception)
            {
            }
        }

        //resetuje kolory wszystkich przycisksow
        public void PrepereButtonsForGame()
        {
            Stack<SingleField> ChangesStack = gameBoard.PrepereBoardForGame();
            while (ChangesStack.Count != 0)
            {
                SingleField element = ChangesStack.Pop();

                ChangeButtonColor(element);
            }
        }

        //metoda zwracajaca kolor dla przyciskow w zaleznosci od wartosci pola
        private SolidColorBrush GetButtonColor(int k)
        {
            switch(k)
            {
                case 0:
                    {
                        return Brushes.White;
                    }
                case 1:
                    {
                        return Brushes.ForestGreen;
                    }
                case -5:
                    {
                        return Brushes.Orange;
                    }
                //case -1:
                //    {
                //        return Brushes.DarkGray;
                //    }
                //case -2:
                //    {
                //        return Brushes.DimGray;
                //    }
                //case -3:
                //    {
                //        return Brushes.DarkSlateBlue;
                //    }
                //case -4:
                //    {
                //        return Brushes.Black;
                //    }
                case 5: //oznacza że statek został trafiony
                    {
                        return Brushes.DarkRed;
                    }

                default:
                    {
                        if (CanBeChanged==false)
                        {
                            return Brushes.White;
                        }
                        else return Brushes.Silver;
                    }
            }
        }

        //pobiera ilości poszczególnych statków
        public int[] GetShipsAmount()
        {
            return gameBoard.CountShips();
        }

        public int[] GetRemainingShipsAmount()
        {
            return gameBoard.CountDestroyedShips();
        }
               

        public int CheckField(int[] cordinates)
        {
            int FieldValue = gameBoard.GetFieldValue(cordinates);

            Stack<SingleField> ChangesStack = gameBoard.GameChangeFieldValue(cordinates);
            while (ChangesStack.Count != 0)
            {
                SingleField element = ChangesStack.Pop();

                ChangeButtonColor(element);
            }

            return FieldValue;
        }
    }
}
