using System;

namespace MarsRoverSimulation
{
    public sealed class Grid : IGrid
    {
        public LocationCoordinate LowerLeftLocationCoordinate { get; private set; } = new LocationCoordinate { X = 0, Y = 0 };
        public LocationCoordinate UpperRightLocationCoordinate { get; private set; }

        public bool CheckForCollisions { get; private set; }

        public Grid(LocationCoordinate gridUpperRightLocationCoordinate, bool checkForCollisions = false)
        {
            if (gridUpperRightLocationCoordinate == null
                || gridUpperRightLocationCoordinate.X != gridUpperRightLocationCoordinate.Y
                || gridUpperRightLocationCoordinate.X <= 0)
            {
                throw new ArgumentException("Grid X, Y upper right coordinates must be equal and greater than 0 - aborting");
            }

            UpperRightLocationCoordinate = gridUpperRightLocationCoordinate;
            CheckForCollisions = checkForCollisions;
        }

        public override string ToString()
        {
            return $"[{LowerLeftLocationCoordinate.X}, {LowerLeftLocationCoordinate.Y}] - [{UpperRightLocationCoordinate.X}, {UpperRightLocationCoordinate.Y}]";
        }
    }
}