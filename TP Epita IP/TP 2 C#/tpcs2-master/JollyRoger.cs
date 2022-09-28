using System;

namespace tpcs2
{
  public class JollyRoger
  {
    static void Main()
    {
      PrintSkull ();
      Console.Read ();
      ConsoleColor fg = Console.ForegroundColor;
      ConsoleColor bg = Console.BackgroundColor;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.BackgroundColor = ConsoleColor.White;
      PrintSkull ();
      Console.Read ();
      Console.BackgroundColor = bg;
      Console.ForegroundColor = fg;
      Console.Clear ();
      Console.WriteLine ("The code is the law.");
    }

    static void PrintSkull ()
    {
      int x = (Console.BufferWidth / 2) - 16;
      int y = 0;
      if (Console.BufferHeight < 23 || Console.BufferWidth < 32)
        return;
      Console.Clear ();
      Console.SetCursorPosition (x, y++);
      Console.Write(@"         _,.++++++-.,_");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"     ,;~'             '~;, ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"   ,;                     ;,");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"  ;                         ;");
      Console.SetCursorPosition (x, y++);
      Console.Write(@" ,'                         ',");
      Console.SetCursorPosition (x, y++);
      Console.Write(@",;                           ;,");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"; ;      .           .      ; ;");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"| ;   ______       ______   ; | ");
      Console.SetCursorPosition (x, y++);
      Console.Write("|  `/~\"     ~\" . \"~     \"~\\'  |");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"|  ~  ,-~~~^~, | ,~^~~~-,  ~  |");
      Console.SetCursorPosition (x, y++);
      Console.Write(@" |   |        }:{        |   | ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@" |   l       / | \       !   |");
      Console.SetCursorPosition (x, y++);
      Console.Write(" .~  (__,.++\" .^. \"++.,__)  ~. ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@" |     ++-;' / | \ `;++-     |  ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"  \__.       \/^\/       .__/  ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"   V| \                 / |V  ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"    | |T~\___!___!___/~T| |  ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"    | |`IIII_I_I_I_IIII'| |  ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"    |  \,III I I I III,/  |  ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"     \   `~~~~~~~~~~'    /");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"       \   .       .   /");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"         \.    ^    ./   ");
      Console.SetCursorPosition (x, y++);
      Console.Write(@"           ^~~~^~~~^");
      Console.SetCursorPosition (0, y++);
    }
  }
}

