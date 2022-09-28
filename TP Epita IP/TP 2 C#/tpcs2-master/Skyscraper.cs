using System;

public class Program
{
  static Random random = new Random();

  static ConsoleColor GetRandomColor()
  {
    return (ConsoleColor)random.Next(0, 16);
  }

  static void Main(string[] args)
  {
    Skyscraper(42);
  }

  static void Roof()
  {
    Console.WriteLine(" ____________ ");
    Console.WriteLine("|            |");
  }

  static void Floor()
  {
    ConsoleColor oldBack = Console.BackgroundColor;
    ConsoleColor oldFore = Console.ForegroundColor;
    ConsoleColor back = GetRandomColor();
    ConsoleColor fore = GetRandomColor();

    Console.BackgroundColor = back;
    Console.ForegroundColor = fore;
    Console.Write("|  |O|  |O|  |");
    Console.BackgroundColor = oldBack;
    Console.ForegroundColor = oldFore;
    Console.WriteLine();

    Console.BackgroundColor = back;
    Console.ForegroundColor = fore;
    Console.Write("|            |");
    Console.BackgroundColor = oldBack;
    Console.ForegroundColor = oldFore;
    Console.WriteLine();

    Console.BackgroundColor = oldBack;
    Console.ForegroundColor = oldFore;
  }

  static void Floors(int n)
  {
    if (n <= 0)
      return;
    Floor();
    Floors(n - 1);
  }

  static void Ground()
  {
    Console.WriteLine("|    ____    |");
    Console.WriteLine("|___|-||-|___|");
  }

  static void Skyscraper(int n)
  {
    Roof();
    Floors(n);
    Ground();
  }
}
