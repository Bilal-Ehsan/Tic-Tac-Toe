using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string play = null;

            do
            {
                NewGame();
                
                Console.Write("\n\nPlay again? (y/n): ");
                play = Console.ReadLine();

                if (play == "y")
                    NewGame();
            } while (play != "n");

            Console.WriteLine("\nGoodbye!");
        }

        private static void NewGame()
        {
            TicTacToe gameObj = new TicTacToe();
            gameObj.Start();
        }
    }
}
