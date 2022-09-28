using System;
namespace TP12
{
    public class KeyboardInput : Input
    {
		static ConsoleKeyInfo key;
		Action lastAction = Action.up;
		ConsoleKey upKey = ConsoleKey.UpArrow;
		ConsoleKey downKey = ConsoleKey.DownArrow;
		ConsoleKey leftKey = ConsoleKey.LeftArrow;
		ConsoleKey rightKey = ConsoleKey.RightArrow;

		public KeyboardInput(ConsoleKey up, ConsoleKey down,
							 ConsoleKey left, ConsoleKey right)
		{
			upKey = up;
			leftKey = left;
			rightKey = right;
			downKey = down;
		}
		public KeyboardInput()
		{
		}

		public static void UpdateKey()
		{
			if (Console.KeyAvailable)
				key = Console.ReadKey();
		}

        public override Action GetNextAction()
        {
			if (key.Key == upKey)
				lastAction = Action.up;
			else if (key.Key == downKey)
				lastAction = Action.down;
			else if (key.Key == leftKey)
				lastAction = Action.left;
			else if (key.Key == rightKey)
				lastAction = Action.right;
			
			return lastAction;
        }
    }
}
