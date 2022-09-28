
namespace BattleShip
{
    public class Cell
    {
        public enum State { WATER, BOAT, HIT, MISSED }

        private readonly Coordinate _coord;
        private State _hState;
        private State _pState;

        public Cell(Coordinate coord)
        {
            _coord = coord;
            _hState = State.WATER;
            _pState = State.WATER;
        }

        public State GetPstate()
        {
            return _pState;
        }

        public void SetPstate(State s)
        {
            _pState = s;
        }

        public State GetHstate()
        {
            return _hState;
        }

        public Coordinate GetCoordinate()
        {
            return _coord;
        }

        public void SetHstate(State s)
        {
            _hState = s;
        }
    }
}
