qusing System;

namespace TP12
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Map map = new Map(40, 20);
            map.AddPlayer(new Player(new KeyboardInput(), 20, 10));
			map.AddPlayer(new Player(new KeyboardInput(ConsoleKey.W,
			                                           ConsoleKey.S,
			                                           ConsoleKey.A,
			                                           ConsoleKey.D)
			                         , 10, 10));
            int winner = 0;
            do
            {
                map.Display();
				System.Threading.Thread.Sleep(100);
				KeyboardInput.UpdateKey();
				winner = map.Update();
            } while (winner == 0);
            if (winner > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nPlayer {0} wins !", winner);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nNo players on the map, nobody wins");
            }
            Console.ResetColor();
        }
    }
}
