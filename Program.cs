using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {

        //Variables 
        public static string[] board = new string[9] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };

        static string[] player = new string[] { "Player 1", "Player 2" };

        static string[] playerPiece = new string[] { "X", "O" };

        static int playerIndex;
        static int result;
       

        public static bool gameIsOver = false;
        
        //Draws board to the console with values from board array.c
        public static void drawBoard()
        {
            Console.Clear();
            Console.WriteLine(" {0}  |  {1}  |  {2} ", board[0], board[1], board[2]);
            Console.WriteLine("____|_____|____");
            Console.WriteLine(" {0}  |  {1}  |  {2} ", board[3], board[4], board[5]);
            Console.WriteLine("____|_____|____");
            Console.WriteLine(" {0}  |  {1}  |  {2} ", board[6], board[7], board[8]);
        }

        //Main game loop
        public static void Main(string[] args)
        {

            do
            {
                //Draw the board
                drawBoard();

                //Get player input and validate
                askForInput();

                //Check if someone wins
                checkWin();

                //Checks win condition and assigns winner then displays result of the game to the console.
                if (result == 1)
                {
                    Console.WriteLine($"The winner is {player[1 - playerIndex]}!");
                    gameIsOver = true;
                }
                else if(result == -1)
                {
                    Console.WriteLine("Draw");

                    
                }


            }
            while (gameIsOver != true);

        }


        //Ask for input function
        public static void askForInput()
        {
            //Asks for player input and assigns it to a variable
            Console.WriteLine("{0} enter your choice: ", player[playerIndex]);
            string playerInput = Console.ReadLine();

            //Variables for function.
            //Player choice is the input parsed to an int
            //isValid is used to check the validity of the input
            int playerChoice;
            bool isValid = false;

            bool isNumber = int.TryParse(playerInput, out playerChoice);


            if (board[playerChoice] == "X" || board[playerChoice] == "O")
            {
                Console.WriteLine("That spot is taken");
                askForInput();
                isValid = false;
            }

            else if (!isNumber)
            {
                Console.WriteLine("Not a number enter a number:");
                askForInput();
                isValid = false;
            }

            else if (playerChoice > 8 || playerChoice < 0)
            {
                isValid = false;
                askForInput();
            }

            else
            {
                isValid = true;
            }

            //In the end if the input is valid then the board array is updated and the new board is drawn to the console
            if (isValid)
            {
                board[playerChoice] = playerPiece[playerIndex];
                drawBoard();
                playerIndex = 1 - playerIndex;
            }
        }



        //Checking Win Conditions
        public static int checkWin()
        {
            //ROWS
            if (board[0] == board[1] && board[1] == board[2])
            {
                result = 1;
            }
            if (board[3] == board[4] && board[4] == board[5])
            {
                result = 1;
            }
            if (board[6] == board[7] && board[7] == board[8])
            {
                result = 1;
            }

            //COLUMNS

            if (board[0] == board[3] && board[3] == board[6])
            {
                result = 1;
            }
            if (board[1] == board[4] && board[4] == board[7])
            {
                result = 1;
            }
            if (board[2] == board[5] && board[5] == board[8])
            {
                result = 1;
            }

            //DIAGNOLS
            if (board[0] == board[4] && board[4] == board[8])
            {
                result = 1;
            }
            if (board[2] == board[4] && board[4] == board[6])
            {
                result = 1;
            }

            //STALEMATE
            if (board[1] != "0" && board[1] != "1" && board[2] != "2" && board[3] != "3" && board[4] != "4" && board[5] != "5" && board[6] != "6" && board[7] != "7" && board[8] != "8")
            {
                result = -1;
            }


            return result;
        }
    }
}
