using System;
using System.Timers;

namespace MySimCity
{
	class Program
	{
		static Town town;

		static void Main (string[] args)
		{
			town = new Town ();
			Timer timer = new Timer (2000);
			timer.Elapsed += Update;
			timer.Enabled = true;
			timer.Start ();

			bool isWaiting = false;
            
			// Game loop
			while (true) {
				town.PrintState ();
				if (isWaiting) {
					Console.WriteLine ("Press any key to stop waiting");
					if (Console.KeyAvailable) {
						Console.ReadKey ();
						isWaiting = false;
					}
					System.Threading.Thread.Sleep (500);
					continue;
				}

				Console.WriteLine ("What do you want to do ?");
				Console.WriteLine ("Wait: W");
				Console.WriteLine ("Buy Building: B");
				Console.WriteLine ("Destroy Building: D");
				Console.WriteLine ("Print Town Buildings: P");
				Console.WriteLine ("Quit the game: Q");
				Console.Write ("Action ?: ");

				string input = Console.ReadLine ().ToUpper ();
				switch (input) {
				case "W":
					isWaiting = true;
					break;
				case "B":
					town.AddBuilding ();
					break;
				case "D":
					town.DestroyBuilding ();
					break;
				case "P":
					town.PrintBuildings ();
					break;
				case "Q":
					return;
				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Error.WriteLine ("Action not recognized. Press ENTER to continue");
					Console.ResetColor ();
					Console.ReadLine ();
					break;
				}
			}
		}

		private static void Update (object sender, ElapsedEventArgs e)
		{
			town.Update ();
		}
	}
}
