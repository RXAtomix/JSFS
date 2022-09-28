using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimCity
{
    class PoliceStation : Building
    {
        public static int POLICE_STATION_HEIGHT { get; } = 6;
        public static int POLICE_STATION_WIDTH { get; } = 25;
        public static int POLICE_STATION_MAX_HEALTH { get; } = 1000;

        public PoliceStation()
        {
            this.Health = POLICE_STATION_MAX_HEALTH;
            this.Type = BuildingType.PoliceStation;
        }

        public override void Print()
        {
            int offset = Console.CursorLeft;
            int previousTop = Console.CursorTop;
            int top = previousTop + CityHall.HOMETOWN_HEIGHT - POLICE_STATION_HEIGHT;

            // Newline if there is no space to print the building
            if (offset + POLICE_STATION_WIDTH >= Console.WindowWidth)
            {
                offset = 0;
                top += POLICE_STATION_HEIGHT + 1;
            }

            Console.SetCursorPosition(offset, top);
            Console.Write("/------------\\");
            Console.SetCursorPosition(offset, top + 1);
            Console.Write("|            |");
            Console.SetCursorPosition(offset, top + 2);
            Console.Write("| [ POLICE ] |----------\\");
            Console.SetCursorPosition(offset, top + 3);
            Console.Write("|            |  ______  |");
            Console.SetCursorPosition(offset, top + 4);
            Console.Write("|            | |------| |");
            Console.SetCursorPosition(offset, top + 5);
            Console.Write("|____________|_|______|_|");
            Console.SetCursorPosition(offset + POLICE_STATION_WIDTH + 1, previousTop);
        }
    }
}
