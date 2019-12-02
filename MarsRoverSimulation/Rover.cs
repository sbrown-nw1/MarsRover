using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverSimulation
{
    public class Rover : IRover
    {
        private LocationCoordinate currentLocationCoordinate;
        private CompassDirection currentCompassDirection;
        private readonly IGrid grid;

        private static List<Rover> rovers = new List<Rover>();

        public static int Count { get { return rovers.Count; } }
        public string Name { get; private set; }
        public PositionWithDirection PositionWithDirection { get; private set; }

        public Rover(LocationCoordinate startLocationCoordinate, CompassDirection compassStartDirection, IGrid grid)
        {
            if (startLocationCoordinate == null
                || startLocationCoordinate.X < 0
                || startLocationCoordinate.Y < 0)
            {
                throw new ArgumentException($"Rover X, Y start coordinates must be greater than or equal to 0 - aborting {Name}");
            }

            this.grid = grid ?? throw new ArgumentException($"Rover grid argument cannot be null - aborting {Name}");
            Name = $"Rover {Count + 1}";
            currentLocationCoordinate = startLocationCoordinate;
            currentCompassDirection = compassStartDirection;
            PositionWithDirection = new PositionWithDirection
            {
                CompassDirection = currentCompassDirection,
                LocationCoordinate = currentLocationCoordinate
            };

            rovers.Add(this);
        }

        public static void ClearAll()
        {
            rovers = new List<Rover>();
        }

        public PositionWithDirection Move(string moves)
        {
            var movesArray = moves.ToCharArray();

            foreach (var c in movesArray)
            {
                if (c == 'M')
                {
                    MoveOne();
                }
                else if (c == 'R')
                {
                    RotateRight();
                }
                else if (c == 'L')
                {
                    RotateLeft();
                }
                else
                {
                    throw new IllegalMoveInstruction($"Illegal move instruction: {c.ToString()} - aborting {Name}");
                }
            }

            this.PositionWithDirection = new PositionWithDirection
            {
                CompassDirection = currentCompassDirection,
                LocationCoordinate = currentLocationCoordinate
            };

            return this.PositionWithDirection;
        }

        private bool Move(LocationCoordinate newLocationCoordinate)
        {
            var newXCoordinate = currentLocationCoordinate.X + newLocationCoordinate.X;
            var newYCoordinate = currentLocationCoordinate.Y + newLocationCoordinate.Y;
            var newCoordinate = new LocationCoordinate { X = newXCoordinate, Y = newYCoordinate };

            if (newXCoordinate < grid.LowerLeftLocationCoordinate.X
                || newXCoordinate > grid.UpperRightLocationCoordinate.X
                || newYCoordinate < grid.LowerLeftLocationCoordinate.Y
                || newYCoordinate > grid.UpperRightLocationCoordinate.Y)
            {
                throw new IllegalMoveLocation($"{Name} cannot be moved to location: {newCoordinate} with defined grid: {grid} - aborting {Name}");
            }

            if (grid.CheckForCollisions
                && rovers.Where(r => r.Name != this.Name).Any(r => r.PositionWithDirection.LocationCoordinate.ToString() == newCoordinate.ToString()))
            {
                throw new IllegalMoveLocationCoordinateAlreadyOccupied(
                    $"{Name} cannot be moved to location: {newCoordinate} as the move location already contains another Rover");
            }

            currentLocationCoordinate = newCoordinate;
            return true;
        }

        private void MoveOne()
        {
            switch (currentCompassDirection)
            {
                case CompassDirection.N:
                    Move(MoveMap.MoveN);
                    break;
                case CompassDirection.E:
                    Move(MoveMap.MoveE);
                    break;
                case CompassDirection.S:
                    Move(MoveMap.MoveS);
                    break;
                case CompassDirection.W:
                    Move(MoveMap.MoveW);
                    break;
            }
        }

        private void RotateRight()
        {
            switch (currentCompassDirection)
            {
                case CompassDirection.N:
                    currentCompassDirection = CompassDirection.E;
                    break;
                case CompassDirection.E:
                    currentCompassDirection = CompassDirection.S;
                    break;
                case CompassDirection.S:
                    currentCompassDirection = CompassDirection.W;
                    break;
                case CompassDirection.W:
                    currentCompassDirection = CompassDirection.N;
                    break;
            }
        }

        private void RotateLeft()
        {
            switch (currentCompassDirection)
            {
                case CompassDirection.N:
                    currentCompassDirection = CompassDirection.W;
                    break;
                case CompassDirection.E:
                    currentCompassDirection = CompassDirection.N;
                    break;
                case CompassDirection.S:
                    currentCompassDirection = CompassDirection.E;
                    break;
                case CompassDirection.W:
                    currentCompassDirection = CompassDirection.S;
                    break;
            }
        }
    }
}

