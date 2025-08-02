namespace MartianRobots.Commands
{
    /// <summary>
    /// Command to turn the robot right.
    /// </summary>
    public class RightCommand : ICommand
    {
        public void Execute(Robot robot, Grid grid, HashSet<(int x, int y)> scentPositions)
        {
            if (!robot.IsLost)
            {
                robot.TurnRight();
            }
        }
    }
}
