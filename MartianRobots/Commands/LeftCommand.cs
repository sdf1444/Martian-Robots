namespace MartianRobots.Commands
{
    /// <summary>
    /// Command to turn the robot left.
    /// </summary>
    public class LeftCommand : ICommand
    {
        public void Execute(Robot robot, Grid grid, HashSet<(int x, int y)> scentPositions)
        {
            if (!robot.IsLost)
            {
                robot.TurnLeft();
            }
        }
    }
}
