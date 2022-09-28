using System;

namespace Explorer
{
	public class Character
	{
		public int life;
		public int pos_x { get; private set; }
		public int pos_y  { get; private set; }
		public Character (int life, int x, int y)
		{
			this.life = life;
			this.pos_x = x;
			this.pos_y = y;
		}
		public void set_x(int x)
		{ 
			pos_x = x;

		}
		public void set_y(int y)
		{
			pos_y = y;
		}
		
	}
}

