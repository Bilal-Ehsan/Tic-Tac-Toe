using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string _play = null;

            do
            {
                NewGame();
                
                Console.Write("\n\nPlay again? (y/n): ");
                _play = Console.ReadLine();

                if (_play == "y")
                    NewGame();
            } while (_play != "n");

            Console.WriteLine("\nGoodbye!");
        }

        private static void NewGame()
        {
            TicTacToe gameObj = new TicTacToe();
            gameObj.Start();
        }
    }
}
