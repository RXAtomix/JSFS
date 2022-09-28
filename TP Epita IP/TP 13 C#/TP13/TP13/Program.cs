/* GIVEN FILE
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace TP13
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			try
			{
				Map map = new Map();
				map.Init();
				AI ai = new AI(map);
				map.Update();
				while (true)
				{
					map.Update();
					Map.Action action = ai.GetNextAction();
					map.Move(action);
				}
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e);
			}
		}
	}
}
