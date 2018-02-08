using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gra_w_statki.Classes
{
    class StringHandler
    {
        int PlayerNumber; // w metodzie CheckStartingDimensions wpisywana jako 2 - gracz odbierający parametry jest graczem nr 2
        MainWindow main;
        public string Opponent;
        public string Me;

        public delegate void UpdateTextCallback(string message);

        
        public StringHandler(MainWindow Main, int player)
        {
            main = Main;
            PlayerNumber = player;
        }

        public void DecodeIncomingString(string input)
        {

            string msg = CheckMessage(input);
            string startingDimensions = CheckStartingDimensions(input);
            string[] startingShips = CheckStartingShips(input);
            string[] hit = CheckHit(input);
            string[] confirmationHit = CheckConfirmationHit(input);
            bool ready = CheckReady(input);
            int turn = CheckTurn(input);

            //if (startingDimensions != null) InitializeBoard(startingDimensions);
            //if (startingShips != null) InitializeShips(startingShips);
            if (startingDimensions != null && startingShips != null) InitializeBoard(startingDimensions, startingShips);
            if (ready) StartGame();
            if (msg != null) ShowMessage(msg);
            if (hit != null) InterpreteHit(hit);
            if (confirmationHit != null) InterpreteConfirmationHit(confirmationHit);
            if (turn != 0) InterpreteTurn(turn);
        }





        // region zawierający metody przetwarzające nadchodzące dane
        #region Incoming Strings

        public string GetNick(string line)
        {
            var splittedLine = line.Split(' ');
            string output = null;
            if (splittedLine[0] == "nick")
            {
                for (int i = 2; i < splittedLine.Count(); i++)
                {
                    output += splittedLine[i] + " ";
                }

            }
            else return null;
            Opponent = output;
            return output;
        }

        private string CheckMessage(string input)
        {
            var splittedLine = input.Split(' ');
            string output = null;
            if (splittedLine[0] == "msg")
            {
                for (int i = 2; i < splittedLine.Count(); i++)
                {
                    output += splittedLine[i] + " ";
                }
                   
             }
            else return null;

            return output;
        }

        private string CheckStartingDimensions(string input)
        {
            var splittedLine = input.Split(' ');
            string[] parameters;
            if (splittedLine[0] == "start") parameters = splittedLine[1].Split('|');
            else return null;

           // PlayerNumber = 2;
            string size = parameters[0].Split('=')[1];
            //string Y = parameters[1].Split('=')[1];


            return size;
        }

        private string[] CheckStartingShips(string input)
        {
            var splittedLine = input.Split(' ');
            string[] parameters;
            if (splittedLine[0] == "start") parameters = splittedLine[1].Split('|');
            else return null;

            //var separator = new char[] { ',' };
            string[] Ships = parameters[1].Split('=')[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return Ships;
        }

        private bool CheckReady(string input)
        {
            var splittedLine = input.Split(' ');
            if (splittedLine[0] == "ready")
            {
                if (splittedLine[1] == "True") return true;
                else return false;
            }
            else return false;
        }

        private string[] CheckHit(string input)
        {
            var splittedLine = input.Split(' ');
            var output = (splittedLine[0] == "hit") ? splittedLine[2].Split(',') : null;

            return output;
        }

        private string[] CheckConfirmationHit(string input)
        {
            var splittedLine = input.Split(' ');
            var output = (splittedLine[0] == "confirmationHit") ? splittedLine[2].Split('|') : null;

            return output;
        }

        private int CheckTurn(string input)
        {
            var splittedLine = input.Split(' ');
            int output = 0;
            output = (splittedLine[0] == "turn") ? Convert.ToInt32(splittedLine[2]) : 0;



            return output;

        }
        #endregion

        // region zawierający metody interpretujące przetworzone dane
        #region Interpreting Data

        private  void ShowMessage(string msg)
        {
            Application.Current.Dispatcher.Invoke(
                                            new UpdateTextCallback(main.UpdateText),
                                            new object[] { msg + "\n" }
                                            );
           // main.tb_Czat.Text += msg;
        }

        public void InitializeBoard(string startingDimensions, string[] startingShips)
        {
            int[] intStartingShips = new int[6];
            for (int i = 0; i < startingShips.Count(); i++)
            {
                intStartingShips[i] = Convert.ToInt32(startingShips[i]);
            }
            int StartingDimensionsToSend = Convert.ToInt32(startingDimensions);
            CreateMapPage.CreateNewMap(StartingDimensionsToSend, intStartingShips);

        }

        //private void InitializeBoard(string startingDimensions)
        //{
        //    int StartingDimensionsToSend = Convert.ToInt32(startingDimensions);
        //    //wywołanie czegoś z parametrem StartingDimensionsToSend
        //}

        //private void InitializeShips(string[] startingShips)
        //{
        //    int[] intStartingShips = new int[6];
        //    for (int i = 0; i < startingShips.Count(); i++)
        //    {
        //        intStartingShips[i] = Convert.ToInt32(startingShips[i]);
        //    }
        //    //wywołanie czegoś z parametrem intStartingShips
        //}

        private void InterpreteConfirmationHit(string[] confirmationHit)
        {
            bool hit = (confirmationHit[0] == "True") ? true : false;
            var coordsS = confirmationHit[1].Split(',');
            int[] coords = new int[] { Convert.ToInt32(coordsS[0]), Convert.ToInt32(coordsS[1]) };
            int sinkedSize = Convert.ToInt32(confirmationHit[2]);

            /*
             * Tutaj metoda lub event robiący coś z danymi
             * */
        }

        private void InterpreteHit(string[] hit)
        {
            var coords = new int[] { Convert.ToInt32(hit[0]), Convert.ToInt32(hit[1]) };

            /*
             * Tutaj metoda lub event robiący coś z danymi
             * */
        }

        private void StartGame()
        {
            throw new NotImplementedException();
        }

        private void InterpreteTurn(int turn)
        {
            if (turn == PlayerNumber) return;   //zmiana flagi gdzieś w kodzie
            
        }
        #endregion

        #region Creating data to send

        public string CreateNickMsg(string nick)
        {
            return "nick = " + nick + Environment.NewLine;
        }

        public string CreateMessage(string input)
        {
            return "msg = " + Me + ": " + input + Environment.NewLine;
        }

        public string CreateStartingParameters(int Dimensions, int[] Ships)
        {
            var output = "start = ";
            output += "size=" + Dimensions.ToString() + "|ships=";
            foreach (var ship in Ships)
            {
                output += ship.ToString()+",";
            }
            output += Environment.NewLine;

            return output;
        }

        public string CreateTurnChangeSignal()
        {
            if (PlayerNumber == 1) return "turn = " + 2.ToString() + Environment.NewLine;
            else return "turn = " + 1.ToString() + Environment.NewLine;
        }

        public string CreateHit(int[] coords)
        {
            return "hit = " + coords[0].ToString() + "," + coords[1].ToString() + Environment.NewLine;
        }

        public string CreateConfirmationHit(bool hit, int[] coords, int sinkedSize)
        {
            return "confirmationHit = " + hit.ToString() + "|" + coords[0].ToString() + "," + coords[1].ToString() + "|" + sinkedSize.ToString() + Environment.NewLine;
        }

        public string CreateReadySignal()
        {
            return "ready = True" + Environment.NewLine;
        }
        #endregion

        

        

    }
}
