using System;

namespace MarsRoverSimulation
{
    class Program
    {
        public static IGrid Grid { get; private set; }

        static void Main(string[] args)
        {
            RunSimulator();
        }

        public static void RunSimulator()
        {
            try
            {
                Console.Write("Enter Graph Upper Right Coordinate: ");
                var gridInit = Console.ReadLine().Split(' ');

                Grid = new Grid(new LocationCoordinate
                {
                    X = int.Parse(gridInit[0]),
                    Y = int.Parse(gridInit[1])
                }, true);

                while (true)
                {
                    try
                    {
                        var roverName = $"Rover {Rover.Count + 1}";
                        Console.Write($"{roverName} Starting Position: ");
                        var roverInit = Console.ReadLine().Split(' ');

                        if (roverInit.Length != 3)
                        {
                            throw new ArgumentException($"Starting position for {roverName} must contain X Y Direction");
                        }

                        var rover = new Rover(
                            new LocationCoordinate
                            {
                                X = int.Parse(roverInit[0]),
                                Y = int.Parse(roverInit[1])
                            },
                            (CompassDirection)Enum.Parse(typeof(CompassDirection), char.Parse(roverInit[2]).ToString()),
                            Grid);

                        Console.Write($"{roverName} Movement Plan: ");
                        var roverMoves = Console.ReadLine();

                        Console.WriteLine(rover.Move(roverMoves));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
