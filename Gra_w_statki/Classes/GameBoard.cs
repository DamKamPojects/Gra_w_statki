using System.Windows.Controls;
using System;
using System.Windows;
using System.Collections.Generic;

namespace Gra_w_statki
{
    //klasa tworzaca plansze
    class GameBoard
    {
        //zmienne
        public int _boardDimension; //wymiar planszy
        private int[,] _board; // deklaracja planszy

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
                    try
                    {
                        _board[x + i, y + j] += k;
                        changesList.Push(new SingleField(_board[x + i, y + j], new int[] { x + i, y + j }));                        
                    }
                    catch
                    {

                    }
                }
            }

            return changesList;
        }

        public int[] CountShips()
        {
            int[] countedShips = new int[6] { 0, 0, 0, 0, 0, 0 }; //tablica statkow
            int[,] temporaryTable = new int[_boardDimension+1,_boardDimension+1]; //sluzy tylko i wylacznie do policzenia statkow

            //tworzy pusta tablice
            for (int i = 0; i < _boardDimension+1; i++)
            {
                for (int j = 0; j < _boardDimension + 1; j++)
                {
                    temporaryTable[i, j] = 0;
                }
            }


            for (int i = 0; i < _boardDimension + 1; i++)
            {
                for (int j = 0; j < _boardDimension + 1; j++)
                {
                    if (temporaryTable[i,j]==0) //sprawdza czy dane pole zostalo juz sprawdozpne wczensiej
                    {
                        if (_board[i, j] != 1) //sprawdza czy dane pole na planszy zaweiera statek
                        {
                            temporaryTable[i, j] = 1;//1 oznacza sprawdzone pole
                        }
                        else //znaleziony został statek
                        {
                            temporaryTable[i, j] = 1;
                            int shipSize = 1; //rozmiar statku
                            int direction = FindDirection(i, j);

                            //liczenie stakow
                            if (direction==0)
                            {
                                countedShips[0]++;
                                temporaryTable[i, j] = 1;
                            }
                            else if (direction==1)
                            {
                                int indexY = j;
                                while(true) //prawo
                                {
                                    indexY++;
                                    try
                                    {
                                        if (_board[i,indexY] == 1)
                                        {
                                            temporaryTable[i, indexY] = 1;
                                            shipSize++;
                                        }
                                        else
                                        {
                                            temporaryTable[i, indexY] = 1;
                                            break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        break;
                                    } 
                                }
                            }
                            else if (direction == -1)
                            {
                                int indexX = i;
                                while (true) //prawo
                                {
                                    indexX++;
                                    try
                                    {
                                        if (_board[indexX,j] == 1)
                                        {
                                            temporaryTable[indexX, j] = 1;
                                            shipSize++;
                                        }
                                        else
                                        {
                                            temporaryTable[indexX, j] = 1;
                                            break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        break;
                                    }
                                }
                            }


                            if (shipSize < 7 && direction != 0)
                            {
                                countedShips[shipSize - 1]++;
                            }
                        }
                    }
                    
                }
            }


            return countedShips;
        }

        //szuka kierunku ulozenia danego statku
        private int FindDirection(int i, int j)
        {
            //int direction = 0; //1-horyzontalny,; -1 wertykalny
            //okreslanieorientacji statku

            //dol
            if (i<_boardDimension) 
            {
                if (_board[i + 1, j] == 1) // dol
                {
                    return -1; // 
                }
            }

            //gora
            //if (_board[i - 1, j] == 1) // to znaczy ze po lewo lub prawo jest dalsza czesc statku
            //{
            //    return -1; // gora
            //}

            //prawo
            if (j< _boardDimension)
            {
                if (_board[i, j+1] == 1) // prawo
                {
                    return 1; // 
                }
            }

            //lewo
            //if (_board[i, j - 1] == 1) // lewo
            //{
            //    return 1; // 
            //}
            return 0;
        }
    }
}
