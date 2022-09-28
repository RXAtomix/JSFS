using System;

namespace Parameters
{
	class MainClass
	{
		static void Swap(ref int a, ref int b)
		{
			int tmp = a;
			a = b;
			b = tmp;
		}

		static int Div(ref int a, int b)
		{
			if (b == 0)
				return -1;
			int tmp = a;
			a = a / b;
			return tmp % b;
		}

		static bool Mod(ref int a, int b)
		{
			if (b == 0)
				return false;
			a = a % b;
			return true;
		}

		static int Sum(params int[] arr)
		{
			int res = 0;
			for (int i = 0; i < arr.Length; ++i)
			{
				res += arr [i];
			}
			return res;
		}

		public static void Main (string[] args)
		{
      int a = 52;
      int b = 63;
      Swap(ref a, ref b);
      Console.WriteLine("SWAP: {0}", a == 63 && b == 52 ? "OK" : "KO");
		}
	}
}
