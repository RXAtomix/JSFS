using System;

namespace Polish
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Enter an operator (+, -, /, *, %):");
			string op = Console.ReadLine ();
			Console.WriteLine ("Enter a first value:");
			int val1 = Convert.ToInt32 (Console.ReadLine ());
			Console.WriteLine ("Enter a second value:");
			int val2 = Convert.ToInt32 (Console.ReadLine ());
			int res = eval (op, val1, val2);
			Console.WriteLine(op + " " + val1 + " " + val2 + " = " + res);
		}

		public static int eval(string op, int a, int b)
		{
			switch (op) {
			case "+":
				return a + b;
			case "-":
				return a - b;
			case "*":
				return a * b;
			case "%":
				return a % b;
			case "/":
				return a / b;
			default:
				return 0;
			}
		}
	}
}
