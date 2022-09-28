using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fact(5));
            Console.WriteLine(pow(2, 10));
            hello_name("Daddy");
            even_odd(1);
            even_odd(4);
            Console.WriteLine(deg_to_rad(53));
            Console.WriteLine(rad_to_deg(5.5F));
            Console.ReadLine();
        }

        public static int fact(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return n * fact(n - 1);
        }

        public static int pow(int x, int y)
        {
            if (y <= 0)
                return 1; ;
            return x * pow(x, y - 1);
        }

        public static void hello_name(string name)
        {
            Console.WriteLine("Hello " + name + "!");
        }

        public static void even_odd(int x)
        {
            if (x % 2 == 0)
                Console.WriteLine(x + " est pair");
            else
                Console.WriteLine(x + " est impair");
        }

        public static float deg_to_rad(float x)
        {
            return x * 0.0174533F;
        }

        public static float rad_to_deg(float x)
        {
            return x / 0.0174533F;
        }
    }
}
