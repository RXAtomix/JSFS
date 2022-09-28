using System;
using System.Collections.Generic;

namespace PathFinding
{
	public class Room
	{
		private string name;
		private List<Room> neighbours;
		private int size;

		public Room(string name, int size)
		{
			this.name = name;
			this.neighbours = new List<Room>();
			this.size = size;
		}

		public string GetName()
		{
			return this.name;
		}

		public int GetSize()
		{
			return this.size;
		}

		public void AddDoorWith(Room room)
		{
			neighbours.Add(room);
			room.neighbours.Add(this);
		}

		public bool HasDoorWith(Room room)
		{
			foreach (Room neighbour in neighbours)
			{
				if (room == neighbour)
				{
					return true;
				}
			}
			return false;
		}
	}
}