namespace MartianRobots.Commands
{
    /// <summary>
    /// Command to move the robot forward.
    /// Handles lost robots and scent logic.
    /// </summary>
    public class ForwardCommand : ICommand
    {
        public void Execute(Robot robot, Grid grid, HashSet<(int x, int y)> scentPositions)
        {
            if (robot.IsLost) return;

            var (newX, newY) = robot.GetForwardPosition();

            // Check if moving forward causes the robot to fall off the grid
            if (!grid.IsInside(newX, newY))
            {
                // Check if scent exists at current position to ignore move
                if (!scentPositions.Contains((robot.X, robot.Y)))
                {
                    // Mark robot as lost and leave scent
                    robot.IsLost = true;
                    scentPositions.Add((robot.X, robot.Y));
                }
                // else: scent present, ignore the move
            }
            else
            {
                // Safe to move forward
                robot.MoveForward();
            }
        }
    }
}