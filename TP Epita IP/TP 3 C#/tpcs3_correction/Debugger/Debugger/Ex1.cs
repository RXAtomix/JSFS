using System;

namespace Debugger
{
	public class Ex1
	{
		public static int ex1() //FIXME
		{
			bool stop = false;
			int div = 42;
			while (!stop) 
			{
				bool isDivisor = Misc.isDivisorOf (666, div);
				stop |= isDivisor;
				++div;
			}
			return --div;
		}
	}
}

