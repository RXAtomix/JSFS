using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimCity
{
    class CityHall : Building
    {
        public static int HOMETOWN_WIDTH { get; } = 25;
        public static int HOMETOWN_HEIGHT { get; } = 12;
        public static int HOMETOWN_MAX_HEALTH { get; } = 5000;

        public CityHall()
        {
            this.Health = HOMETOWN_MAX_HEALTH;
            this.Type = BuildingType.CityHall;
        }

        public override void Print()
        {
            int offset = Console.CursorLeft;
            int top = Console.CursorTop;

            // Newline if there is no space to print the building
            if (offset + HOMETOWN_WIDTH >= Console.WindowWidth)
            {
                offset = 0;
                top += HOMETOWN_HEIGHT + 1;
            }

            Console.SetCursorPosition(offset, top);
            Console.Write("/-----------------------\\");
            Console.SetCursorPosition(offset, top + 1);
            Console.Write("|     [ CITY HALL ]     |");
            Console.SetCursorPosition(offset, top + 2);
            Console.Write("\\-----------------------/");
            Console.SetCursorPosition(offset, top + 3);
            Console.Write("   | |  | |   | |  | |");
            Console.SetCursorPosition(offset, top + 4);
            Console.Write("   | |  | |   | |  | |");
            Console.SetCursorPosition(offset, top + 5);
            Console.Write("   | |  | |   | |  | |");
            Console.SetCursorPosition(offset, top + 6);
            Console.Write("   | |  | |   | |  | |");
            Console.SetCursorPosition(offset, top + 7);
            Console.Write("   | |  | |   | |  | |");
            Console.SetCursorPosition(offset, top + 8);
            Console.Write("   | |  | |   | |  | |");
            Console.SetCursorPosition(offset, top + 9);
            Console.Write("|-----------------------|");
            Console.SetCursorPosition(offset, top + 10);
            Console.Write("|-----------------------|");
            Console.SetCursorPosition(offset, top + 11);
            Console.Write("|_______________________|");
            Console.SetCursorPosition(offset + HOMETOWN_WIDTH + 1, top);
        }
    }
}
