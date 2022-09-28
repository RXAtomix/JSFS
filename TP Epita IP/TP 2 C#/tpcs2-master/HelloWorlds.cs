using System;

namespace tpcs2
{
  class HelloWorlds
  {
    static void Hello(string str)
    {
      if (str == "")
        str = "World";
      Console.WriteLine ("Hello {0}!", str);
    }

    static void HelloWorldErr()
    {
      Console.Error.WriteLine ("Hello World!");
    }

    static void ImportantHello()
    {
      ConsoleColor bg = Console.BackgroundColor;
      ConsoleColor fg = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Red;
      Console.BackgroundColor = ConsoleColor.Yellow;
      Console.WriteLine ("This is an important announcement: Hello World!");
      Console.ForegroundColor = fg;
      Console.BackgroundColor = bg;
    }
  }
}
