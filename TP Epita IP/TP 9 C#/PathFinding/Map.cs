using System;
using System.IO;
using System.Collections.Generic;

namespace PathFinding
{
	public class Map
	{
		private List<Room> rooms;

		public Map(Tuple<string, int>[] rooms)
		{
			this.rooms = new List<Room>();
			foreach (Tuple<string, int> room in rooms)
			{
				this.rooms.Add(new Room(room.Item1, room.Item2));
			}
		}

		public void AddDoorBetween(string room1, string room2)
		{
			this.rooms.Find(room => room.GetName() == room1).AddDoorWith(rooms.Find(room => room.GetName() == room2));
		}
			
		public Stack<Room> FindShortestPath(string src, string dest)
		{
			if (this.rooms.Find (room => room.GetName() == src) == null)
			{
				throw new Exception("Room '" + src + "' not found");
			}

			if (this.rooms.Find (room => room.GetName() == dest) == null)
			{
				throw new Exception("Room '" + dest + "' not found");
			}

			bool[] done = new bool[this.rooms.Count];
			int[] parent = new int[this.rooms.Count];
			int[] distances = new int[this.rooms.Count];
			for (int i = 0; i < this.rooms.Count; i++)
			{
				done[i] = false;
				parent[i] = -1;
				distances[i] = int.MaxValue;
			}

			int current = this.rooms.FindIndex(x => x.GetName() == src);
			distances[current] = 0;
			while (!done[current])
			{
				done[current] = true;
				for (int i = 0; i < this.rooms.Count; ++i)
				{
					if (this.rooms[current].HasDoorWith(this.rooms[i]))
					{
						int dist = distances[current] + this.rooms[i].GetSize();
						if (dist < distances[i])
						{
							distances[i] = dist;
							parent[i] = current;
						}
					}
				}
				int min = int.MaxValue;
				for (int i = 0; i < this.rooms.Count; i++)
				{
					if (distances[i] < min && !done[i])
					{
						current = i;
						min = distances[i];
					}
				}
			}

			Stack<Room> shortestPath = new Stack<Room>();
			int currentIndex = this.rooms.FindIndex(x => x.GetName() == dest);
			while (currentIndex != -1)
			{
				shortestPath.Push(this.rooms[currentIndex]);
				currentIndex = parent[currentIndex];
			}

			return shortestPath;
		}

		public bool WritePath(string filename, Stack<Room> path)
		{
			int totalCost = 0;
			try
			{
				using (StreamWriter sw = new StreamWriter(filename))
				{
					sw.WriteLine("--- Path to follow ---");
					foreach (Room item in path)
					{
						sw.WriteLine(item.GetName());
						totalCost += item.GetSize();
					}
					sw.WriteLine("--------------------");
					sw.WriteLine("Total cost: " + totalCost);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Error during the opening of " + filename);
				Console.WriteLine (e);
				return false;
			}
			return true;
		}
	}
}