using System;

namespace TicTacToe
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // making array of 0 to 9 but we will not be using the zero in this array.

        static string player1Name;
        static string player2Name;

        static char player1Symbol;
        static char player2Symbol;

        static string checkSymbol;
        static string winner;

        static void printBoard()
        {
            Console.WriteLine($"{player1Name} = {player1Symbol}");
            Console.WriteLine($"{player2Name} = {player2Symbol}");

            Console.WriteLine("\n *************************");
            Console.WriteLine(" *       *       *       *");
            Console.WriteLine(" *   {0}   *   {1}   *   {2}   *", arr[1], arr[2], arr[3]);
            Console.WriteLine(" *       *       *       *");
            Console.WriteLine(" *************************");

            Console.WriteLine(" *       *       *       *");
            Console.WriteLine(" *   {0}   *   {1}   *   {2}   *", arr[4], arr[5], arr[6]);
            Console.WriteLine(" *       *       *       *");
            Console.WriteLine(" *************************");

            Console.WriteLine(" *       *       *       *");
            Console.WriteLine(" *   {0}   *   {1}   *   {2}   *", arr[7], arr[8], arr[9]);
            Console.WriteLine(" *       *       *       *");
            Console.WriteLine(" *************************");

        } // This function prints the Board state + giving the players the information about their symbols. --  O / X 

        static void introduction()
        {
            Console.WriteLine("Player 1 please enter your name: ");
            player1Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Player 2 please enter your name: ");
            player2Name = Console.ReadLine();
            Console.Clear();
        } // This function asks for the names of the players.

        static void pickASymbol()
        {
            Console.WriteLine($"The symbols that you can select from are: 'X' or 'O' -- Only accepts uppercase letter");
            Console.WriteLine($"{player1Name} Please pick a symbol: ");
            checkSymbol = Console.ReadLine();        

            if (checkSymbol == "X")
            {
                player1Symbol = char.Parse(checkSymbol);
                player2Symbol = 'O';
            }

            else if (checkSymbol == "O")
            {
                player1Symbol = char.Parse(checkSymbol);
                player2Symbol = 'X';
            }

            else
            {
                Console.Clear();
                pickASymbol();
            }

        } // This function is where our players get their symbols -- it lets player1 choose his symbol and assign the other symbol to player2.

        static void player1_MarkingBoard()
        {
            Console.Clear();
            printBoard();
            Console.WriteLine($"Its {player1Name}'s turn now ({player1Symbol})");
            int choiceAsINT = 0;
            string choiceAsString;
            choiceAsString = Console.ReadLine();
            int.TryParse(choiceAsString, out choiceAsINT);
            if (choiceAsINT == 0 || choiceAsINT > 9 || arr[choiceAsINT] == 'O' || arr[choiceAsINT] == 'X') // This checks if a player has inserted a wrong input or an occupied place.
            {
                player1_MarkingBoard();
            }
            else
            {
                arr[choiceAsINT] = player1Symbol;
                winner = player1Name;
                printBoard();
                checkWinner();
                player2_MarkingBoard();
            }
        } // This function is where player1 is marking his symbol on the board.

        static void player2_MarkingBoard()
        {
            Console.Clear();
            printBoard();
            Console.WriteLine($"Its {player2Name}'s turn now ({player2Symbol})");
            int choiceAsINT = 0;
            string choiceAsString;
            choiceAsString = Console.ReadLine();
            int.TryParse(choiceAsString, out choiceAsINT);
            if (choiceAsINT == 0 || choiceAsINT > 9 || arr[choiceAsINT] == 'O' || arr[choiceAsINT] == 'X') // This checks if a player has inserted a wrong input or an occupied place.
            {
                player2_MarkingBoard();
            }
            else
            {
                arr[choiceAsINT] = player2Symbol;
                winner = player2Name;
                printBoard();
                checkWinner();
                player1_MarkingBoard();
            }
        } // This function is where player2 is marking his symbol on the board.

        static void winnerCongrations()
        {
            Console.Clear();
            printBoard();
            Console.WriteLine($"{winner} has won the game!!!");
            Console.WriteLine("Game will be terminated in 5 seconds!");
            System.Threading.Thread.Sleep(5000);
            Environment.Exit(0);
        } // This is the function that will inform the players about the winner and exit the game.

        static void checkWinner()
        {
            //Winning Condition For First Row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                winnerCongrations();
            }
            //Winning Condition For Second Row
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                winnerCongrations();
            }
            //Winning Condition For Third Row
            else if (arr[8] == arr[7] && arr[7] == arr[9])
            {
                winnerCongrations();
            }

            //Winning Condition For First Column
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                winnerCongrations();
            }

            //Winning Condition For Second Column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                winnerCongrations();
            }

            //Winning Condition For Third Column
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                winnerCongrations();
            }

            //Winning Condition For Diagonal
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                winnerCongrations();
            }

            //Winning Condition For Diagonal
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                winnerCongrations();
            }

            //Draw
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                Console.Clear();
                printBoard();
                Console.WriteLine($"This is a Draw!!!");
                Console.WriteLine("Game will be terminated in 5 seconds!");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(0);
            }

        } // This function checks all winning conditions and also draw condition -- incase of a winner it'll invoke the function "winnerCongrations".

        static void Main(string[] args)
        {
            introduction();
            pickASymbol();
            printBoard();
            player1_MarkingBoard(); // This initiates the game.
        }
    }

}