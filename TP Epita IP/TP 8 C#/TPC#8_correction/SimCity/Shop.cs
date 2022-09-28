using System;

namespace MySimCity
{
	class Shop : Building
	{
		public static int SHOP_WIDTH { get; } = 16;
		public static int SHOP_HEIGHT { get; } = 7;
		public static int SHOP_MAX_HEALTH { get; } = 500;

		public Shop ()
		{
			this.Health = SHOP_MAX_HEALTH;
			this.Type = BuildingType.Shop;
		}

		public override void Print ()
		{
			int offset = Console.CursorLeft;
			int previousTop = Console.CursorTop;
			int top = previousTop + CityHall.HOMETOWN_HEIGHT - SHOP_HEIGHT;


			// Newline if there is no space to print the building
			if (offset + SHOP_WIDTH >= Console.WindowWidth)
			{
				offset = 0;
				top += SHOP_HEIGHT + 1;
			}

			Console.SetCursorPosition(offset, top);
			Console.Write (" ______________");
			Console.SetCursorPosition(offset, top + 1);
			Console.Write ("|              |");
			Console.SetCursorPosition(offset, top + 2);
			Console.Write ("|   | SHOP |   |");
			Console.SetCursorPosition(offset, top + 3);
			Console.Write ("|              |");
			Console.SetCursorPosition(offset, top + 4);
			Console.Write ("|              |");
			Console.SetCursorPosition(offset, top + 5);
			Console.Write ("|      __      |");
			Console.SetCursorPosition(offset, top + 6);
			Console.Write ("|_____|  |_____|");
			Console.SetCursorPosition(offset + SHOP_WIDTH + 1, top);
		}
	}
}

