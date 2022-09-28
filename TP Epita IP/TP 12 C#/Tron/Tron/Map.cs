using System;
using System.Collections.Generic;

namespace TP12
{
	public class Map
	{
		public List<Player> players { get; private set; }
		int[,] squares;

		public int Width { get; private set; }
		public int Height { get; private set; }

		public Map(int x, int y)
		{
			Width = x;
			Height = y;
			players = new List<Player>();
			squares = new int[y, x];
			Console.Clear();
		}

		public void AddPlayer(Player p)
		{
			if (!MoveTo(p))
				throw new Exception("No room for new player");
			players.Add(p);
		}


		private void PrintChar(char c, int player)
		{
			switch (player)
			{
				case 1:
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case 2:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case 3:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				default:
					Console.ForegroundColor = ConsoleColor.White;
					break;
			}
			Console.Write(c);
			Console.ForegroundColor = ConsoleColor.White;
		}

		public void Display()
		{
			Console.SetCursorPosition(0, 0);
			for (int i = 0; i < squares.GetLength(0); i++)
			{
				for (int j = 0; j < squares.GetLength(1); j++)
				{
					bool hasPlayer = false;
					for (int k = 0; k < players.Count; k++)
						if (players[k].x == j && players[k].y == i)
						{
							hasPlayer = true;
							PrintChar('@', players[k].identifier);
						}
					if (!hasPlayer)
					{
						if (squares[i, j] == 0)
							Console.Write(' ');
						else
							PrintChar('#', squares[i, j]);
					}
				}
				Console.WriteLine('|');
			}
			for (int j = 0; j < squares.GetLength(1); j++)
			{
				Console.Write('-');
			}
		}

		public int Update()
		{
			if (players.Count <= 0)
                return -1; //Better than Exception

            if (players.Count == 1)
                return players[0].identifier;

			for (int i = 0; i < players.Count; i++)
			{
				if (!players[i].Move(this))
				{
					players.Remove(players[i]);
					i--;
				}
			}
			return 0;
		}

		public bool MoveTo(Player p)
		{
			if (squares[p.y, p.x] == 0)
			{
				squares[p.y, p.x] = p.identifier;
				return true;
			}
			return false;
		}
	}
}
