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

            if (startingDimensions != null) InitializeBoard(startingDimensions);
            if (startingShips != null) InitializeShips(startingShips);
            if (ready) StartGame();
            if (msg != null) ShowMessage(msg);
            if (hit != null) InterpreteHit(hit);
            if (confirmationHit != null) InterpreteConfirmationHit(confirmationHit);
            if (turn != 0) InterpreteTurn(turn);
        }

        



        // region zawierający metody przetwarzające nadchodzące dane
        #region Incoming Strings
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

            string[] Ships = parameters[1].Split('=')[1].Split(',');

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
                                            new UpdateTextCallback(main.Hh),
                                            new object[] { msg + "\n" }
                                            );
           // main.tb_Czat.Text += msg;
        }

        private void InitializeBoard(string startingDimensions)
        {
            int StartingDimensionsToSend = Convert.ToInt32(startingDimensions);
            //wywołanie czegoś z parametrem StartingDimensionsToSend
        }

        private void InitializeShips(string[] startingShips)
        {
            int[] intStartingShips = new int[6];
            for (int i = 0; i < startingShips.Count(); i++)
            {
                intStartingShips[i] = Convert.ToInt32(startingShips[i]);
            }
            //wywołanie czegoś z parametrem intStartingShips
        }

        private void InterpreteConfirmationHit(string[] confirmationHit)
        {
            throw new NotImplementedException();
        }

        private void InterpreteHit(string[] hit)
        {
            throw new NotImplementedException();
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

        public string CreateMessage(string input)
        {
            return "msg = " + Me + ": " + input + Environment.NewLine;
        }

        #endregion

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

        public string GetNickMsg(string nick)
        {
            return "nick = " + nick + Environment.NewLine;
        }
    }
}
