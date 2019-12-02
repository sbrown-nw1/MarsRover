namespace MarsRoverSimulation
{
    public class PositionWithDirection
    {
        public LocationCoordinate LocationCoordinate { get; set; }
        public CompassDirection CompassDirection { get; set; }

        public override string ToString()
        {
            return $"{LocationCoordinate.X} {LocationCoordinate.Y} {CompassDirection}";
        }
    }
}
