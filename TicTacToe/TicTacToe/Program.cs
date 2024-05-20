using BoardLogic;
namespace TicTacToe
{
    // dead code, doesn't do anything now that TicTacGUI is here.
    // originally wrote stuff to the little cmd prompt looking window.
    class Program
    {
        static Board game = new Board();
        static void Main(string[] args)
        {
            int userTurn = -1;
            int computerTurn = -1;
            Random rand = new Random();
            while (game.checkForWinner() == 0)
            {
                while (userTurn == -1 || game.Grid[userTurn] != 0)
                {
                    Console.WriteLine("Pick Number");
                    userTurn = int.Parse(Console.ReadLine());
                }
                game.Grid[userTurn] = 1;
                if(game.isBoardFull())
                {
                    break;
                }
                while (computerTurn == -1 || game.Grid[computerTurn] != 0)
                {
                    computerTurn = rand.Next(8);
                    
                    
                }
                Console.WriteLine($"Computer chose {computerTurn}");
                game.Grid[computerTurn] = 2;
                if (game.isBoardFull())
                {
                    break;
                }
                //printBoard();
            }
            Console.WriteLine($"Player {game.checkForWinner()} won");
            Console.ReadLine();

        }
        
        // dead code now
        private static void printBoard()
        {
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if(i % 3 == 0)
                {
                    Console.WriteLine();
                }
                if (game.Grid[i] == 0)
                {
                    Console.Write(".");
                }
                else if (game.Grid[i] == 1)
                {
                    Console.Write("X");
                }
                else
                {
                    Console.Write("O");
                }               
            }
            Console.WriteLine("\n--------------------");
        }
    }
}