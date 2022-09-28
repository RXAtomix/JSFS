using System;

namespace Explorer
{
	public class Map
	{
		private Random rnd;
		char[,] map;
		int width;
		int height;
		Character hero;

		public Map (int w, int h, Character hero, int nb_ennemies)
		{
			rnd = new Random ();
			this.hero = hero;
			width = w;
			height = h;
			map = new char[w, h];
			int x = rnd.Next (w);
			int y = rnd.Next (h);
			x = (x != hero.pos_x) ? x : (x + hero.pos_x) % width;
			y = (y != hero.pos_y) ? y : (y + hero.pos_y) % height;
			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					map [j, i] = ' ';
				}
			}
			map [x, y] = 'X';
			while (nb_ennemies > 0) {
				x = rnd.Next (w);
				y = rnd.Next (h);
				x = (x != hero.pos_x) ? x : (x + hero.pos_x) % width;
				y = (y != hero.pos_y) ? y : (y + hero.pos_y) % height;
				map [x, y] = '0';
				nb_ennemies--;
			}
		}

		public void display()
		{
			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					if (j == hero.pos_x && i == hero.pos_y)
						Console.Write (" " + 'A');
					else 
						Console.Write (" " + map [j, i]);
				}
				Console.WriteLine ('|');
			}
			for (int i = 0; i < width; i++)
				Console.Write ("--");
			Console.WriteLine ();
		}

		public void move_hero(int x, int y)
		{
			y = y < 0 ? -y : y;
			x = x < 0 ? -x : x;
			hero.set_x (x % width);
			hero.set_y (y % height);
		}
		public int over()
		{
			//Console.WriteLine (hero.life);
			if (hero.life <= 0)
				return 2;
			if (map [hero.pos_x, hero.pos_y] == 'X')
				return 1;
			return 0;
		}
		public void update(int dx, int dy)
		{
			move_hero (hero.pos_x + dx, hero.pos_y + dy);
			hero.life = hero.life - check_neighbours ();
			Console.WriteLine (hero.life);
		}
		private int check_neighbours()
		{
			int i = hero.pos_x > 0 ? hero.pos_x - 1 : hero.pos_x;
			int j = hero.pos_y > 0 ? hero.pos_y - 1 : hero.pos_y;
			int up_x = (hero.pos_y < (width - 2)) ? hero.pos_x + 1 : hero.pos_x;
			int up_y = (hero.pos_y < (height - 2)) ? hero.pos_y + 1 : hero.pos_y;
			int damage = 0;
			for (int x = i; x <= up_x; x++) {
				for (int y = j; y <= up_y; y++) {
					if (map [x, y] == '0')
						damage++;
				}
			}
			if (damage > 0)
				Console.WriteLine (damage + " Damage taken");
			return damage;
		}

	}
}

