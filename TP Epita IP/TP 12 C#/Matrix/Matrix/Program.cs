using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<Matrix<int>> test = new Matrix<Matrix<int>>(5, 6, new Matrix<int>(2));
            Matrix<Matrix<int>> test2 = new Matrix<Matrix<int>>(5, 6, new Matrix<int>(2));
            Console.WriteLine(test == test2);
            /*try
            {
                Console.WriteLine("Third constructor:");
                Matrix<int> test1 = new Matrix<int>(5, 5, 1);
                Console.WriteLine(test1.ToString());
                Console.WriteLine("Second constructor:");
                Matrix<int> test2 = new Matrix<int>(5, 5);
                Console.WriteLine(test2.ToString());
                Console.WriteLine("First constructor:");
                Matrix<int> test3 = new Matrix<int>(5);
                Console.WriteLine(test3.ToString());
                Console.WriteLine("Multiplication");
                test3 = test2 * test3;
                Console.WriteLine(test2.ToString());
                Console.WriteLine("Addition");
                test1 = test2 + test1;
                Console.WriteLine(test1.ToString());
                Console.WriteLine("Subtraction");
                test1 = test2 - test1;
                Console.WriteLine(test1.ToString());
                Console.WriteLine(test1[0, 0]);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
        }
    }
}
