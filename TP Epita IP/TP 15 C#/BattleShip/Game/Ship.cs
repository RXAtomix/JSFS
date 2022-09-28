using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip
{
    public class Ship
    {
        public enum ShipType { AIRCRAFT, BATTLESHIP, SUBMARINE, DESTROYER, PATROLBOAT}

        private readonly ShipType _type;
        private readonly bool _horizontal;
        private readonly List<Coordinate> _coordinates;
        private bool _sunk;

        public Ship(ShipType type, bool horizontal, Coordinate origin)
        {
            _type = type;
            _horizontal = horizontal;
            int size = GetSize(type);
            _coordinates = new List<Coordinate>();

            if (horizontal)
                for (int i = origin.GetX(); i < origin.GetX() + size; ++i)
                    _coordinates.Add(new Coordinate(i, origin.GetY()));
            else
                for (int i = origin.GetY(); i < origin.GetY() + size; ++i)
                    _coordinates.Add(new Coordinate(origin.GetX(), i));
        }

        public bool IsHorizontal()
        {
            return _horizontal;
        }

        public List<Coordinate> GetCoordinates()
        {
            return _coordinates;
        }

        public bool IsAtCoordinate(Coordinate coord)
        {
            return _coordinates.Any(coordinate => coordinate.GetX() == coord.GetX() && coordinate.GetY() == coord.GetY());
        }

        public bool IsSunk()
        {
            return _sunk;
        }


        public void SetSunk(bool sunk)
        {
            _sunk = sunk;
        }

        public ShipType GetShipType()
        {
            return _type;
        }

        public static int GetSize(ShipType type)
        {
            switch (type)
            {
                case ShipType.AIRCRAFT:
                    return 5;
                case ShipType.BATTLESHIP:
                    return 4;
                case ShipType.SUBMARINE:
                    return 3;
                case ShipType.DESTROYER:
                    return 3;
                case ShipType.PATROLBOAT:
                    return 2;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}