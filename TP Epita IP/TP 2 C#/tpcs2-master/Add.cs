using System;

namespace tpcs2
{
  class Add
  {
    static void Main(string[] args)
    {
      if (args.Length < 2)
        Console.Error.WriteLine ("Invalid number of operands");
      else 
      {
        int a = Int32.Parse (args [0]);
        int b = Int32.Parse (args [1]);
        Console.WriteLine ("{0}", (a + b));
      }
    }
  }
}

