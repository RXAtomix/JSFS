using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            print_house();
            Console.ReadLine();
        }
        public static void roof()
        {
            Console.WriteLine("  ______________\n / | |      | | \\ \n------------------");
        }

        public static void floor()
        {
            Console.WriteLine("|    |0|   |0|    |\n|                 | ");
        }

        public static void ground()
        {
            Console.WriteLine("|        _        |\n|_____ | -| _____ | ");
        }

        public static void print_house()
        {
            roof();
            floor();
            ground();
        }
    }
}
