/* GIVEN FILE
 */

using System;
namespace TP13
{
	public class Player
	{
		public int x { get; set; }
		public int y { get; set; }
		public Player(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Player Clone()
		{
			return new Player(x, y);
		}

		public Player()
		{
			string line = Console.ReadLine();
			string[] split = line.Split(' ');
			x = Convert.ToInt32(split[0]);
			y = Convert.ToInt32(split[1]);
		}

		public bool MoveTo(Map m, Map.Action action)
		{
			int newx = x;
			int newy = y;
			switch (action)
			{
				case Map.Action.up:
					newy--;
					break;
				case Map.Action.down:
					newy++;
					break;
				case Map.Action.left:
					newx--;
					break;
				case Map.Action.right:
					newx++;
					break;
			}
			if (newx >= 0 && newx < m.Width
				&& newy >= 0 && newy < m.Height
				&& !m.Walls[newx, newy])
			{
				x = newx;
				y = newy;
				m.Walls[x, y] = true;
				return true;
			}
			return false;
		}
	}
}
