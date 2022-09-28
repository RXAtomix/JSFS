using System;
namespace TP12
{
    public class Player
    {
        public int x { get; private set; }
        public int y { get; private set; }
        private Input input;

        static int identifierIterator = 1;
        public int identifier { get; private set; }



        public Player(Input input, int x, int y)
        {
            identifier = identifierIterator++;
            this.input = input;
            this.x = x;
            this.y = y;
        }

        public bool Move(Map map)
        {
            switch (input.GetNextAction())
            {
                case Input.Action.up:
                    y--;
                    break;
                case Input.Action.down:
                    y++;
                    break;
                case Input.Action.left:
                    x--;
                    break;
                case Input.Action.right:
                    x++;
                    break;
            }
            return y >= 0 && x >= 0 && x < map.Width && y < map.Height
              && map.MoveTo(this);
        }

    }
}
