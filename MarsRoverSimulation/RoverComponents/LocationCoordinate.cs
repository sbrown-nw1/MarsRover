namespace MarsRoverSimulation
{
    public class LocationCoordinate
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}
