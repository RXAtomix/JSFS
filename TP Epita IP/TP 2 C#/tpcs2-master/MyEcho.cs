using System;

public class MyEcho
{
  static void Main(string[] args)
  {
    if (args.Length < 1)
      Console.WriteLine("Not enough arguments.");
    else
      Console.WriteLine(args[0]);
  }
}
