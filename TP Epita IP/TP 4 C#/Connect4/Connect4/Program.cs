using System;

namespace Connect4
{
	class MainClass
	{
		static void Print(char[,] grid, int cursor)
		{
			Console.Clear();
			Console.Write(" ");
			while (cursor > 0)
			{
				Console.Write("  ");
				cursor--;
			}
			Console.WriteLine("|");
			for (int i = 0; i < grid.GetLength(0); ++i)
			{
				Console.Write("|");
				for (int j = 0; j < grid.GetLength(1) - 1; ++j)
				{
					Console.Write(grid[i, j] + " ");
				}
				Console.WriteLine(grid[i, grid.GetLength(1) - 1] + "|");
			}
			for (int i = 0; i < grid.GetLength(1) * 2 + 1; ++i)
				Console.Write("-");
			Console.WriteLine();
		}

		static char[,] CreateGrid(int x, int y)
		{
			char[,] grid = new char[x, y];
			for (int i = 0; i < x; ++i)
				for (int j = 0; j < y; ++j)
					grid[i,j] = '-';
			return grid;
		}

		static int CheckInput(char[,] grid)
		{
			int i = 0;
			bool pressEnter = false;
			ConsoleKeyInfo input;
			Print(grid, i);
			while (!pressEnter)
			{
				input = Console.ReadKey();
				if (input.Key == ConsoleKey.LeftArrow && i > 0)
					--i;
				if (input.Key == ConsoleKey.RightArrow && i < grid.GetLength(1) - 1)
					++i;
				pressEnter = (input.Key == ConsoleKey.Enter);
				Print(grid, i);
			}
			return i;
		}

		static int AddToken(char[,] grid, int i, bool player)
		{
			if (grid[0, i] != '-')
				return -1;
			int h = 0;
			while (h < grid.GetLength(0) && grid[h, i] == '-')
				++h;
			if (player)
				grid[h - 1, i] = 'X';
			else
				grid[h - 1, i] = 'O';
			if (CheckWin(grid, h - 1, i, player))
				return 1;
			return 0;
		}

		static bool CheckLine(char[,] grid, int h, bool player)
		{
			int cnt = 0;
			for (int i = 0; i < grid.GetLength(1) && cnt < 4; ++i)
			{
				if (grid[h, i] == 'X')
				{
					if (player)
						++cnt;
					else
						cnt = 0;
				}
				else if (grid[h, i] == 'O')
				{
					if (!player)
						++cnt;
					else
						cnt = 0;
				}
				else
					cnt = 0;
			}
			return cnt == 4;
		}

		static bool CheckColumn(char[,] grid, int w, bool player)
		{
			int cnt = 0;
			for (int i = 0; i < grid.GetLength(0) && cnt < 4; ++i)
			{
				if (grid[i, w] == 'X')
				{
					if (player)
						++cnt;
					else
						cnt = 0;
				}
				else if (grid[i, w] == 'O')
				{
					if (!player)
						++cnt;
					else
						cnt = 0;
				}
				else
					cnt = 0;
			}
			return cnt == 4;
		}

		static bool CheckWin(char[,] grid, int h, int w, bool player)
		{
			return CheckLine(grid, h, player)
				|| CheckColumn(grid, w, player);
		}

		static void win(char[,] grid, bool player)
		{
			Print(grid, 0);
			if (player)
				Console.WriteLine("Player X Win !!!");
			else
				Console.WriteLine("Player O Win !!!");
		}

		static void EndFull(char[,] grid)
		{
			Print(grid, 0);
			Console.WriteLine("Nobody wins, the grid is full...");
		}

		static int IsFull(char[,] grid)
		{
			bool full = true;
			for (int i = 0; i < grid.GetLength(1); ++i)
				full = full && grid[0, i] != '-';
			if (full)
				return -1;
			else
				return 0;
		}

		public static void Main(string[] args)
		{
			int width = 5;
			int height = 4;
			char[,] grid = CreateGrid(height, width);
			bool player = true;
			int res = 0;
			while (res == 0)
			{
				int ret = CheckInput(grid);
				res = AddToken(grid, ret, player);
				if (res == -1)
					res = IsFull(grid);
				else
					player = !player;
			}
			if (res == 1)
				win(grid, !player);
			if (res == -1)
				EndFull(grid);
		}
	}
}
