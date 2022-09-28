using System;

namespace Debugger
{
	public class Ex3
	{
		/*
		 *  This function sort the array and return true.
		 */
		public static bool ex3() //FIXME maybe
		{
			int[] array = { 5, 1337, 42, 666, 1, 3, 1024};
			for (uint i = 1; i < Misc.getLength (array); ++i) 
			{
				ex3_2 (array, i, array [i]);
			}
			return ex3_3 (array);
		}

		static void ex3_2(int[] arr, uint count, int val) //FIXME maybe
		{
			uint i = count;
			while (i > 0 && arr[i-1] > val) 
			{
				arr [i] = arr [i - 1];
				--i;
			}
			arr [i] = val;	
		}

		/*
		 *  This function check if an array is sorted.
		 */
		static bool ex3_3(int[] arr) //FIXME maybe
		{
			uint i = 0;
			for (; i < Misc.getLength (arr) - 2 && arr [i + 1] > arr [i]; ++i)
				continue;
			return i == Misc.getLength (arr) - 2;
		}
	}
}

