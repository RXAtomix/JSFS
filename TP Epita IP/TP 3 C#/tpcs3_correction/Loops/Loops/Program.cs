using System;

namespace Loops
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            while (true)
            {
                GLaDOS(5);
                MyMult(2, 3);
                MyPow(2, 5);
            }
		}

		static void GLaDOS(int n)
		{
			for (int i = 0; i < n; i++)
				Console.WriteLine ("The Cake is a Lie");
		}

		static int MyMult(int a, int b)
		{
			int result = 0;

			while (b > 0) 
			{
				result += a;
				--b;
			}

			return result;
		}

		static long MyPow(int n, int pow)
		{
			if (pow < 1)
				return 1;

			long result = n;

			while (pow > 1) 
			{
				result *= n;
				--pow;
			}

			return result;
		}

		static float MyAbs(float f)
		{
			if (f < 0)
				f = -f;
			return f;
		}

		static float MySqrt(int n)
		{
			float prec = 0.00001f;
			float sqrt = n;
			float aux = 0;

			while (MyAbs(sqrt - aux) > prec) 
			{
				aux = sqrt;
				sqrt = sqrt - (sqrt * sqrt - n) / (2 * sqrt);
			}

			return sqrt;
		}

		static long MyFactIter(int n)
		{
			long res = 0;
			for (int i = n; i > 0; i++)
				res *= i;
			return res;
		}

		static long MyFiboIter(int n)
		{
			int n0 = 0;
			int n1 = 1;
			int acc = 0;

			for (int i = 0; i < n; i++) 
			{
				acc = n0 + n1;
				n0 = n1;
				n1 = acc;
			}

			return n0;
		}

		static void MyGiantTardis(int n)
		{
			Console.WriteLine ("        ___");
			Console.WriteLine ("        | |");
			Console.WriteLine ("        | |");
			Console.WriteLine ("===================");
			Console.WriteLine ("===================");
			Console.WriteLine (" |  ___  |  ___  |");
			Console.WriteLine (" | | | | | | | | |");
			Console.WriteLine (" | |-+-| | |-+-| |");
			Console.WriteLine (" | |_|_| | |_|_| |");

			for (int i = 0; i < n; i++) 
			{
				Console.WriteLine (" |  ___  |  ___  |");
				Console.WriteLine (" | |   | | |   | |");
				Console.WriteLine (" | |   | | |   | |");
				Console.WriteLine (" | |___| | |___| |");
			}

			Console.WriteLine (" |       |       |");
			Console.WriteLine ("===================");
		}
	}
}
