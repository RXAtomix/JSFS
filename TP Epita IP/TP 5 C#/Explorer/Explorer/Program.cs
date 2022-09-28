using System;

namespace Explorer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Character hero = new Character (10, 5, 0);
			Map map = new Map (15, 15, hero, 20);

			int score = 0;
			do {
				Console.Clear();
				map.display ();
				ConsoleKey k = Console.ReadKey ().Key;

				switch (k) {
				case ConsoleKey.DownArrow:
					map.update (0, 1);
					break;
				case ConsoleKey.UpArrow:
					map.update (0, -1);
					break;
				case ConsoleKey.LeftArrow:
					map.update (-1, 0);
					break;
				case ConsoleKey.RightArrow:
					map.update (1, 0);
					break;
				default:
					Console.WriteLine ("Invalid input");
					break;
					
				}
				score = map.over();
			} while (score == 0);
			if (score == 1)
				Console.WriteLine ("Victory !");
			if (score == 2)
				Console.WriteLine ("Defeat !");
		}
	}
}
