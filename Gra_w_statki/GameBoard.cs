using System.Windows.Controls;

namespace Gra_w_statki
{
    //klasa tworzaca plansze
    class GameBoard
    {
        private Grid Board = new Grid();
        public int _boardDimension { get; private set; } = 10; //wymiar planszy
        private int[,] _board { get; set; } // deklaracja planszy

        public GameBoard(int dimension)
        {
            _boardDimension = dimension;
            _board = new int[_boardDimension+ 1, _boardDimension + 1]; //plus jeden z tego względu że 0 kol i wier jest przeznaczony na oznaczenia komórek   
            FillTableWithZeros();
        }    
        
        //wypelnia tabele zerami; do resetowania
        public void FillTableWithZeros()
        {
            for (int i = 0; i < _boardDimension+1; i++)
            {
                for (int j = 0; j < _boardDimension + 1; j++)
                {
                    _board[i, j] = 0;
                }
            }
        }

        //sprawdza jaka wartosc 
        public int CheckArea(int[] cordinates)
        {
            return _board[cordinates[0], cordinates[1]];
        }

        public void ChangeAreaValue(int[] cordinates)
        {
            int x = cordinates[0];
            int y = cordinates[1];
            int value = _board[x, y];
            //to oznacza że jest pusty
            if (_board[x, y] == 0)
            {
                _board[x, y] = 1;
            }
            else if (_board[x, y] == 1)
            {
                _board[x, y] = 0;
            }
        }
    }
}
