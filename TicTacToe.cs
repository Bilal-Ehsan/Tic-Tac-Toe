using System;

namespace TicTacToe
{
    class TicTacToe
    {
        private static char[,] board;
        private static bool player;

        public TicTacToe()
        {
            board = new char[3, 3] 
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };

            player = true; // Player 1
        }

        public void Start()
        {
            DisplayBoard();
        }

        private void DisplayBoard()
        {
            Console.WriteLine();

            for (int i = 0; i < board.GetLength(0); ++i)
            {
                Console.WriteLine($"{board[i, 0]} | {board[i, 1]} | {board[i, 2]}");
                if (i != 2) Console.WriteLine("---------");
            }

            MakeMove();
        }

        private void MakeMove()
        {  
            char playerNum = player == true ? '1' : '2';
            Console.Write("\nPlayer " + playerNum.ToString() +  ": ");

            string userInput = Console.ReadLine();
            char square = char.Parse(userInput);

            UpdateBoard(square);
        }

        private void UpdateBoard(char position)
        {
            char symbol = player ? 'X' : 'O';
            player = !player; // Switch player

            for (int i = 0; i < board.GetLength(0); ++i)
            {
                if (board[i, 0] == position)
                {
                    board[i, 0] = symbol;
                }
                else if (board[i, 1] == position)
                {
                    board[i, 1] = symbol;
                }
                else if (board[i, 2] == position)
                {
                    board[i, 2] = symbol;
                }
            }

            CheckWinner();
        }

        private void CheckWinner()
        {
            // NOTE: Check if there's a winner...

            // Otherwise continue
            DisplayBoard();
        }
    }
}
