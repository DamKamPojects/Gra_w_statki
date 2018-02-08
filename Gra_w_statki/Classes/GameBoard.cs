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
        private int[] _eachShipAmount;

        public GameBoard(int dimension)
        {
            _boardDimension = dimension;
            _board = new int[_boardDimension+ 2, _boardDimension + 2]; //plus jeden z tego względu że 0 kol i wier jest przeznaczony na oznaczenia komórek
            ResetTable();
        }    
        

        //wypelnia tabele zerami; do resetowania
        public void ResetTable()
        {
            for (int i = 0; i < _boardDimension+2; i++)
            {
                for (int j = 0; j < _boardDimension + 2; j++)
                {
                    _board[i, j] = 0;
                }
            }
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
                //MessageBox.Show("Bledna wartosc przycisku: " + value);
            }
            //petla iterujaca po polach na rogach od kliknietego przycisku

            if (k != 0)
            {
                for (int i = -1; i < 2; i = i + 2)
                {
                    for (int j = -1; j < 2; j = j + 2)
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
            }

            return changesList;
        }

        //metoda liczaca postawione statki
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
                        if (_board[i, j] != 1 && _board[i,j] !=5) //sprawdza czy dane pole na planszy zaweiera statek
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

            _eachShipAmount = countedShips;
            return countedShips;
        }

        //szuka kierunku ulozenia danego statku
        private int FindDirection(int i, int j)
        {
            //1-horyzontalny,; -1 wertykalny
            
            //dol
            if (i<_boardDimension+2) 
            {
                if (_board[i + 1, j] > 0 || _board[i -1, j] > 0) // dol
                {
                    return -1; // 
                }
            }
            //prawo
            if (j< _boardDimension+2)
            {
                if (_board[i, j+1] > 0 ||  _board[i, j -1] > 0) // prawo
                {
                    return 1; // 
                }
            }
            return 0;
        }

        //przygotowuje plansze do gry
        public Stack<SingleField> PrepereBoardForGame()
        {
            Stack<SingleField> changesList = new Stack<SingleField>();

            for (int i = 0; i < _boardDimension+1; i++)
            {
                for (int j = 0; j < _boardDimension+1; j++)
                {
                    try
                    {
                        if (_board[i, j] < 1)
                        {
                            //_board[i, j] = 0;
                            changesList.Push(new SingleField(_board[i, j], new int[] { i, j }));
                        }
                    }
                    catch
                    {

                    }
                }
            }

            return changesList;
        }

        //metoda liczaca zniszczone statki
        public int[] CountDestroyedShips()
        {
            int[] countedShips = new int[6] { 0, 0, 0, 0, 0, 0 }; //tablica statkow
            int[,] temporaryTable = new int[_boardDimension + 1, _boardDimension + 1]; //sluzy tylko i wylacznie do policzenia statkow

            //tworzy pusta tablice
            for (int i = 0; i < _boardDimension + 1; i++)
            {
                for (int j = 0; j < _boardDimension + 1; j++)
                {
                    temporaryTable[i, j] = 0;
                }
            }

            //liczenie
            for (int i = 0; i < _boardDimension + 1; i++)
            {
                for (int j = 0; j < _boardDimension + 1; j++)
                {
                    if (temporaryTable[i, j] == 0) //sprawdza czy dane pole zostalo juz sprawdozpne wczensiej
                    {
                        if (_board[i, j] != 5) //sprawdza czy dane pole na planszy zaweiera statek
                        {
                            temporaryTable[i, j] = 1;//1 oznacza sprawdzone pole
                        }
                        else //znaleziony został statek
                        {
                            temporaryTable[i, j] = 1;
                            int shipSize = 1; //rozmiar statku
                            int direction = FindDirection(i, j);

                            //liczenie stakow
                            if (direction == 0)
                            {
                                countedShips[0]++;
                                temporaryTable[i, j] = 1;
                            }
                            else if (direction == 1)
                            {
                                int indexY = j;
                                while (true) //prawo
                                {
                                    indexY++;
                                    try
                                    {
                                        if (_board[i, indexY] == 5)
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
                                        if (_board[indexX, j] == 5)
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

            int[] remainingShips = new int[6];
            for (int i = 0; i < 6; i++)
            {
                remainingShips[i] = _eachShipAmount[i] - countedShips[i];
            }

            return remainingShips;
        }

        public int GetFieldValue(int[] cordinates)
        {
            return _board[cordinates[0], cordinates[1]];
        }


        //metody oblsugujace nasza plansze w trakcie gry
        public Stack<SingleField> GameChangeFieldValue(int[] cordinates)
        {
            //przypisanie wspolrzednych aktualnie wybranego pola; ulatwia dalsze operacje
            int x = cordinates[0];
            int y = cordinates[1];
            int value = _board[x, y];

            Stack<SingleField> ChangesList = new Stack<SingleField>();

            if (value==1)
            {
                _board[x, y] = 5;
                

                ChangesList = GameChangeSurroundingFieldValue(x, y, value);
                ChangesList.Push(new SingleField(_board[x, y], new int[] { x, y }));
            }
            else if(value<1 && value>-5) //pudło
            {
                _board[x, y] = -5;
                ChangesList.Push(new SingleField(_board[x, y], new int[] {x, y}));
            }                         

            return ChangesList;
        }

        //metoda zmieniająca sąsiednie pola
        private Stack<SingleField> GameChangeSurroundingFieldValue(int x, int y, int value)
        {
            Stack<SingleField> changesList = new Stack<SingleField>();
            int direction = FindDirection(x, y);

            if (direction==0) //jednomasztowiec
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        try
                        {
                            if (i!=0 || j!=0)
                            { 
                                _board[x + i, y + j] = -5;
                                changesList.Push(new SingleField(_board[x + i, y + j], new int[] { x + i, y + j }));
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            else if (direction==1) //horyzontalnie polozony statek
            {
                if (_board[x,y+1]==1 || _board[x,y-1]==1) //czyli po lewo lub prawo znajujde się niezatopiony statek
                {
                    for (int i = -1; i < 2; i = i + 2)
                    {
                        for (int j = -1; j < 2; j = j + 2)
                        {
                            try
                            {
                                _board[x + i, y + j] = -5;
                                changesList.Push(new SingleField(_board[x + i, y + j], new int[] { x + i, y + j }));
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                else
                {
                    //znajduje poczatek i koniec statku
                    int minIndex=y, maxIndex=y;
                    //lewo
                    while (true)
                    {
                        if (_board[x,minIndex-1]>0)
                        {
                            minIndex--;
                        }
                        else
                        {
                            break;
                        }
                    }

                    //prawo
                    while (true)
                    {
                        if (_board[x, maxIndex + 1] > 0)
                        {
                            maxIndex++;
                        }

                        else
                        {
                            break;
                        }
                    }

                    _board[x, minIndex - 1] = -5;
                    changesList.Push(new SingleField(_board[x, minIndex - 1], new int[] { x, minIndex-1 }));

                    _board[x, maxIndex +1] = -5;
                    changesList.Push(new SingleField(_board[x, maxIndex +1], new int[] { x, maxIndex +1}));

                    if (maxIndex + 1 < _boardDimension + 2)
                    {
                        _board[x, maxIndex + 1] = -5;
                        changesList.Push(new SingleField(_board[x, maxIndex + 1], new int[] { x, maxIndex + 1 }));
                    }

                    for (int i = minIndex-1; i < maxIndex+2; i++)
                    {
                        if (i +1 < _boardDimension + 2)
                        {
                            _board[x-1, i] = -5;
                            changesList.Push(new SingleField(_board[x-1,i], new int[] { x-1, i }));

                            if (x+1<_boardDimension+2)
                            {
                                _board[x + 1, i] = -5;
                                changesList.Push(new SingleField(_board[x + 1, i], new int[] { x + 1, i }));
                            }
                        }                        
                    }
                }
            }
            else if (direction == -1) //horyzontalnie polozony statek
            {
                if (_board[x+1, y] == 1 || _board[x-1,y] == 1) //
                {
                    for (int i = -1; i < 2; i = i + 2)
                    {
                        for (int j = -1; j < 2; j = j + 2)
                        {
                            try
                            {
                                _board[x + i, y + j] = -5;
                                changesList.Push(new SingleField(_board[x + i, y + j], new int[] { x + i, y + j }));
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                else
                {
                    //znajduje poczatek i koniec statku
                    int minIndex = x, maxIndex = x;
                    //lewo
                    while (true)
                    {
                        if (_board[minIndex - 1,y] > 0)
                        {
                            minIndex--;
                        }
                        else
                        {
                            break;
                        }
                    }

                    //prawo
                    while (true)
                    {
                        if (_board[maxIndex + 1,y] > 0)
                        {
                            maxIndex++;
                        }

                        else
                        {
                            break;
                        }
                    }

                    _board[minIndex - 1,y] = -5;
                    changesList.Push(new SingleField(_board[minIndex - 1, y], new int[] { minIndex - 1, y }));

                    _board[maxIndex + 1, y] = -5;
                    changesList.Push(new SingleField(_board[maxIndex + 1, y], new int[] { maxIndex + 1, y }));

                    if (maxIndex + 1 < _boardDimension + 2)
                    {
                        _board[maxIndex + 1,y] = -5;
                        changesList.Push(new SingleField(_board[maxIndex + 1, y], new int[] { maxIndex + 1, y }));
                    }

                    for (int i = minIndex - 1; i < maxIndex + 2; i++)
                    {
                        if (i + 1 < _boardDimension + 2)
                        {
                            _board[i, y-1] = -5;
                            changesList.Push(new SingleField(_board[i, y - 1], new int[] { i, y - 1 }));

                            if (y + 1 < _boardDimension + 2)
                            {
                                _board[i, y + 1] = -5;
                                changesList.Push(new SingleField(_board[i, y + 1], new int[] { i, y + 1 }));
                            }
                        }
                    }
                }
            }
            return changesList;
        }
    }
}
