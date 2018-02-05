using System.Windows.Controls;
using System;
using System.Windows;
using System.Collections.Generic;

namespace Gra_w_statki
{
    //klasa tworzaca plansze
    class GameBoard
    {
        public int _boardDimension; //wymiar planszy
        private int[,] _board { get; set; } // deklaracja planszy

        public GameBoard(int dimension)
        {
            _boardDimension = dimension;
            _board = new int[_boardDimension+ 1, _boardDimension + 1]; //plus jeden z tego względu że 0 kol i wier jest przeznaczony na oznaczenia komórek
            ResetTable();
        }    
        
        //wypelnia tabele zerami; do resetowania
        public void ResetTable()
        {
            for (int i = 0; i < _boardDimension+1; i++)
            {
                for (int j = 0; j < _boardDimension + 1; j++)
                {
                    _board[i, j] = 0;
                }
            }
        }

        //sprawdza jaka wartosc //do usuniecia
        public int CheckArea(int[] cordinates)
        {
            return _board[cordinates[0], cordinates[1]];
        }

        //metoda zmieniajaca wartosci pol
        public Stack<SingleField> ChangeFieldValue(int[] cordinates)
        {
            //przypisanie wspolrzednych aktualnie wybranego pola; ulatwia dalsze operacje
            int x = cordinates[0];
            int y = cordinates[1];
            int value = _board[x, y];

            Stack<SingleField> ChangesList = ChangeSurroundingFieldValue(x, y, value);
            //to oznacza że jest pusty
            if (_board[x, y] == 0)
            {
                _board[x, y] = 1;
            }
            //to oznacza ze juz coś w nim jest
            else if (_board[x, y] == 1)
            {
                _board[x, y] = 0;
            }
            ChangesList.Push(new SingleField(_board[x, y], new int[] {x, y}));

            return ChangesList;
        }

        //metoda zmieniająca sąsiednie pola
        private Stack<SingleField> ChangeSurroundingFieldValue(int x, int y, int value)
        {
            Stack<SingleField> changesList = new Stack<SingleField>();

            int k=0;
            if (value==0)
            {
                k = -1;
            }
            else if(value==1)
            {
                k = 1;
            }
            else
            {
                MessageBox.Show("Bledna wartosc przycisku: " + value);
            }
            //petla iterujaca po polach na rogach od kliknietego przycisku
            for (int i = -1 ; i < 2; i=i+2)
            {
                for (int j = -1; j < 2; j=j+2)
                {
                    _board[x + i, y + j] += k;
                    changesList.Push(new SingleField(_board[x + i, y + j], new int[]{x+i, y+j}));
                }
            }

            return changesList;
        }
        
    }
}
