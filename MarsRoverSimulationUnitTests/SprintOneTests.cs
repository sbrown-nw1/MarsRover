using MarsRoverSimulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SprintDemoTests
{
    [TestClass]
    public class SprintOneTests
    {
        [TestMethod]
        public void SprintOneDemo()
        {
            var grid = new Grid(new LocationCoordinate { X = 5, Y = 5 });

            var rover1 = new Rover(
                new LocationCoordinate { X = 1, Y = 2 },
                CompassDirection.N,
                grid);

            Assert.AreEqual("1 3 N", rover1.Move("LMLMLMLMM").ToString());

            var rover2 = new Rover(
                new LocationCoordinate { X = 3, Y = 3 },
                CompassDirection.E,
                grid);

            Assert.AreEqual("5 1 E", rover2.Move("MMRMMRMRRM").ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalMoveLocationCoordinateAlreadyOccupied))]
        public void SprintOneDemoWithCollisionCheck()
        {
            var grid = new Grid(new LocationCoordinate { X = 5, Y = 5 }, true);

            var rover1 = new Rover(
                new LocationCoordinate { X = 1, Y = 2 },
                CompassDirection.N,
                grid);

            Assert.AreEqual("1 3 N", rover1.Move("LMLMLMLMM").ToString());

            var rover2 = new Rover(
                new LocationCoordinate { X = 3, Y = 3 },
                CompassDirection.E,
                grid);

            Assert.AreEqual("5 1 E", rover2.Move("MMRMMRMRRM").ToString());

            var rover3 = new Rover(
                new LocationCoordinate { X = 1, Y = 2 },
                CompassDirection.N,
                grid);

            Assert.AreEqual("1 3 N", rover3.Move("M").ToString());
        }

        [TestCleanup]
        public void Cleanup()
        {
            Rover.ClearAll();
        }
    }
}
