using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void Should_stay_within_the_boundaries_when_driving_around_the_edges()
        {
            var rover = new Rover().Init(5, 5, 0, 0, Direction.N);

            Action<Rover> move = r =>
            {
                for (var i = 0; i < 8; i++)
                    r.Move();

                r.Right();
            };

            move(rover);
            Assert.AreEqual(new Position(0, 5, Direction.E), rover.Position);

            move(rover);
            Assert.AreEqual(new Position(5, 5, Direction.S), rover.Position);

            move(rover);
            Assert.AreEqual(new Position(5, 0, Direction.W), rover.Position);

            move(rover);
            Assert.AreEqual(new Position(0, 0, Direction.N), rover.Position);
        }

        /*Test Input:
        5 5
        1 2 N
        LMLMLMLMM

        3 3 E
        MMRMMRMRRM

        Expected Output:
        1 3 N
        5 1 E*/
        [Test]
        [TestCase(1, 2, Direction.N, "LMLMLMLMM", 1, 3, Direction.N)]
        [TestCase(3, 3, Direction.E, "MMRMMRMRRM", 5, 1, Direction.E)]
        public void End_to_end_tests(int x, int y, Direction direction, string commands, int expextedX, int expectedY, Direction expectedDirection)
        {
            var position = new Rover().Init(5, 5, x, y, direction).Exec(commands).Position;
            Assert.AreEqual(new Position(expextedX, expectedY, expectedDirection), position);
        }
    }
}
