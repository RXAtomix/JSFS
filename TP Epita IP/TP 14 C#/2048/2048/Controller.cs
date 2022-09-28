using System;
namespace Application
{
	public class Controller
	{
		public Controller()
		{
		}

		public enum Action
		{
			Up, Down, Left, Right, Quit
		};

		public Action get_action()
		{
			ConsoleKeyInfo a = Console.ReadKey();
			if (a.Key == ConsoleKey.UpArrow)
				return Action.Up;
			else if (a.Key == ConsoleKey.DownArrow)
				return Action.Down;
			else if (a.Key == ConsoleKey.LeftArrow)
				return Action.Left;
			else if (a.Key == ConsoleKey.RightArrow)
				return Action.Right;

			return Action.Quit;
		}
	}
}