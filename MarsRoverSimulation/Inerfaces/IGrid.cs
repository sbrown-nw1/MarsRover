namespace MarsRoverSimulation
{
    public interface IGrid
    {
        LocationCoordinate LowerLeftLocationCoordinate { get; }
        LocationCoordinate UpperRightLocationCoordinate { get; }
        bool CheckForCollisions { get; }
        string ToString();
    }
}
