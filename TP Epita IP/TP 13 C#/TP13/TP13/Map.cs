/* GIVEN FILE
 */

using System;
using System.Collections.Generic;

namespace TP13
{
	public class Map
	{
		public enum Action { up, left, right, down };


		public int Height { get; private set; }
		public int Width { get; private set; }
		public int Timeout { get; private set; }
		public bool[,] Walls { get; set; }

		public Player Self { get; set; }
		public List<Player> Others { get; set; }



		public void Init()
		{
			Timeout = Convert.ToInt32(Console.ReadLine());
			string line = Console.ReadLine();
			string[] split = line.Split(' ');
			Width = Convert.ToInt32(split[0]);
			Height = Convert.ToInt32(split[1]);
			Walls = new bool[Width, Height];

			Self = new Player();
			Others = new List<Player>();
		}

		//Deep copy
		//Expansive, avoid using it unless needed
		public Map Clone()
		{
			Map newMap = new Map();
			newMap.Height = Height;
			newMap.Width = Width;
			newMap.Walls = new bool[Width, Height];
			for (int i = 0; i < Width; i++)
				for (int j = 0; j < Height; j++)
					newMap.Walls[i, j] = Walls[i, j];
			newMap.Others = new List<Player>();
			foreach (var p in Others)
				newMap.Others.Add(p.Clone());
			newMap.Self = Self.Clone();
			return newMap;
		}

		public void Update()
		{
			int playerCount = Convert.ToInt32(Console.ReadLine());
			Others.Clear();

			// Temporary list of players so that self is first in the list
			List<Player> beforeSelf = new List<Player>();
			bool passedSelf = false;

			for (int i = 0; i < playerCount; i++)
			{
				Player newPlayer = new Player();
				Walls[newPlayer.x, newPlayer.y] = true;
				if (newPlayer.x != Self.x || newPlayer.y != Self.y)
				{
					if (passedSelf)
						Others.Add(newPlayer);
					else
						beforeSelf.Add(newPlayer);
				}
				else
					passedSelf = true;
			}
			Others.AddRange(beforeSelf);
		}

		public void Move(Action a)
		{
			Walls[Self.x, Self.y] = true;
			switch (a)
			{
				case Action.up:
					Self.y--;
					Console.WriteLine('U');
					break;
				case Action.down:
					Self.y++;
					Console.WriteLine('D');
					break;
				case Action.left:
					Self.x--;
					Console.WriteLine('L');
					break;
				case Action.right:
					Self.x++;
					Console.WriteLine('R');
					break;
			}
		}
	}
}
