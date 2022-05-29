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
            DisplayBoard(true);
        }

        private void DisplayBoard(bool makeMove)
        {
            Console.WriteLine();

            for (int i = 0; i < board.GetLength(0); ++i)
            {
                Console.WriteLine($"{board[i, 0]} | {board[i, 1]} | {board[i, 2]}");
                if (i != 2) Console.WriteLine("---------");
            }

            if (makeMove) MakeMove();
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
            player = !player;

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
            bool hasWon = false;

            for (int i = 0; i < board.GetLength(0); ++i)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    hasWon = true;
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    hasWon = true;
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                hasWon = true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                hasWon = true;

            if (hasWon)
            {
                DeclareWinner();
                return;
            }
 
            DisplayBoard(true);
        }

        private void DeclareWinner()
        {
            DisplayBoard(false);
            player = !player;

            char winner = player ? '1' : '2';
            Console.Write("\nPlayer " + winner.ToString() +  " wins!");
        }
    }
}
