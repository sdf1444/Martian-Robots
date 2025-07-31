using MartianRobots.Models;

namespace MartianRobots
{
    /// <summary>
    /// Represents a robot with position, orientation, and lost status.
    /// </summary>
    public class Robot
    {
        public int X { get; set; }  // Current X coordinate
        public int Y { get; set; }  // Current Y coordinate
        public Direction Direction { get; set; }  // Current facing direction
        public bool IsLost { get; set; } = false;  // Whether robot is lost

        public Robot(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        /// <summary>
        /// Rotate robot 90 degrees to the left.
        /// </summary>
        public void TurnLeft()
        {
            Direction = Direction switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => Direction
            };
        }

        /// <summary>
        /// Rotate robot 90 degrees to the right.
        /// </summary>
        public void TurnRight()
        {
            Direction = Direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => Direction
            };
        }

        /// <summary>
        /// Calculate the next position if the robot moves forward.
        /// </summary>
        public (int newX, int newY) GetForwardPosition()
        {
            return Direction switch
            {
                Direction.N => (X, Y + 1),
                Direction.S => (X, Y - 1),
                Direction.E => (X + 1, Y),
                Direction.W => (X - 1, Y),
                _ => (X, Y)
            };
        }

        /// <summary>
        /// Move the robot forward one grid point.
        /// </summary>
        public void MoveForward()
        {
            var (newX, newY) = GetForwardPosition();
            X = newX;
            Y = newY;
        }
    }
}