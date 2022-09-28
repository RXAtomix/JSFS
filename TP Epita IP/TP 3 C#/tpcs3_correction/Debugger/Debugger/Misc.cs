namespace Debugger
{
	public class Misc
	{
		public static bool isDivisorOf(int number, int divisor)
		{
			return number % divisor == 0;
		}

		public static uint getLength(int[] array)
		{
			return (uint)(array.Length);
		}

	}
}

