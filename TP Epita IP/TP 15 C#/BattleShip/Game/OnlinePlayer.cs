using System;
using System.Linq;

namespace BattleShip
{
    public class OnlinePlayer : Player
    {
        private int _killcount;

        public OnlinePlayer(string name, bool display = false) : base(name, display)
        {
            _killcount = 0;
        }

        public override Coordinate Shoot()
        {
            Coordinate target = null;
            do
            {
                var input = Console.ReadLine();
                if (input == null)
                    continue;
                var data = input.Split(' ');
                if (data.Length == 2 
                    && Int32.TryParse(data[0], out int x)
                    && x < 10 && x >= 0
                    && Int32.TryParse(data[1], out int y)
                    && y < 10 && y >= 0)
                    target = new Coordinate(x, y);
            } while (target == null || Map.GetCell(target.GetX(), target.GetY()).GetPstate() != Cell.State.WATER);
            return target;
        }

        public int ReceiveShotVersus(Coordinate coord)
        {
            Cell cur = Map.GetCell(coord.GetX(), coord.GetY());
            if (cur.GetHstate() == Cell.State.BOAT
                    || cur.GetHstate() == Cell.State.HIT)
            {
                cur.SetHstate(Cell.State.HIT);
                var find = Map.GetShips().Find(ship => ship.IsAtCoordinate(cur.GetCoordinate()));
                if (find.GetCoordinates()
                    .All(coordinate => Map.GetCell(coordinate.GetX(), coordinate.GetY()).GetHstate() == Cell.State.HIT))
                {
                    find.SetSunk(true);
                    return 2;
                }
                return 1;
            }
            cur.SetHstate(Cell.State.MISSED);
            return 0;
        }

        public void setCell(Coordinate coord, int success)
        {
            if (success == 2)
                _killcount++;
            Map.GetCell(coord.GetX(), coord.GetY())
                    .SetPstate(success > 0 ? Cell.State.HIT : Cell.State.MISSED);
        }

        public bool HasWon()
        {
            return _killcount == 5;
        }
        
    }
}