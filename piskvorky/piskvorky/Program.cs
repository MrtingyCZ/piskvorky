using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];

        static void Main(string[] args)
        {
            InitializeBoard();
            PrintBoard();
            PlayGame();
            Console.ReadKey();
        }

        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static void PrintBoard()
        {
            Console.WriteLine("   |   |   ");
            Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
            Console.WriteLine("   |   |   ");
        }

        static void PlayGame()
        {
            int turns = 0;
            char player = 'X';
            bool gameover = false;

            while (!gameover)
            {
                Console.Write($"Hráč {player}, zadejte řádek (0-2): ");
                int row = int.Parse(Console.ReadLine());

                Console.Write($"Hráč {player}, zadejte sloupec (0-2): ");
                int col = int.Parse(Console.ReadLine());

                if (board[row, col] == ' ')
                {
                    board[row, col] = player;
                    turns++;
                    PrintBoard();

                    if (CheckForWin(player))
                    {
                        Console.WriteLine($"Vyhrává hráč {player}!");
                        gameover = true;
                    }
                    else if (turns == 9)
                    {
                        Console.WriteLine("Remíza!");
                        gameover = true;
                    }
                    else
                    {
                        player = (player == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Místo zabráno, zadejte jiné.");
                }
            }
        }

        static bool CheckForWin(char player)
        {
            // kontrola radku
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                {
                    return true;
                }
            }

            // kontrola sloupcu
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
                {
                    return true;
                }
            }

            // kontrola uhlopricek
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }

            // zadna vyhra
            return false;
        } 
    }
}




