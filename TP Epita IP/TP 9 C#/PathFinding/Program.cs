using System;
using System.Collections.Generic;

namespace PathFinding
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Map map = new Map(new[] { 
				new Tuple<string, int>("Corridor 1", 1),
				new Tuple<string, int>("Corridor 2", 1),
				new Tuple<string, int>("Corridor 3", 1),
				new Tuple<string, int>("Corridor 4", 1),
				new Tuple<string, int>("Corridor 5", 1),
				new Tuple<string, int>("Exit", 1),
				new Tuple<string, int>("Hall", 1),
				new Tuple<string, int>("Visitation Area", 1),
				new Tuple<string, int>("Offices", 1),
				new Tuple<string, int>("Guard Building", 1),
				new Tuple<string, int>("Room 42", 1),
				new Tuple<string, int>("Common Room", 1),
				new Tuple<string, int>("Toilet", 1),
				new Tuple<string, int>("Kitchen", 1),
				new Tuple<string, int>("Bathroom", 1),
				new Tuple<string, int>("Dining Room", 1),
				new Tuple<string, int>("Security", 1),
				new Tuple<string, int>("Jack's Cell", 1),
				new Tuple<string, int>("Execution", 1)
			});

			map.AddDoorBetween ("Jack's Cell", "Corridor 5");
			map.AddDoorBetween ("Security", "Corridor 5");
			map.AddDoorBetween ("Security", "Corridor 4");
			map.AddDoorBetween ("Dining Room", "Corridor 4");
			map.AddDoorBetween ("Kitchen", "Corridor 4");
			map.AddDoorBetween ("Common Room", "Corridor 4");
			map.AddDoorBetween ("Common Room", "Toilet");
			map.AddDoorBetween ("Common Room", "Corridor 1");
			map.AddDoorBetween ("Hall", "Corridor 1");
			map.AddDoorBetween ("Hall", "Exit");
			map.AddDoorBetween ("Hall", "Offices");
			map.AddDoorBetween ("Visitation Area", "Offices");
			map.AddDoorBetween ("Guard Building", "Offices");
			map.AddDoorBetween ("Room 42", "Offices");
			map.AddDoorBetween ("Corridor 3", "Corridor 4");
			map.AddDoorBetween ("Corridor 3", "Execution");
			map.AddDoorBetween ("Corridor 3", "Room 42");
			map.AddDoorBetween ("Corridor 2", "Room 42");
			map.AddDoorBetween ("Corridor 2", "Bathroom");

			try
			{
				List<string> predictions = GetPredictions();
				Stack<Room> path = map.FindShortestPath("Jack's Cell", "Exit");
				ComparePredictions(predictions, path);
				map.WritePath("path.txt", path);
			}
			catch (Exception e)
			{
				Console.WriteLine (e);
			}
            string a = Console.ReadLine();
		}

		public static List<string> GetPredictions()
		{
			List<string> res = new List<string> ();
			string input = "";
			Console.WriteLine("What are the Captain's predictions");
			do
			{
				input = Console.ReadLine();
				res.Add(input);
			} while(input != "done");
			res.RemoveAt(res.Count - 1);
			return res;
		}

		public static void ComparePredictions(List<string> predictions, Stack<Room> path)
		{
			if (predictions.Count != path.Count)
				Console.WriteLine("Ohoh, you got it wrong !");
			int good = 0;
			foreach (Room room in path)
			{
				if (room.GetName () == predictions [good])
					good++;
				else
					break;
			}
			if (good == path.Count)
				Console.WriteLine("You are a wizard buddy, you were right!");
			else
				Console.WriteLine("Ok, you're wrong buddy. You got {0} on {1} good answers", good, path.Count);
		}
	}
}