using System;

namespace Application
{
	public class grid
	{
		public grid(int size)
		{
			tab = new int[size, size];
			this.size = size;
			gen_rand();
			gen_rand();
		}

		public void print_grid()
		{
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size * 6 + 1; j++)
				{
					Console.Write("#");
				}
				Console.Write("\n");
				for (int j = 0; j < size; j++)
				{
					Console.Write("#");
					if (tab[i, j] != 0)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("{0,5}", tab[i, j]);
						Console.ForegroundColor = ConsoleColor.Black;
					}
					else
					{
						Console.Write("     ");
					}
				}
				Console.WriteLine("#");
			}

			for (int j = 0; j < size * 6 + 1; j++)
			{
				Console.Write("#");
			}
			Console.WriteLine();
		}

		public bool move_down()
		{
			bool change = false;
			for (int i = size - 1; i >= 0; i--) /* toutes les lignes */
			{
				for (int k = 0; k < size; k++)
				{
					for (int j = size - 1; j >= 0; j--)
					{
						if (j > 0 && tab[j,i] != 0 && tab[j, i] == tab[j - 1, i])
						{
							change = true;
							info.score += tab[j, i] * 2;
							tab[j, i] = tab[j, i] * 2;
							tab[j - 1, i] = 0;
						}
						else if (tab[j, i] == 0 && j != 0)
						{
							change = true;
							tab[j, i] = tab[j-1, i];
							tab[j - 1, i] = 0;
						}
					}
				}
			}
			if (change)
				gen_rand();

			return change;
		}

		public bool move_up()
		{
			bool change = false;
			for (int i = 0; i < size; i++) /* toutes les lignes */
			{
				for (int k = 0; k < size; k++)
				{
					for (int j = 0; j < size; j++)
					{
						if (j < size - 1 && tab[j, i] != 0 && tab[j, i] == tab[j + 1, i])
						{
							info.score += tab[j, i] * 2;
							change = true;
							tab[j, i] = tab[j, i] * 2;
							tab[j + 1, i] = 0;
						}
						else if (tab[j, i] == 0 && j != size - 1)
						{
							change = true;
							tab[j, i] = tab[j + 1, i];
							tab[j + 1, i] = 0;
						}
					}
				}
			}
			if (change)
				gen_rand();

			return change;
		}


		private void gen_rand()
		{
			Random r = new Random();
			int val;
			if (r.Next(0, 2) == 0)
				val = 2;
			else
				val = 4;

			bool counter = true;
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (tab[i, j] == 0)
					{
						counter = false;
						break ;
					}
				}
			}

			if (counter)
				return;

			while (true)
			{
				int i = r.Next(0, size);
				int j = r.Next(0, size);

				if (tab[i, j] == 0)
				{
					tab[i, j] = val;
					break;
				}
			}


		}

		public bool move_r()
		{
			bool change = false;
			for (int i = size - 1; i >= 0; i--) /* toutes les lignes */
			{
				for (int k = 0; k < size; k++)
				{
					for (int j = size - 1; j >= 0; j--)
					{
						if (j > 0 && tab[i, j] != 0 && tab[i, j] == tab[i, j - 1])
						{
							info.score += tab[i, j] * 2;
							change = true;
							tab[i, j] = tab[i, j] * 2;
							tab[i, j - 1] = 0;
						}
						else if (tab[i, j] == 0 && j != 0)
						{
							change = true;
							tab[i, j] = tab[i, j - 1];
							tab[i, j - 1] = 0;
						}
					}
				}
			}
			if (change)
				gen_rand();

			return change;
		}

		public bool move_l()
		{
			bool change = false;
			for (int i = 0; i < size; i++) /* toutes les lignes */
			{
				for (int k = 0; k < size; k++)
				{
					for (int j = 0; j < size; j++)
					{	
						if (j < size - 1 && tab[i, j] != 0 && tab[i, j] == tab[i, j + 1])
						{
							info.score += tab[i, j] * 2;
							change = true;
							tab[i, j] = tab[i, j] * 2;
							tab[i, j + 1] = 0;
						}
						else if (tab[i, j] == 0 && j != size - 1)
						{
							change = true;
							tab[i, j] = tab[i, j + 1];
							tab[i, j + 1] = 0;
						}
					}
				}
			}
			if (change)
				gen_rand();

			return change;
		}

		public int[,] tab;
		private int size;
	}
}

