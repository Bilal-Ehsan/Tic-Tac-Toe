using System;

namespace TicTacToe
{
    class TicTacToe
    {
        private static char[,] _board;
        private static bool _player;

        public TicTacToe()
        {
            _board = new char[3, 3] 
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };

            _player = true; // Player 1
        }

        public void Start()
        {
            DisplayBoard(true);
        }

        private void DisplayBoard(bool makeMove)
        {
            Console.WriteLine();

            for (int i = 0; i < _board.GetLength(0); ++i)
            {
                Console.WriteLine($"{_board[i, 0]} | {_board[i, 1]} | {_board[i, 2]}");
                if (i != 2) Console.WriteLine("---------");
            }

            if (makeMove) MakeMove();
        }

        private void MakeMove()
        {  
            char playerNum = _player == true ? '1' : '2';
            Console.Write("\nPlayer " + playerNum.ToString() +  ": ");

            string userInput = Console.ReadLine();
            char square = char.Parse(userInput);

            UpdateBoard(square);
        }

        private void UpdateBoard(char position)
        {
            char symbol = _player ? 'X' : 'O';
            _player = !_player;

            for (int i = 0; i < _board.GetLength(0); ++i)
            {
                if (_board[i, 0] == position)
                {
                    _board[i, 0] = symbol;
                }
                else if (_board[i, 1] == position)
                {
                    _board[i, 1] = symbol;
                }
                else if (_board[i, 2] == position)
                {
                    _board[i, 2] = symbol;
                }
            }

            CheckWinner();
        }

        private void CheckWinner()
        {
            bool hasWon = false;

            for (int i = 0; i < _board.GetLength(0); ++i)
            {
                if (_board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2])
                    hasWon = true;
                if (_board[0, i] == _board[1, i] && _board[1, i] == _board[2, i])
                    hasWon = true;
            }

            if (_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2])
                hasWon = true;
            if (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0])
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

            _player = !_player;
            char winner = _player ? '1' : '2';

            Console.Write("\nPlayer " + winner.ToString() +  " wins!");
        }
    }
}
