using System;

namespace BattleShip
{

    public class InvalidPositionException : Exception
    {
        public InvalidPositionException(Coordinate coord)
        {
            Message =  "Invalid coordinates at x: " + coord.GetX() + ", y: " + coord.GetY()
                       + Environment.NewLine;
        }

        public override string Message { get; }
    }
}
