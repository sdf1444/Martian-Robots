using MartianRobots.Models;

namespace MartianRobots.Tests
{
    [TestFixture]
    public class RobotTests
    {
        // Turning Tests

        [Test]
        public void TurnLeft_FromNorth_FacesWest()
        {
            // Turn left from North results in West
            var robot = new Robot(0, 0, Direction.N);
            robot.TurnLeft();
            Assert.That(robot.Direction, Is.EqualTo(Direction.W));
        }

        [Test]
        public void TurnRight_FromNorth_FacesEast()
        {
            // Turn right from North results in East
            var robot = new Robot(0, 0, Direction.N);
            robot.TurnRight();
            Assert.That(robot.Direction, Is.EqualTo(Direction.E));
        }

        [Test]
        public void FullTurnLeft_CyclesThroughAllDirections()
        {
            // Four left turns cycle back to North
            var robot = new Robot(0, 0, Direction.N);
            robot.TurnLeft();
            robot.TurnLeft();
            robot.TurnLeft();
            robot.TurnLeft();
            Assert.That(robot.Direction, Is.EqualTo(Direction.N));
        }

        [Test]
        public void FullTurnRight_CyclesThroughAllDirections()
        {
            // Four right turns cycle back to North
            var robot = new Robot(0, 0, Direction.N);
            robot.TurnRight();
            robot.TurnRight();
            robot.TurnRight();
            robot.TurnRight();
            Assert.That(robot.Direction, Is.EqualTo(Direction.N));
        }

        // Movement Tests

        [Test]
        public void MoveForward_FacingNorth_IncrementsY()
        {
            // Move forward facing North increments Y
            var robot = new Robot(1, 1, Direction.N);
            robot.MoveForward();
            Assert.That(robot.X, Is.EqualTo(1));
            Assert.That(robot.Y, Is.EqualTo(2));
        }

        [Test]
        public void MoveForward_FacingEast_IncrementsX()
        {
            // Move forward facing East increments X
            var robot = new Robot(1, 1, Direction.E);
            robot.MoveForward();
            Assert.That(robot.X, Is.EqualTo(2));
            Assert.That(robot.Y, Is.EqualTo(1));
        }

        [Test]
        public void MoveForward_FacingSouth_DecrementsY()
        {
            // Move forward facing South decrements Y
            var robot = new Robot(1, 1, Direction.S);
            robot.MoveForward();
            Assert.That(robot.X, Is.EqualTo(1));
            Assert.That(robot.Y, Is.EqualTo(0));
        }

        [Test]
        public void MoveForward_FacingWest_DecrementsX()
        {
            // Move forward facing West decrements X
            var robot = new Robot(1, 1, Direction.W);
            robot.MoveForward();
            Assert.That(robot.X, Is.EqualTo(0));
            Assert.That(robot.Y, Is.EqualTo(1));
        }

        // Forward Position Prediction

        [Test]
        public void GetForwardPosition_DoesNotMoveRobot()
        {
            // GetForwardPosition predicts next position without moving
            var robot = new Robot(3, 3, Direction.N);
            var (newX, newY) = robot.GetForwardPosition();
            Assert.That(newX, Is.EqualTo(3));
            Assert.That(newY, Is.EqualTo(4));
            Assert.That(robot.X, Is.EqualTo(3));
            Assert.That(robot.Y, Is.EqualTo(3));
        }

        // Initialization Test

        [Test]
        public void Robot_InitialValues_AreCorrect()
        {
            // Robot initializes with given position and direction; not lost
            var robot = new Robot(2, 3, Direction.S);
            Assert.That(robot.X, Is.EqualTo(2));
            Assert.That(robot.Y, Is.EqualTo(3));
            Assert.That(robot.Direction, Is.EqualTo(Direction.S));
            Assert.That(robot.IsLost, Is.False);
        }
    }
}