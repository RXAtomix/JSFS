using System;

public class ConsoleTests
{
  static void Main()
  {
    Console.WriteLine("The Code is the Law.");

    Console.Write("Jack");
    Console.Write("Sparrow\n");

    Console.WriteLine("a" + "b" + "c" + "d");
    Console.WriteLine(42);
    Console.WriteLine("42");
    Console.WriteLine(6 * 7);

    string beloved = "ACDC";
    bool best = !false;
    Console.WriteLine("The {0}s are the {1} best ones.", beloved, best);
    Console.Error.Write("An error occurred.\n");

    Console.Write("First char: ");
    int c = (char)Console.Read();
    Console.WriteLine();
    Console.WriteLine("You typed: '{0}'", (char)c);

    Console.Write("Second char: ");
    c = (char)Console.Read();
    Console.WriteLine();
    Console.WriteLine("You typed: '{0}'", (char)c);

    Console.WriteLine("Type a line:");
    string str = Console.ReadLine();
    Console.WriteLine("You typed: \"{0}\"", str);
    Console.WriteLine("Length == " + str.Length);
  }
}
