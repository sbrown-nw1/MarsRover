namespace MarsRoverSimulation
{
    public static class MoveMap
    {
        public static readonly LocationCoordinate MoveN = new LocationCoordinate { X = 0, Y = 1 };
        public static readonly LocationCoordinate MoveE = new LocationCoordinate { X = 1, Y = 0 };
        public static readonly LocationCoordinate MoveS = new LocationCoordinate { X = 0, Y = -1 };
        public static readonly LocationCoordinate MoveW = new LocationCoordinate { X = -1, Y = 0 };
    }
}
