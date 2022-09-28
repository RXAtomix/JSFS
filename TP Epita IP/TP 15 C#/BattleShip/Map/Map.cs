using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{

    public class Map
    {
        private readonly Cell[][] _matrix;
        private readonly List<Ship> _ships;

        public Map()
        {
            _matrix = new Cell[10][];
            for (int i = 0; i < 10; i++)
            {
                _matrix[i] = new Cell[10];
                for (int j = 0; j < 10; j++)
                {
                    _matrix[i][j] = new Cell(new Coordinate(i, j));
                }
            }
            _ships = new List<Ship>();
        }

        public Cell[][] GetMatrix()
        {
            return _matrix;
        }

        public Cell GetCell(int i, int j)
        {
            return _matrix[i][j];
        }

        public List<Ship> GetShips()
        {
            return _ships;
        }

        public void AddShip(Ship ship)
        {
            _ships.Add(ship);
            foreach (Coordinate c in ship.GetCoordinates())
                _matrix[c.GetX()][c.GetY()].SetHstate(Cell.State.BOAT);
        }

        public void PrettyPrint(string map)
        {
            var water = false;
            foreach (var c in map)
            {
                switch (c)
                {
                    case '|':
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        water = !water;
                        break;
                    case '+':
                    case '-':
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 'A':
                    case 'B':
                    case 'S':
                    case 'D':
                    case 'P':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 'X':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                if (water && c != '|')
                    Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(c);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            var sb = new StringBuilder("+ - - - - - - - - - - +  + - - - - - - - - - - +");
            sb.Append(Environment.NewLine);
            for (int i = 0; i < 10; i++)
            {
                sb.Append("|");
                for (int j = 0; j < 10; j++)
                {
                    sb.Append(' ');
                    Cell.State s = _matrix[j][i].GetHstate();
                    if (s == Cell.State.BOAT)
                    {
                        foreach (Ship sh in _ships)
                        {
                            if (sh.IsAtCoordinate(new Coordinate(j, i)))
                            {
                                sb.Append(sh.GetShipType().ToString()[0]);
                                break;
                            }
                        }
                    }
                    else
                        sb.Append(s.ToString()[0]);
                }
                sb.Append(" |  | ");
                for (int j = 0; j < 10; j++)
                {
                    sb.Append(_matrix[j][i].GetPstate().ToString()[0]).Append(' ');
                }
                sb.Append("|").Append(Environment.NewLine);
            }
            sb.Append("+ - - - - - - - - - - +  + - - - - - - - - - - +");
            return sb.ToString().Replace('W', ' ').Replace('H', 'X').Replace('M', 'O');
        }
    }

}
