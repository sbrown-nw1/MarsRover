using System;

namespace MarsRoverSimulation
{
    public class IllegalMoveInstruction : Exception
    {
        public IllegalMoveInstruction(string msg) : base(msg)
        {
        }
    }

    public class IllegalMoveLocation : Exception
    {
        public IllegalMoveLocation(string msg) : base(msg)
        {
        }
    }

    public class IllegalMoveLocationCoordinateAlreadyOccupied : Exception
    {
        public IllegalMoveLocationCoordinateAlreadyOccupied(string msg) : base(msg)
        {
        }
    }
}
