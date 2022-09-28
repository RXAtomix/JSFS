using System;

namespace Debugger
{
	public class Program
	{
		static void Main()
		{

			if (Ex1.ex1 () == 74)
				Console.WriteLine ("Exercise 1: OK\n");
			if (Ex2.ex2 () == 45)
				Console.WriteLine ("Exercise 2: OK\n");
			if (Ex3.ex3 ())
				Console.WriteLine ("Exercise 3: OK");
            string a = Console.ReadLine();
		}
	}
}

