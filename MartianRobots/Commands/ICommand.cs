namespace MartianRobots.Commands
{
    /// <summary>
    /// Interface for commands that manipulate robot movement.
    /// </summary>
    public interface ICommand
    {
        void Execute(Robot robot, Grid grid, HashSet<(int x, int y)> scentPositions);
    }
}
