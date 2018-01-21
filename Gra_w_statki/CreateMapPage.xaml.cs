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
    /// Interaction logic for CreateMapPage.xaml
    /// </summary>
    public partial class CreateMapPage : Page
    {
        private int _boardDimension { get; set; } = 10;
        private int[] EachShipAmount { get; set; }
        GameBoard gameBoard = new GameBoard(10);

        
        public CreateMapPage(int dimension)
        {
            InitializeComponent();
            _boardDimension = dimension;
            //tworznie planszy
            CreateEmptyGrid();
            FillGridWIthButtons();
        }





        //Tworzenie planszy

        //metoda tworzaca pustego grida w zaleznosci od rozmiaru planszy
        private void CreateEmptyGrid()
        {
            for (int i = 0; i < _boardDimension + 1; i++)
            {
                OurBoard.RowDefinitions.Add(new RowDefinition());
                OurBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        //wypełnia grida przyciskami
        private void FillGridWIthButtons()
        {
            //tworzenie instancji obiektu tworzacego buttony
            CreateBoardsButton FillBoard = new CreateBoardsButton();

            //stworzenie oznaczen osi
            for (int i = 1; i < _boardDimension + 1; i++)
            {
                //opisanie osi poziomej - x
                this.OurBoard.Children.Add(FillBoard.CreateTextBlock_X(i));

                //opisanie osi pionowej - Y
                this.OurBoard.Children.Add(FillBoard.CreateTextBlock_Y(i));
            }            

            // utworzenie buttonow
            for (int i = 1; i < _boardDimension + 1; i++)
            {
                for (int j = 1; j < _boardDimension + 1; j++)
                {
                    Button FieldButton = FillBoard.CreateButton(i, j);
                    FieldButton.Click += FieldButton_Click;
                    this.OurBoard.Children.Add(FieldButton);
                }
            }
        }


        private void FieldButton_Click(object sender, RoutedEventArgs e)
        {
            int[] cordinates = GetButtonCordinates(((Button)sender).Name);
            int buttonValue=gameBoard.CheckArea(cordinates);

            if (buttonValue==0) //znaczy ze nie ma tam statku
            {
                ((Button)sender).Background = Brushes.LawnGreen;
                gameBoard.ChangeAreaValue(cordinates);
            }
            else
            {
                ((Button)sender).Background = Brushes.White;
                gameBoard.ChangeAreaValue(cordinates);
            }
        }

        //wyciaga wartosc wspolrzednych dabego buttona
        private int[] GetButtonCordinates(string name)
        {
            int[] cordinates = new int[2];

            string[] StringCordinates = name.Split(new char[] { 'y' });
            cordinates[0] = Convert.ToInt32(StringCordinates[0].TrimStart(new char[] { 'x' }));
            cordinates[1] = Convert.ToInt32(StringCordinates[1]);
            return cordinates;
        }
    }
}
