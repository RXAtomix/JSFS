using System;
namespace TP12
{
    public abstract class Input
    {
        public enum Action { up, left, right, down };
        public abstract Action GetNextAction();
    }
}
