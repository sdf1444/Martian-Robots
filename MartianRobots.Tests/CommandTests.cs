using MartianRobots.Commands;
using MartianRobots.Models;

namespace MartianRobots.Tests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void LeftCommand_RotatesLeft()
        {
            // LeftCommand rotates robot 90° left
            var robot = new Robot(0, 0, Direction.N);
            new LeftCommand().Execute(robot, new Grid(5, 3), new HashSet<(int, int)>());
            Assert.That(robot.Direction, Is.EqualTo(Direction.W));
        }

        [Test]
        public void RightCommand_RotatesRight()
        {
            // RightCommand rotates robot 90° right
            var robot = new Robot(0, 0, Direction.N);
            new RightCommand().Execute(robot, new Grid(5, 3), new HashSet<(int, int)>());
            Assert.That(robot.Direction, Is.EqualTo(Direction.E));
        }

        [Test]
        public void ForwardCommand_MovesInsideGrid()
        {
            // ForwardCommand moves robot forward within grid bounds
            var robot = new Robot(1, 1, Direction.N);
            var grid = new Grid(5, 3);
            var scents = new HashSet<(int, int)>();
            new ForwardCommand().Execute(robot, grid, scents);
            Assert.That(robot.X, Is.EqualTo(1));
            Assert.That(robot.Y, Is.EqualTo(2));
            Assert.That(robot.IsLost, Is.False);
        }

        [Test]
        public void ForwardCommand_RobotGetsLostAndLeavesScentAtGridEdge()
        {
            // Robot moves off grid, gets lost, and leaves scent
            var robot = new Robot(5, 3, Direction.N);
            var grid = new Grid(5, 3);
            var scents = new HashSet<(int, int)>();
            new ForwardCommand().Execute(robot, grid, scents);
            Assert.That(robot.IsLost);
            Assert.That(scents.Contains((5, 3)));
        }

        [Test]
        public void ForwardCommand_IgnoresMoveIfScentExistsAtEdge()
        {
            // Robot ignores forward move if scent present at edge
            var robot = new Robot(5, 3, Direction.N);
            var grid = new Grid(5, 3);
            var scents = new HashSet<(int, int)> { (5, 3) };
            new ForwardCommand().Execute(robot, grid, scents);
            Assert.That(robot.IsLost, Is.False);
            Assert.That(robot.X, Is.EqualTo(5));
            Assert.That(robot.Y, Is.EqualTo(3));
        }
    }
}
