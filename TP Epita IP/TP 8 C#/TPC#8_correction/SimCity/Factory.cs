using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimCity
{
	class Factory : Building
	{
		public static int FACTORY_WIDTH { get; } = 14;
		public static int FACTORY_HEIGHT { get; } = 8;
		public static int FACTORY_MAX_HEALTH { get; } = 750;

		public Factory ()
		{
			this.Health = FACTORY_MAX_HEALTH;
			this.Type = BuildingType.Factory;
		}

		public override void Print()
		{
			int offset = Console.CursorLeft;
			int previousTop = Console.CursorTop;
			int top = previousTop + CityHall.HOMETOWN_HEIGHT - FACTORY_HEIGHT;

			// Newline if there is no space to print the building
			if (offset + FACTORY_WIDTH >= Console.WindowWidth)
			{
				offset = 0;
				top += FACTORY_HEIGHT + 1;
			}
				
			Console.SetCursorPosition(offset, top);
			Console.Write (" ||");
			Console.SetCursorPosition(offset, top + 1);
			Console.Write (" ||");
			Console.SetCursorPosition(offset, top + 2);
			Console.Write (" || |\\ |\\ |\\");
			Console.SetCursorPosition(offset, top + 3);
			Console.Write (" ||_| \\| \\| \\");
			Console.SetCursorPosition(offset, top + 4);
			Console.Write ("|            |");
			Console.SetCursorPosition(offset, top + 5);
			Console.Write ("|            |");
			Console.SetCursorPosition(offset, top + 6);
			Console.Write ("|            |");
			Console.SetCursorPosition(offset, top + 7);
			Console.Write ("|____________|");
			Console.SetCursorPosition(offset + FACTORY_WIDTH + 1, top);
		}
	}
}

