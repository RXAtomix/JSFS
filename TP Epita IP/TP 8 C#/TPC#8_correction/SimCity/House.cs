using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimCity
{
    class House : Building
    {
        public static int HOUSE_MAX_HEALTH { get; } = 500;
        public static int HOUSE_WIDTH { get; } = 12;
        public static int HOUSE_HEIGHT { get; } = 5;

        public House()
        {
            this.Health = HOUSE_MAX_HEALTH;
            this.Type = BuildingType.House;
        }

        public override void Print()
        {
            int offset = Console.CursorLeft;
            int previousTop = Console.CursorTop;
            int top = previousTop + CityHall.HOMETOWN_HEIGHT - HOUSE_HEIGHT;

            // Newline if there is no space to print the building
            if (offset + HOUSE_WIDTH >= Console.WindowWidth)
            {
                offset = 0;
                top += HOUSE_HEIGHT + 1;
            }

            Console.SetCursorPosition(offset, top);
            Console.Write("/----------\\");
            Console.SetCursorPosition(offset, top + 1);
            Console.Write("|          |");
            Console.SetCursorPosition(offset, top + 2);
            Console.Write("| [ ]  [ ] |");
            Console.SetCursorPosition(offset, top + 3);
            Console.Write("|          |");
            Console.SetCursorPosition(offset, top + 4);
            Console.Write("|__________|");
            Console.SetCursorPosition(offset + HOUSE_WIDTH + 1, previousTop);
        }
    }
}
