using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class StateControllerTests
    {
        [Test]
        public void Should_start_with_initial_state()
        {
            var positionJson = new StateController(new Rover().Init(0, 0, 0, 0, Direction.N)).Get();
            Assert.AreEqual(0, positionJson.X);
            Assert.AreEqual(0, positionJson.Y);
            Assert.AreEqual(0, positionJson.R);
        }

        [Test]
        public void Should_move()
        {
            var positionJson = new StateController(new Rover().Init(10, 10, 0, 0, Direction.N))
                .Post(new CommandJson { Message = "M" });
            Assert.AreEqual(0, positionJson.X);
            Assert.AreEqual(1, positionJson.Y);
            Assert.AreEqual(0, positionJson.R);
        }
    }
}