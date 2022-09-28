using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace BattleShip
{

    public class Player : IDisplayable
    {
        protected readonly string Name;
        protected readonly bool Display;
        protected readonly Map Map;
        protected static readonly Random Random = new Random();

        public Player(string name, bool display)
        {
            Name = name;
            Display = display;
            Map = new Map();
        }

        public Player(string name)
        {
            Name = name;
            Display = false;
            Map = new Map();
        }

        public virtual Coordinate Shoot()
        {
            Cell c;
            do {
                c = Map.GetCell(Random.Next(10), Random.Next(10));
            } while (c.GetPstate() != Cell.State.WATER);

            return c.GetCoordinate();
        }

        public bool ReceiveShoot(Coordinate coord)
        {
            Cell cur = Map.GetCell(coord.GetX(), coord.GetY());
            if (cur.GetHstate() == Cell.State.BOAT
                    || cur.GetHstate() == Cell.State.HIT)
            {
                cur.SetHstate(Cell.State.HIT);
                var find = Map.GetShips().Find(ship => ship.IsAtCoordinate(cur.GetCoordinate()));
                if (find.GetCoordinates().All(coordinate => Map.GetCell(coordinate.GetX(), coordinate.GetY()).GetHstate() == Cell.State.HIT))
                    find.SetSunk(true);
                return true;
            }
            cur.SetHstate(Cell.State.MISSED);
            return false;
        }

        public void SetCell(Coordinate coord, bool success)
        {
            Map.GetCell(coord.GetX(), coord.GetY())
                    .SetPstate(success ? Cell.State.HIT : Cell.State.MISSED);
        }

        public bool HasLost()
        {
            return Map.GetShips().All(ship => ship.IsSunk());
        }

        public void CheckPosition(Ship ship)
        {
            foreach (var c in ship.GetCoordinates())
            {
                if (c.GetY() < 0 || c.GetY() > 9
                    || c.GetX() < 0 || c.GetX() > 9 
                    || Map.GetCell(c.GetX(), c.GetY()).GetHstate() == Cell.State.BOAT)
                    throw new InvalidPositionException(c);
            }
        }

        public bool AddShip(Ship ship)
        {
            try
            {
                CheckPosition(ship);
            }
            catch (InvalidPositionException)
            {
                return false;
            }
            Map.AddShip(ship);
            return true;
        }

        public void GenerateShip(Ship.ShipType type)
        {
            var placed = false;
            while (!placed)
            {
                bool horizontal = Random.Next(2) == 0;
                var c = new Coordinate(horizontal ? Random.Next(10 - Ship.GetSize(type)) : Random.Next(10),
                        horizontal ? Random.Next(10) : Random.Next(10 - Ship.GetSize(type)));
                var s = new Ship(type, horizontal, c);
                placed = AddShip(s);
            }
        }

        public string GetName()
        {
            return Name;
        }

        public Map GetMap()
        {
            return Map;
        }

        public bool IsDisplay()
        {
            return Display;
        }
    }
}
