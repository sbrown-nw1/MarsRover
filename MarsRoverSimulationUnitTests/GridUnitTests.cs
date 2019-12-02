using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverSimulation;

namespace MarsRoverSimulationUnitTests
{
    [TestClass]
    public class GridUnitTests
    {
        [TestMethod]
        public void GridCtor_ReturnsGridWithValidArgs()
        {
            var grid = new Grid(new LocationCoordinate { X = 1, Y = 1 });

            Assert.IsNotNull(grid);
            Assert.IsTrue(grid is Grid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GridCtor_ThrowsExeptionWhenLocationCoordinateNull()
        {
            var grid = new Grid(null, false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GridCtor_ThrowsException_WhenXCoordinateNotEqualToYCoordinate()
        {
            var grid = new Grid(new LocationCoordinate { X = 1, Y = 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GridCtor_ThrowsException_WhenXCoordinateLessThan1()
        {
            var grid = new Grid(new LocationCoordinate { X = 0, Y = 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GridCtor_ThrowsException_WhenYCoordinateLessThan1()
        {
            var grid = new Grid(new LocationCoordinate { X = 1, Y = 0 });
        }

        [TestMethod]
        public void GridToString_ReturnsValidGridString()
        {
            var grid = new Grid(new LocationCoordinate { X = 5, Y = 5 });

            Assert.AreEqual("[0, 0] - [5, 5]", grid.ToString());
        }
    }
}

