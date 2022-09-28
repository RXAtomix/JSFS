using System;

namespace Arrays
{
	class MainClass
	{
		static int Search(int[] arr, int e)
		{
			int i = 0;
			while (i < arr.Length && arr [i] != e)
				++i;
			return i >= arr.Length ? -1 : i;
		}

		static int Minimum(int[] arr)
		{
			if (arr.Length == 0)
				return -1;
			int min = 0;
			for (int i = 0; i < arr.Length; ++i) 
			{
				if (arr [i] < arr [min]) 
					min = i;
			}
			return min;
		}

		static void BubbleSort(int[] arr)
		{
			for (int i = arr.Length - 1; i > 0; --i) 
			{
				bool sort = true;
				for (int j = 0; j < i; ++j) 
				{
					if (arr [j] > arr [j + 1]) 
					{
						sort = false;
						int tmp = arr [j];
						arr [j] = arr [j + 1];
						arr [j + 1] = tmp;
					}
				}
				if (sort)
					break;
			}
		}

    static void PrintArray(int[] arr)
    {
      Console.Write("arr = ");
      for (int i = 0; i < arr.Length - 1; i++)
        Console.Write(arr[i] + " ");
      if (arr.Length > 0)
        Console.Write(arr[arr.Length - 1]);
      Console.WriteLine();
    }
		
		public static void Main(string[] args)
		{
      int[] arr = { 4, 5, 3, 2, 8 };
      int[] one = { 5 };
      int[] empty = { };
      PrintArray(arr);
      Console.WriteLine("Search(arr, 5) == 2: {0}",
        Search(arr, 5) == 2 ? "OK" : "KO");
      Console.WriteLine("Search(arr, 8) == 5: {0}",
        Search(arr, 8) == 5 ? "OK" : "KO");
      Console.WriteLine("Search(arr, -10) == -1: {0}", 
        Search(arr, -10) == -1 ? "OK" : "KO");
      Console.WriteLine("Search(one, 5) == 0: {0}",
        Search(one, 5) == 0 ? "OK" : "KO");
      Console.WriteLine("Search(empty, 2) == -1: {0}", 
        Search(empty, 2) == -1 ? "OK" : "KO");
      Console.WriteLine("Minimum(arr) == 3: {0}", 
        Minimum(arr) == 3 ? "OK" : "KO");
      Console.WriteLine("Minimum(one) == 0: {0}", 
        Minimum(one) == 0 ? "OK" : "KO");
      Console.WriteLine("Minimum(empty) == -1: {0}", 
        Minimum(empty) == -1 ? "OK" : "KO");
 		}
	}
}
