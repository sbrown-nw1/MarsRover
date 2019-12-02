namespace MarsRoverSimulation
{
    public interface IRover
    {
        string Name { get; }
        PositionWithDirection PositionWithDirection { get; }
        PositionWithDirection Move(string moves);
    }
}
