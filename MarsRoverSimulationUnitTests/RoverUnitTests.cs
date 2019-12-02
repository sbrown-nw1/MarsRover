using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverSimulation;
using Moq;

namespace MarsRoverSimulationUnitTests
{
    [TestClass]
    public class RoverUnitTests
    {
        [TestMethod]
        public void RoverCtor_ReturnsRoverWithValidArgs()
        {
            var mockGrid = new Mock<IGrid>();
            var rover = new Rover(
                new LocationCoordinate { X = 1, Y = 2 },
                CompassDirection.N,
                mockGrid.Object);

            Assert.IsNotNull(rover);
            Assert.AreEqual("Rover 1", rover.Name);
            Assert.AreEqual("1 2 N", rover.PositionWithDirection.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoverCtor_ThrowsException_WhenLocationCoordinateNull()
        {
            var mockGrid = new Mock<IGrid>();
            var rover = new Rover(
               null,
               CompassDirection.N,
               mockGrid.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoverCtor_ThrowsException_WhenGridNull()
        {
            var rover = new Rover(
               new LocationCoordinate { X = 1, Y = 2 },
               CompassDirection.N,
               null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoverCtor_ThrowsException_WhenXCoordinateLesThanZero()
        {
            var mockGrid = new Mock<IGrid>();
            var rover = new Rover(
                new LocationCoordinate { X = -1, Y = 1 },
                CompassDirection.N,
                mockGrid.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoverCtor_ThrowsException_WhenYCoordinateLessThanZero()
        {
            var mockGrid = new Mock<IGrid>();
            var rover = new Rover(
                new LocationCoordinate { X = 1, Y = -1 },
                CompassDirection.N,
                mockGrid.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalMoveInstruction))]
        public void RoverMove_ThrowsException_WhenInvalidInstruction()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 1, Y = 1 },
                CompassDirection.N,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            rover.Move("Z");
        }

        [TestMethod]
        public void RoverMove_MovesOneNorthCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.N,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 3 N", rover.Move("M").ToString());
        }

        [TestMethod]
        public void RoverMove_MovesOneEastCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.E,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("3 2 E", rover.Move("M").ToString());
        }

        [TestMethod]
        public void RoverMove_MovesOneSouthCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.S,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 1 S", rover.Move("M").ToString());
        }

        [TestMethod]
        public void RoverMove_MovesOneWestCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.W,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("1 2 W", rover.Move("M").ToString());
        }

        [TestMethod]
        public void RoverMove_RotatesToWestFromNorthCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.N,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 2 W", rover.Move("L").ToString());
        }

        [TestMethod]
        public void RoverMove_RotatesToEastFromNorthCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.N,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 2 E", rover.Move("R").ToString());
        }

        [TestMethod]
        public void RoverMove_RotatesToNorthFromEastCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.E,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 2 N", rover.Move("L").ToString());
        }

        [TestMethod]
        public void RoverMove_RotatesToSouthFromEastCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.E,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 2 S", rover.Move("R").ToString());
        }

        [TestMethod]
        public void RoverMove_RotatesToEastFromSouthCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.S,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 2 E", rover.Move("L").ToString());
        }

        [TestMethod]
        public void RoverMove_RotatesToWestFromSouthCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.S,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 2 W", rover.Move("R").ToString());
        }

        [TestMethod]
        public void RoverMove_RotatesToSouthFromWestCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.W,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 2 S", rover.Move("L").ToString());
        }

        [TestMethod]
        public void RoverMove_RotatesToNorthFromWestCorrectly_WhenValidMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 2, Y = 2 },
                CompassDirection.W,
                new Grid(new LocationCoordinate { X = 5, Y = 5 }));

            Assert.AreEqual("2 2 N", rover.Move("R").ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalMoveLocation))]
        public void RoverMove_ThrowsException_WhenInvalidNorthMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 1, Y = 1 },
                CompassDirection.N,
                new Grid(new LocationCoordinate { X = 1, Y = 1 }));

            rover.Move("M");
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalMoveLocation))]
        public void RoverMove_ThrowsException_WhenInvalidEastMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 1, Y = 1 },
                CompassDirection.E,
                new Grid(new LocationCoordinate { X = 1, Y = 1 }));

            rover.Move("M");
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalMoveLocation))]
        public void RoverMove_ThrowsException_WhenInvalidSouthMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 0, Y = 0 },
                CompassDirection.S,
                new Grid(new LocationCoordinate { X = 1, Y = 1 }));

            rover.Move("M");
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalMoveLocation))]
        public void RoverMove_ThrowsException_WhenInvalidWestMove()
        {
            var rover = new Rover(
                new LocationCoordinate { X = 0, Y = 0 },
                CompassDirection.W,
                new Grid(new LocationCoordinate { X = 1, Y = 1 }));

            rover.Move("M");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Rover.ClearAll();
        }
    }
}

